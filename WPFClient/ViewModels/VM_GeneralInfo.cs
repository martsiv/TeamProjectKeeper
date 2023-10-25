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
    public class VM_GeneralInfo : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }
        private ICommand? _goToLogin;
        private ICommand? _goToOrdersByWaiters;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_GeneralInfo(string pageIndex = "2")
        {
            PageId = pageIndex;
            Title = "ViewGeneralInfo";
        }
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
        public ICommand GoToOrdersByWaiters
        {
            get
            {
                return _goToOrdersByWaiters ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "3" });
                });
            }
        }
    }
}
