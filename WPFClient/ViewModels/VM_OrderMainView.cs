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
    public class VM_OrderMainView : IPageViewModel
    {
        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrdersAllTables;
        private ICommand? _goToOrderQuickCheck;

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_OrderMainView(string pageIndex = "6")
        {
            PageId = pageIndex;
            Title = "ViewOrderMainView";
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
        public ICommand GoToOrdersAllTables
        {
            get
            {
                return _goToOrdersAllTables ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "5");
                });
            }
        }
        public ICommand GoToOrderQuickCheck
        {
            get
            {
                return _goToOrderQuickCheck ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "7");
                });
            }
        }
    }
}
