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
    public class VM_OrdersByWaiters : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }
        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrdersByHalls;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_OrdersByWaiters(string pageIndex = "3")
        {
            PageId = pageIndex;
            Title = "ViewOrdersByWaiters";
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
        public ICommand GoToOrdersByHalls
        {
            get
            {
                return _goToOrdersByHalls ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "4" });
                });
            }
        }
    }
}
