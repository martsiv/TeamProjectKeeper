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

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_OrderQuickCheck : IPageViewModel
    {
        public EmployeeModel CurrentEmployeeModel { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public OrderModel CurrentOrderModel { get; set; }
        public UnitOfWork UoW { get; set; }
        private ICommand? _goToGeneralInfo;
        private ICommand? _goToPayment;
        private ICommand? _goToLogin;
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { UoW = UoW, PageNumber = "1" });
                });
            }
        }

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_OrderQuickCheck(string pageIndex = "5")
        {
            PageId = pageIndex;
            Title = "Швидкий чек";
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
        public ICommand GoToPayment
        {
            get
            {
                return _goToPayment ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPage = PageId, PageNumber = "6" });
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
    }
}
