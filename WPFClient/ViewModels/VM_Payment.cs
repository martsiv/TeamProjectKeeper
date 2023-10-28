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
using WPFClient.TransferModel;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_Payment : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW { get; set; }

        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrderQuickCheck;
        private ICommand? _goToLogin;
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new LoginTM() { PageNumber = "1" });
                });
            }
        }

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_Payment(string pageIndex = "8")
        {
            PageId = pageIndex;
            Title = "ViewPayment";
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
        public ICommand GoToOrderQuickCheck
        {
            get
            {
                return _goToOrderQuickCheck ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "7" });
                });
            }
        }
    }
}
