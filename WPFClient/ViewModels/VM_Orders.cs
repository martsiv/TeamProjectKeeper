using data_access.Entities;
using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFClient.Commands;
using WPFClient.Help;
using WPFClient.Models;
using WPFClient.TransferModel;
using WPFClient.Views;

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_Orders : IPageViewModel
    {
        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW { get; set; }
        [DependsOn (nameof(TransferModel))]
        public EmployeeModel CurrentEmployeeModel => TransferModel.CurrentEmployee;
        public OrderModel CurrentOrderModel { get; set; }
        public HallModel? SelectedHall { get; set; }
        private ObservableCollection<HallModel> halls = new ObservableCollection<HallModel>();
        public IEnumerable<HallModel> Halls => halls;
        public TableModel? SelectedTable { get; set; }
        private ObservableCollection<TableModel> tables = new ObservableCollection<TableModel>();
        public IEnumerable<TableModel> Tables => tables;
        
        public VM_Orders(string pageIndex = "3")
        {
            switchToByAllTablesCmd = new((o) => SwitchToByAllTables());
            switchToByWaitersCmd = new((o) => SwitchToByWaiters());
            switchToByHallsCmd = new((o) => SwitchToByHalls());
            loadHallsCmd = new((o) => LoadHalls());
            loadTablesCmd = new((o) => LoadTables());
            //Встановлюємо значення за замовчуванням
            SwitchToByWaiters();
            PageId = pageIndex;
            Title = "Вибір замовлення";
        }
        #region LoadData
        private readonly RelayCommand loadHallsCmd;
        public ICommand LoadHallsCmd => loadHallsCmd;
        public void LoadHalls()
        {
            var res = UoW.HallRepo.Get();
            halls.Clear();
            foreach (var item in res)
            {
                halls.Add(new HallModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
        }
        private readonly RelayCommand loadTablesCmd;
        public ICommand LoadTablesCmd => loadTablesCmd;
        public void LoadTables()
        {
            if(SelectedHall == null)
                return;
            var res = UoW.TableRepo.Get().Where(x => x.HallId == SelectedHall.Id);
            tables.Clear();
            int count = 0;
            foreach (var item in res)
            {
                tables.Add(new TableModel()
                {
                    Id = item.Id,
                    HallId = item.HallId,
                });
            }
        }
        #endregion
        #region Navigation
        private ICommand? _goToLogin;
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new LoginTM() { UoW = UoW, PageNumber = UserControlsEnum.Login.ToString() });
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
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPages = TransferModel.PreviousPages, PageNumber = UserControlsEnum.GeneralInfo.ToString() });
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
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPages = TransferModel.PreviousPages, PageNumber = UserControlsEnum.Order.ToString() });
                });
            }
        }
        private ICommand? _goToQuickCheck;
        public ICommand GoToQuickCheck
        {
            get
            {
                return _goToQuickCheck ??= new RelayCommand(x =>
                {
                    TransferModel.PreviousPages.Add(PageId);
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPages = TransferModel.PreviousPages, PageNumber = UserControlsEnum.QuickOrder.ToString() });
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
                        string lastPage = TransferModel.PreviousPages.Last();
                        TransferModel.PreviousPages.RemoveAt(TransferModel.PreviousPages.Count - 1);
                        ViewChanged?.Raise(this, new BaseTransferModel() { UoW = this.UoW, PreviousPages = TransferModel.PreviousPages, CurrentEmployee = this.CurrentEmployeeModel, CurrentOrder = this.CurrentOrderModel, PageNumber = lastPage });
                    }
                }, (o) => TransferModel.PreviousPages.Count != 0);
            }
        }
        public object CurrentUserControl { get; set; }

        private readonly RelayCommand switchToByAllTablesCmd;
        public ICommand SwitchToByAllTablesCmd => switchToByAllTablesCmd;
        public void SwitchToByAllTables()
        {
            if (!(CurrentUserControl is UserControlOrdersByAllTables))
            {
                var control = new UserControlOrdersByAllTables() { DataContext = this };
                CurrentUserControl = control;
            }
        }
        private readonly RelayCommand switchToByWaitersCmd;
        public ICommand SswitchToByWaitersCmd => switchToByWaitersCmd;
        public void SwitchToByWaiters()
        {
            if (!(CurrentUserControl is UserControlOrdersByWaiters))
            {
                var control = new UserControlOrdersByWaiters() { DataContext = this };
                CurrentUserControl = control;
            }
        }
        private readonly RelayCommand switchToByHallsCmd;
        public ICommand SwitchToByHallsCmd => switchToByHallsCmd;
        public void SwitchToByHalls()
        {
            if (!(CurrentUserControl is UserControlOrdersByHalls))
            {
                var control = new UserControlOrdersByHalls() { DataContext = this };
                CurrentUserControl = control;
                LoadHalls();
            }
        }
        #endregion
    }
}
