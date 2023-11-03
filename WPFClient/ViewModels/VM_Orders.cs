using data_access.Entities;
using data_access.Repositories;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public UnitOfWork UoW => TransferModel.UoW;
        [DependsOn(nameof(TransferModel))]
        public EmployeeModel CurrentEmployeeModel => TransferModel.CurrentEmployee;
        [DependsOn(nameof(TransferModel))]
        public WorkShiftEmployeeModel CurrentWorkShiftEmployee { get => TransferModel.CurrentWorkShiftEmployee; set => TransferModel.CurrentWorkShiftEmployee = value; }
        public OrderModel CurrentOrderModel { get; set; }
        public HallModel? SelectedHall { get; set; }
        private ObservableCollection<HallModel> halls = new ObservableCollection<HallModel>();
        public IEnumerable<HallModel> Halls => halls;
        public TableModel? SelectedTable { get; set; }
        private ObservableCollection<TableModel> tables = new ObservableCollection<TableModel>();
        public IEnumerable<TableModel> Tables => tables;
        [DependsOn(nameof(TransferModel))]
        public string WorkShiftStatus => $"Зміна відкрита\n{CurrentWorkShiftEmployee?.WorkShiftDate.ToShortDateString()} {CurrentWorkShiftEmployee?.TimeFrom.ToShortTimeString()}";
        public decimal GetTotalOrderAmount(int? employeeId = null)
        {
            decimal totalAmount = 0;

            var orders = UoW.OrderRepo.Get(
                filter: o => o.OrderStatusId == 1 && (!employeeId.HasValue || o.EmployeeID == employeeId),
                includeProperties: "OrderDishes.Dish");

            foreach (var order in orders)
            {
                foreach (var orderDish in order.OrderDishes)
                {
                    totalAmount += orderDish.Quantity * orderDish.Dish.Price;
                }
            }

            return totalAmount;
        }

        public VM_Orders(string pageIndex = "3")
        {
            switchToByAllTablesCmd = new((o) => SwitchToByAllTables());
            switchToByWaitersCmd = new((o) => SwitchToByWaiters());
            switchToByHallsCmd = new((o) => SwitchToByHalls());
            loadHallsCmd = new((o) => LoadHalls());
            loadTablesCmd = new((o) => LoadTables(o));
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
                HallModel hall = new HallModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    LoadTablesCmd = this.LoadTablesCmd
                };
                hall.OccupiedTables = UoW.InternalOrderRepo.Get().Where(x => x.OrderStatus.Id == 1 && x.Table.Hall.Id == item.Id).Count();
                halls.Add(hall);
            }
        }
        private readonly RelayCommand loadTablesCmd;
        public ICommand LoadTablesCmd => loadTablesCmd;
        public void LoadTables(object obj)
        {
            if(obj == null)
                return;
            var res = UoW.TableRepo.Get().Where(x => x.Hall.Name == obj.ToString());
            tables.Clear();
            foreach (var item in res)
            {
                TableModel table = new TableModel()
                {
                    Id = item.Id,
                    HallId = item.HallId,
                    Number = item.Number,
                };
                tables.Add(table);
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
                    TransferModel.PageNumber = UserControlsEnum.GeneralInfo.ToString();
                    ViewChanged?.Raise(this, TransferModel);
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
                    TransferModel.PageNumber = UserControlsEnum.Order.ToString();
                    ViewChanged?.Raise(this, TransferModel);
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
                    TransferModel.PageNumber = UserControlsEnum.QuickOrder.ToString();
                    ViewChanged?.Raise(this, TransferModel);
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
                        TransferModel.PageNumber = TransferModel.PreviousPages.Last();
                        TransferModel.PreviousPages.RemoveAt(TransferModel.PreviousPages.Count - 1);
                        ViewChanged?.Raise(this, TransferModel);
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
