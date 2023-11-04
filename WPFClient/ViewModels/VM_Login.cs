using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClient.Commands;
using WPFClient.Help;
using WPFClient.Views;
using WPFClient.Models;
using WPFClient.TransferModel;
using data_access.Entities;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_Login : IPageViewModel
    {
        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW { get; set; }
        public EmployeeModel? SelectedEmployee { get; set; }
        public WorkShiftEmployeeModel? CurrentWorkShiftEmployee;
        public CashierShiftModel? CurrentCashierShift;
        private ObservableCollection<EmployeeModel> employees = new ObservableCollection<EmployeeModel>();
        public IEnumerable<EmployeeModel> Employees => employees;
        public VM_Login(UnitOfWork unitOfWork, string pageIndex = "1")
        {
            UoW = unitOfWork;
            LoadEmployees();
            PageId = pageIndex;
            Title = "Авторизація";
        }

        #region Load employees
        public void LoadEmployees()
        {
            var res = UoW.EmployeeRepo.Get();
            employees.Clear();
            foreach (var item in res)
            {
                employees.Add(new EmployeeModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PinCode = item.PinCode,
                });
            }
        }
        #endregion

        #region Navigation

        private ICommand? _goToGeneralInfo;
        public ICommand GoToGeneralInfo
        {
            get
            {
                return _goToGeneralInfo ??= new RelayCommand(x =>
                {
                    if (SelectedEmployee != null && CheckPin())
                    {
                        var selectedEmployee = SelectedEmployee;
                        SelectedEmployee = null;
                        var transferModel = new BaseTransferModel()
                        {
                            PageNumber = UserControlsEnum.GeneralInfo.ToString(),
                            CurrentCashierShift = this.CurrentCashierShift,
                            CurrentEmployee = selectedEmployee, 
                            UoW = this.UoW
                        };
                        var workShift = UoW.WorkShiftRepo.Get().Where(ws => ws.Date.Date == DateTime.Now.Date)?.FirstOrDefault();
                        if (workShift != null)
                        {
                            var cashierShift = UoW.CashierShiftRepo.Get().FirstOrDefault(cs => cs.WorkShiftId == workShift.Id);
                            if (cashierShift != null)
                            {
                                CurrentCashierShift = new()
                                {
                                    Id = cashierShift.Id,
                                    CashRegisterId = cashierShift.CashRegisterId,
                                    OpeningDateTime = cashierShift.OpeningDateTime,
                                    ClosingDateTime = cashierShift.ClosingDateTime,
                                    DepositedCash = cashierShift.DepositedCash,
                                    WithdrawnCash = cashierShift.WithdrawnCash,
                                    WorkShiftId = cashierShift.WorkShiftId,
                                    CashRegistryDescription = UoW.CashRegisterRepo.GetByID(cashierShift.CashRegisterId).Description
                                };
                                transferModel.CurrentCashierShift = CurrentCashierShift;
                            }
                            var workShiftEmployees = UoW.WorkShiftEmployeeRepo.Get().Where(wse => wse.WorkShiftId == workShift.Id);
                            foreach (var item in workShiftEmployees)
                            {
                                var wse = new WorkShiftEmployeeModel()
                                {
                                    WorkShiftId = item.WorkShiftId,
                                    EmployeeId = item.EmployeeId,
                                    TimeFrom = item.TimeFrom,
                                    TimeTo = item.TimeTo,
                                    WorkShiftDate = workShift.Date,
                                };
                                transferModel.WorkShiftEmployees.Add(wse);
                            }
                            var workShiftEmployee = transferModel.WorkShiftEmployees.FirstOrDefault(wse => wse.EmployeeId == selectedEmployee.Id);
                            if (workShiftEmployee != null)
                            {
                                CurrentWorkShiftEmployee = new WorkShiftEmployeeModel()
                                {
                                    WorkShiftId = workShiftEmployee.WorkShiftId,
                                    EmployeeId = selectedEmployee.Id,
                                    WorkShiftDate = workShift.Date,
                                    EmployeeModel = selectedEmployee,
                                    TimeFrom = workShiftEmployee.TimeFrom,
                                    TimeTo = workShiftEmployee.TimeTo,
                                };
                                selectedEmployee.WorkShiftEmployees.Add(CurrentWorkShiftEmployee);
                                transferModel.CurrentWorkShiftEmployee = CurrentWorkShiftEmployee;
                            }
                        }
                        foreach (var item in this.Employees)
                            transferModel.Employees.Add(item);
                        
                        ViewChanged?.Raise(this, transferModel);
                    }
                }, x => SelectedEmployee != null);
            }
        }
        private bool CheckPin()
        {
            NumbersWindow numbersWindow = new NumbersWindow();
            numbersWindow.Title = "Введіть пін";
            int enteredPin;
            if (numbersWindow.ShowDialog() == true && int.TryParse(numbersWindow.PinCode, out enteredPin))
                return SelectedEmployee?.PinCode == enteredPin;
            numbersWindow.Close();
            return false;
        }
        #endregion
    }
}