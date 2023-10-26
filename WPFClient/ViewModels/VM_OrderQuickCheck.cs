using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClient.Commands;
using WPFClient.Help;
using WPFClient.TransferModel;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_OrderQuickCheck : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }

        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrderMainView;
        private ICommand? _goToPayment;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_OrderQuickCheck(string pageIndex = "7")
        {
            PageId = pageIndex;
            Title = "ViewOrderQuickCheck";
        }
        public ICommand GoToGeneralInfo
        {
            get
            {
                return _goToGeneralInfo ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "2" });
                });
            }
        }
        public ICommand GoToOrderMainView
        {
            get
            {
                return _goToOrderMainView ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "6" });
                });
            }
        }
        public ICommand GoToPayment
        {
            get
            {
                return _goToPayment ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "8"});
                });
            }
        }
    }
}
