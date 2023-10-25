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
    public class VM_OrdersByAllTables : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }

        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrdersByHalls;
        private ICommand? _goToOrderMainView;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_OrdersByAllTables(string pageIndex = "5")
        {
            PageId = pageIndex;
            Title = "ViewOrdersByAllTables";
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
    }
}
