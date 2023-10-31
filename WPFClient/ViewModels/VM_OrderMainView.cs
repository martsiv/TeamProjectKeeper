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
    public class VM_OrderMainView : IPageViewModel
    {
        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW { get; set; }
        public EmployeeModel CurrentEmployeeModel { get; set; }
        public OrderModel CurrentOrderModel { get; set; }
        public VM_OrderMainView(string pageIndex = "4")
        {
            PageId = pageIndex;
            Title = "Замовлення";
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
        private ICommand? _goToGeneralInfo;
        public ICommand GoToGeneralInfo
        {
            get
            {
                return _goToGeneralInfo ??= new RelayCommand(x =>
                {
                    TransferModel.PreviousPages.Add(PageId);
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPages = TransferModel.PreviousPages, PageNumber = UserControlsEnum.GeneralInfo.ToString() });
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
                    if (TransferModel.PreviousPages.Count != 0)
                    {
                        string lastPage = TransferModel.PreviousPages.Last();
                        TransferModel.PreviousPages.RemoveAt(TransferModel.PreviousPages.Count - 1);
                        ViewChanged?.Raise(this, new BaseTransferModel() { UoW = this.UoW, PreviousPages = TransferModel.PreviousPages, CurrentEmployee = this.CurrentEmployeeModel, CurrentOrder = this.CurrentOrderModel, PageNumber = lastPage });
                    }
                }, (o) => TransferModel.PreviousPages.Count != 0);
            }
        }
        #endregion
    }
}
