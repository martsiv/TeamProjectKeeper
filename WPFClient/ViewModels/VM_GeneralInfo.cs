using data_access.Entities;
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
using WPFClient.Models;
using WPFClient.TransferModel;
using WPFClient.Views;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_GeneralInfo : IPageViewModel
    {
        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW => TransferModel.UoW;
        [DependsOn(nameof(TransferModel))]
        public EmployeeModel CurrentEmployeeModel => TransferModel.CurrentEmployee;
        [DependsOn(nameof(TransferModel))]
        public WorkShiftEmployeeModel? CurrentWorkShiftEmployee { get => TransferModel.CurrentWorkShiftEmployee; set => TransferModel.CurrentWorkShiftEmployee = value; }
        [DependsOn(nameof(TransferModel))]
        public CashierShiftModel? CurrentCashierShiftModel { get => TransferModel.CurrentCashierShift; set => TransferModel.CurrentCashierShift = value; }
        [DependsOn(nameof(TransferModel))]
        public string WorkShiftStatus
        {
            get
            {
                if (!IsOpenedWorkShiftEmployee)
                    return "Зміна закрита\n" + (CurrentWorkShiftEmployee?.TimeTo != null ? $"{CurrentWorkShiftEmployee.WorkShiftDate.ToShortDateString()} {CurrentWorkShiftEmployee.TimeTo.Value.ToShortTimeString()}" : "");
                else
                    return $"Зміна відкрита\n{CurrentWorkShiftEmployee?.WorkShiftDate.ToShortDateString()} {CurrentWorkShiftEmployee?.TimeFrom.ToShortTimeString()}";
            }
        }
        [DependsOn(nameof(TransferModel))]
        public string CashierShiftStatus
        {
            get
            {
                if (!IsOpenedCashierShift)
                    return "Касова зміна закрита\n" + (CurrentCashierShiftModel?.ClosingDateTime != null ? $"{CurrentCashierShiftModel.ClosingDateTime?.ToShortDateString()} {CurrentCashierShiftModel.ClosingDateTime?.ToShortTimeString()}" : "");
                else
                    return $"Касова зміна відкрита\n{CurrentCashierShiftModel?.OpeningDateTime.ToShortDateString()} {CurrentCashierShiftModel?.OpeningDateTime.ToShortTimeString()}";
            }
        }
        

        public VM_GeneralInfo(string pageIndex = "2")
        {
            openWorkShiftEmployeeCmd = new((o) => OpenWorkShiftEmployee(), (o) => !IsOpenedWorkShiftEmployee);
            closeWorkShiftEmployeeCmd = new((o) => CloseWorkShiftEmployee(), (o) => IsOpenedWorkShiftEmployee);
            openCashierShiftCmd = new((o) => OpenCashierShift(), (o) => !IsOpenedCashierShift);
            closeCashierShiftCmd = new((o) => CloseCashierShift(), (o) => IsOpenedCashierShift);

            PageId = pageIndex;
            Title = "Загальна інформація";
        }
        #region Navigation
        private ICommand? _goToLogin;
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { UoW = UoW, PageNumber = UserControlsEnum.Login.ToString() });
                });
            }
        }
        private ICommand? _goToOrders;
        public ICommand GoToOrders
        {
            get
            {
                return _goToOrders ??= new RelayCommand(x =>
                {
                    TransferModel.PreviousPages.Add(PageId);
                    TransferModel.PageNumber = UserControlsEnum.Orders.ToString();
                    ViewChanged?.Raise(this, TransferModel);
                }, o => CurrentWorkShiftEmployee != null && CurrentWorkShiftEmployee.TimeTo == null && CurrentCashierShiftModel != null && CurrentCashierShiftModel.ClosingDateTime == null);
            }
        }
        private ICommand? _goToPreviusPage;
        public ICommand GoToPreviusPage
        {
            get
            {
                return _goToPreviusPage ??= new RelayCommand(x =>
                {
                    if (TransferModel.PreviousPages.Count != 0)
                    {
                        TransferModel.PageNumber = TransferModel.PreviousPages.Last();
                        TransferModel.PreviousPages.RemoveAt(TransferModel.PreviousPages.Count - 1);
                        ViewChanged?.Raise(this, TransferModel);
                    }
                }, o => CurrentWorkShiftEmployee != null && CurrentWorkShiftEmployee.TimeTo == null && TransferModel.PreviousPages.Count != 0);
            }
        }
        #endregion

        #region Service
        [DependsOn(nameof(TransferModel))]
        public bool IsOpenedWorkShiftEmployee => (CurrentWorkShiftEmployee != null && CurrentWorkShiftEmployee.TimeTo == null);
        [DependsOn(nameof(TransferModel))]
        public bool IsOpenedCashierShift => (CurrentCashierShiftModel != null && CurrentCashierShiftModel.ClosingDateTime == null);
        private bool IsTheLastOpenedWorkShiftEpmloyee()
        {
            //There is must be CurrentWorkShiftEmployee
            List<WorkShiftEmployee> workShiftEmployeesForToday = UoW.WorkShiftEmployeeRepo.Get().Where(wse => wse.WorkShiftId == CurrentWorkShiftEmployee.WorkShiftId).ToList();
            foreach (var workShiftEmployee in workShiftEmployeesForToday)
            {
                if (workShiftEmployee.EmployeeId != CurrentWorkShiftEmployee.EmployeeId && workShiftEmployee.TimeTo == null)
                    return false;
            }
            return true;
        }
        private bool IsAnyUnclosingOrders()
        {
            var res = UoW.OrderRepo.Get().Where(o => !(o.OrderStatus.Id == 2 || o.OrderStatus.Id == 3)).Count();
            if (res != 0)
                return true;
            else return false;
        }
        #endregion

        #region Custom commands
        private readonly RelayCommand openWorkShiftEmployeeCmd;
        public ICommand OpenWorkShiftEmployeeCmd => openWorkShiftEmployeeCmd;
        public void OpenWorkShiftEmployee()
        {
            if (CurrentWorkShiftEmployee != null && CurrentWorkShiftEmployee.TimeTo != null)
                return;
            var workShift = UoW.WorkShiftRepo.Get().Where(ws => ws.Date.Date == DateTime.Now.Date)?.FirstOrDefault();
            DateTime currentTime = DateTime.Now;
            if (workShift == null)
            {
                workShift = new WorkShift() { Date = currentTime.Date };
                UoW.WorkShiftRepo.Insert(workShift);
                UoW.Save();
            }
            WorkShiftEmployee workShiftEmployee = new WorkShiftEmployee() { EmployeeId = CurrentEmployeeModel.Id, WorkShiftId = workShift.Id, TimeFrom = new DateTime(1, 1, 1, currentTime.Hour, currentTime.Minute, currentTime.Second) };
            UoW.WorkShiftEmployeeRepo.Insert(workShiftEmployee);
            UoW.Save();
            CurrentWorkShiftEmployee = new WorkShiftEmployeeModel()
            {
                EmployeeId = workShiftEmployee.EmployeeId,
                EmployeeModel = CurrentEmployeeModel,
                WorkShiftDate = workShift.Date,
                WorkShiftId = workShiftEmployee.WorkShiftId,
                TimeFrom = workShiftEmployee.TimeFrom
            };
        }
        private readonly RelayCommand closeWorkShiftEmployeeCmd;
        public ICommand CloseWorkShiftEmployeeCmd => closeWorkShiftEmployeeCmd;
        public void CloseWorkShiftEmployee()
        {
            if (CurrentWorkShiftEmployee == null)
                return;
            if (IsTheLastOpenedWorkShiftEpmloyee() && CurrentCashierShiftModel.ClosingDateTime == null)
            {
                //There is must be custom window with error message for inform that WorkShiftEpmloyee is the last one, and we should close CashierShift first
                return;
            }
            DateTime currentTime = DateTime.Now;

            CurrentWorkShiftEmployee.TimeTo = new DateTime(1, 1, 1, currentTime.Hour, currentTime.Minute, currentTime.Second);
            var workShiftEmployee = UoW.WorkShiftEmployeeRepo.Get().FirstOrDefault(wse => wse.WorkShiftId == CurrentWorkShiftEmployee.WorkShiftId && wse.EmployeeId == CurrentEmployeeModel.Id);
            workShiftEmployee.TimeTo = CurrentWorkShiftEmployee.TimeTo;
            UoW.WorkShiftEmployeeRepo.Update(workShiftEmployee);
            UoW.Save();
            //Update view
            var tmp = CurrentWorkShiftEmployee;
            CurrentWorkShiftEmployee = null;
            CurrentWorkShiftEmployee = tmp;
        }


        private readonly RelayCommand openCashierShiftCmd;
        public ICommand OpenCashierShiftCmd => openCashierShiftCmd;
        public void OpenCashierShift()
        {
            if (CurrentCashierShiftModel != null && CurrentCashierShiftModel.ClosingDateTime != null || CurrentWorkShiftEmployee == null)
                return;
            CashierShift cashierShift = new CashierShift() { CashRegisterId = 1, WorkShiftId = CurrentWorkShiftEmployee.WorkShiftId, OpeningDateTime = DateTime.Now };
            UoW.CashierShiftRepo.Insert(cashierShift);
            UoW.Save();
            CurrentCashierShiftModel = new CashierShiftModel()
            {
                Id = cashierShift.Id,
                OpeningDateTime = cashierShift.OpeningDateTime,
                CashRegisterId = cashierShift.CashRegisterId,
                WorkShiftId = cashierShift.WorkShiftId,
                CashRegistryDescription = UoW.CashRegisterRepo.GetByID(cashierShift.CashRegisterId).Description
            };
        }
        private readonly RelayCommand closeCashierShiftCmd;
        public ICommand CloseCashierShiftCmd => closeCashierShiftCmd;
        public void CloseCashierShift()
        {
            if (CurrentCashierShiftModel == null)
                return;
            if (IsAnyUnclosingOrders())
            {
                //There is must be custom window with error message for inform that some Orders are not closed, and we should close Orders first
                return;
            }
            CurrentCashierShiftModel.ClosingDateTime = DateTime.Now;
            var cashierShift = UoW.CashierShiftRepo.Get().FirstOrDefault(cs => cs.Id == CurrentCashierShiftModel.Id);
            cashierShift.ClosingDateTime = CurrentCashierShiftModel.ClosingDateTime;
            UoW.CashierShiftRepo.Update(cashierShift);
            UoW.Save();
            //Update view
            var tmp = CurrentCashierShiftModel;
            CurrentCashierShiftModel = null;
            CurrentCashierShiftModel = tmp;
        }
        #endregion
    }
}
