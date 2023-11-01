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
    public class VM_Payment : IPageViewModel
    {
        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW => TransferModel.UoW;
        [DependsOn(nameof(TransferModel))]
        public EmployeeModel CurrentEmployeeModel => TransferModel.CurrentEmployee;
        [DependsOn(nameof(TransferModel))]
        public WorkShiftEmployeeModel CurrentWorkShiftEmployee { get => TransferModel.CurrentWorkShiftEmployee; set => TransferModel.CurrentWorkShiftEmployee = value; }

        public OrderModel CurrentOrderModel { get; set; }
        public VM_Payment(string pageIndex = "6")
        {
            PageId = pageIndex;
            Title = "Оплата";
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
        private ICommand? _goToOrderMainView;
        public ICommand GoToOrderMainView
        {
            get
            {
                return _goToOrderMainView ??= new RelayCommand(x =>
                {
                    TransferModel.PreviousPages.Add(PageId);
                    TransferModel.PageNumber = UserControlsEnum.Order.ToString();
                    ViewChanged?.Raise(this, TransferModel);
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
                    TransferModel.PageNumber = UserControlsEnum.GeneralInfo.ToString();
                    ViewChanged?.Raise(this, TransferModel);
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
                        TransferModel.PageNumber = TransferModel.PreviousPages.Last();
                        TransferModel.PreviousPages.RemoveAt(TransferModel.PreviousPages.Count - 1);
                        ViewChanged?.Raise(this, TransferModel);
                    }
                }, (o) => TransferModel.PreviousPages.Count != 0);
            }
        }
        #endregion
    }
}
