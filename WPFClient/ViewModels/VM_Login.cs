﻿using data_access.Repositories;
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
        private ObservableCollection<EmployeeModel> employees = new ObservableCollection<EmployeeModel>();
        public IEnumerable<EmployeeModel> Employees => employees;
        public VM_Login(UnitOfWork unitOfWork, string pageIndex = "1")
        {
            UoW = unitOfWork;
            loadEmployeesCmd = new((o) => LoadEmployees());
            LoadEmployees();
            PageId = pageIndex;
            Title = "Авторизація";
        }
         
        #region Load employees
        private readonly RelayCommand loadEmployeesCmd;
        public ICommand LoadEmployeesCmd => loadEmployeesCmd;
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
                        ViewChanged?.Raise(this, new BaseTransferModel() { PageNumber = UserControlsEnum.GeneralInfo.ToString(), CurrentEmployee = selectedEmployee, UoW = this.UoW });
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
