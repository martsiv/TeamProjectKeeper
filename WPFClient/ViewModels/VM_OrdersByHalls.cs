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
    public class VM_OrdersByHalls : IPageViewModel
    {
        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrdersByWaiters;
        private ICommand? _goToOrdersByAllTables;

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_OrdersByHalls(string pageIndex = "4")
        {
            PageId = pageIndex;
            Title = "ViewOrdersByHalls";
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
        public ICommand GoToOrdersByWaiters
        {
            get
            {
                return _goToOrdersByWaiters ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "3");
                });
            }
        }
        public ICommand GoToOrdersByAllTables
        {
            get
            {
                return _goToOrdersByAllTables ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "5");
                });
            }
        }
    }
}
