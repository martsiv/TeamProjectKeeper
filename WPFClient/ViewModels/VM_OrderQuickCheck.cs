using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClient.Commands;
using WPFClient.Help;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_OrderQuickCheck : IPageViewModel
    {
        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrderMainView;
        private ICommand? _goToPayment;

        public event EventHandler<EventArgs<string>>? ViewChanged;
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
                    ViewChanged?.Raise(this, "2");
                });
            }
        }
        public ICommand GoToOrderMainView
        {
            get
            {
                return _goToOrderMainView ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "6");
                });
            }
        }
        public ICommand GoToPayment
        {
            get
            {
                return _goToPayment ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "8");
                });
            }
        }
    }
}
