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
    public class VM_OrdersByHalls : IPageViewModel
    {
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW { get; set; }
        private ICommand? _goToGeneralInfo;
        private ICommand? _goToOrdersByWaiters;
        private ICommand? _goToOrdersByAllTables;
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
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "2" });
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
        public ICommand GoToOrdersByAllTables
        {
            get
            {
                return _goToOrdersByAllTables ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new GeneralInfoTM() { PageNumber = "5" });
                });
            }
        }

    }
}
