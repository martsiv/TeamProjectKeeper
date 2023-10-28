using data_access.Entities;
using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
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
    public class VM_Orders : IPageViewModel
    {
        public EmployeeModel CurrentEmployeeModel { get; set; }
        public UnitOfWork UoW { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public OrderModel CurrentOrderModel { get; set; }

        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrderMainView;
        private ICommand? _goToLogin;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_Orders(string pageIndex = "3")
        {
            switchToByAllTablesCmd = new((o) => SwitchToByAllTables(), (o) => !(CurrentUserControl is UserControlOrdersByAllTables));
            switchToByWaitersCmd = new((o) => SwitchToByWaiters(), (o) => !(CurrentUserControl is UserControlOrdersByWaiters));
            switchToByHallsCmd = new((o) => SwitchToByHalls(), (o) => !(CurrentUserControl is UserControlOrdersByHalls));

            PageId = pageIndex;
            Title = "Вибір замовлення";
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new LoginTM() { UoW = UoW, PageNumber = "1" });
                });
            }
        }
        public ICommand GoToGeneralInfo
        {
            get
            {
                return _goToGeneralInfo ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPage = PageId, PageNumber = "2" });
                });
            }
        }
        public ICommand GoToOrderMainView
        {
            get
            {
                return _goToOrderMainView ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPage = PageId, PageNumber = "4" });
                });
            }
        }
        private ICommand? _goToQuickCheck;
        public ICommand GoToQuickCheck
        {
            get
            {
                return _goToQuickCheck ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPage = PageId, PageNumber = "5" });
                });
            }
        }
        private ICommand? _goToPreviusPage;
        public ICommand GoToPreviusPage
        {
            get
            {
                return _goToPreviusPage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { PreviousPage = PageId, UoW = this.UoW, CurrentEmployee = this.CurrentEmployeeModel, CurrentOrder = this.CurrentOrderModel, PageNumber = TransferModel.PreviousPage });
                });
            }
        }

        public object CurrentUserControl { get; set; }

        private readonly RelayCommand switchToByAllTablesCmd;
        public ICommand SwitchToByAllTablesCmd => switchToByAllTablesCmd;
        public void SwitchToByAllTables()
        {
            var control = new UserControlOrdersByAllTables() { DataContext = this };
            CurrentUserControl = control;
        }

        private readonly RelayCommand switchToByWaitersCmd;
        public ICommand SswitchToByWaitersCmd => switchToByWaitersCmd;
        public void SwitchToByWaiters()
        {
            var control = new UserControlOrdersByWaiters() { DataContext = this };
            CurrentUserControl = control;
        }

        private readonly RelayCommand switchToByHallsCmd;
        public ICommand SwitchToByHallsCmd => switchToByHallsCmd;
        public void SwitchToByHalls()
        {
            var control = new UserControlOrdersByHalls() { DataContext = this };
            CurrentUserControl = control;
        }
    }
}
