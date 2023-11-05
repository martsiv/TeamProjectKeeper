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
        public UnitOfWork UoW;
        [DependsOn(nameof(TransferModel))]
        public EmployeeModel CurrentEmployeeModel => TransferModel.CurrentEmployee;
        [DependsOn(nameof(TransferModel))]
        public WorkShiftEmployeeModel CurrentWorkShiftEmployee { get => TransferModel.CurrentWorkShiftEmployee; }
        public OrderModel CurrentOrderModel { get; set; }
        //Обраний зал
        public HallModel? SelectedHall { get; set; }
        //Зали
        private ObservableCollection<HallModel> halls = new ObservableCollection<HallModel>();
        public IEnumerable<HallModel> Halls => halls;
        // Обраний стіл
        public TableModel? SelectedTable { get; set; }
        //Всі столи
        private ObservableCollection<TableModel> tables = new ObservableCollection<TableModel>();
        public IEnumerable<TableModel> Tables => tables;
        //Робочі зміни
        [DependsOn(nameof(TransferModel))]
        public IEnumerable<WorkShiftEmployeeModel> WorkShiftEmployees => TransferModel.WorkShiftEmployees;
        //Працівники 
        [DependsOn(nameof(TransferModel))]
        public IEnumerable<EmployeeModel> Employees => TransferModel?.Employees;
        public EmployeeModel? SelectedEmployee { get; set; }
        //Страви
        private ObservableCollection<DishModel> dishes = new ObservableCollection<DishModel>();
        public IEnumerable<DishModel> Dishes => dishes;
        //Замовлення на столиках
        private ObservableCollection<InternalOrderModel> internalOrderModels = new ObservableCollection<InternalOrderModel>();
        public IEnumerable<InternalOrderModel> InternalOrderModels => internalOrderModels;
        //Проміжна замовлення-страви
        private ObservableCollection<OrderDishModel> orderDishModels = new ObservableCollection<OrderDishModel>();
        public IEnumerable<OrderDishModel> OrderDishModels => orderDishModels;
        //Сума по всіх замовленнях поточного юзера
        public string TotalAmmountOfCurrentEmployee { get; set; }
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

        [DependsOn(nameof(TransferModel))]
        public string WorkShiftStatus => $"Зміна відкрита: {CurrentWorkShiftEmployee?.WorkShiftDate.ToShortDateString()} {CurrentWorkShiftEmployee?.TimeFrom.ToShortTimeString()}";

        public VM_Orders(UnitOfWork unitOfWork, string pageIndex = "3")
        {
            UoW = unitOfWork;
            loadAllDataCmd = new((o) => LoadAllData());
            switchToByAllTablesCmd = new((o) => SwitchToByAllTables());
            switchToByWaitersCmd = new((o) => SwitchToByWaiters());
            switchToByHallsCmd = new((o) => SwitchToByHalls());
            //Встановлюємо значення за замовчуванням
            SwitchToByWaiters();
            PageId = pageIndex;
            Title = "Вибір замовлення";
            //Завантажуємо колекції з таблиць з тривіальними даними
            LoadDishes();
            LoadHalls();
            LoadTables();
        }
        #region LoadData
        private readonly RelayCommand loadAllDataCmd;
        public ICommand LoadAllDataCmd => loadAllDataCmd;
        void LoadAllData()
        {
            AddCurrentWorkShiftEmployeeToCollection();
            TotalAmmountOfCurrentEmployee = $"Сума: {GetTotalOrderAmount(CurrentEmployeeModel.Id)}";
            LoadInternalOrders();
            LoadOrdersDishes();
        }
        //Інше завантаження даних 
        private void AddCurrentWorkShiftEmployeeToCollection()
        {
            if (!WorkShiftEmployees.Contains(CurrentWorkShiftEmployee))
                TransferModel.WorkShiftEmployees.Add(CurrentWorkShiftEmployee);
        }
        private void LoadDishes()
        {
            var res = UoW.DishRepo.Get();
            foreach (var item in res)
            {
                DishModel dish = new DishModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    SubcategoryId = item.SubcategoryId,
                };
                dishes.Add(dish);
            }
        }
        private void LoadHalls()
        {
            var res = UoW.HallRepo.Get();
            halls.Clear();
            foreach (var item in res)
            {
                HallModel hall = new HallModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                halls.Add(hall);
            }
        }
        private void LoadTables()
        {
            var res = UoW.TableRepo.Get();
            foreach (var item in res)
            {
                var hall = halls.FirstOrDefault(h => h.Id == item.HallId);
                TableModel table = new TableModel()
                {
                    Id = item.Id,
                    HallId = item.HallId,
                    Number = item.Number,
                    Hall = hall,
                };
                hall.Tables.Add(table);
                tables.Add(table);
            }
        }
        private void LoadInternalOrders()
        {
            internalOrderModels.Clear();
            var res = UoW.InternalOrderRepo.Get().Where(io => io.OrderStatusId == 1 && io.WorkShiftID == CurrentWorkShiftEmployee.WorkShiftId).ToList();
            foreach (var item in res)
            {
                var workShiftEmployee = WorkShiftEmployees.FirstOrDefault(wse => wse.EmployeeId == item.EmployeeID);
                var table = tables.FirstOrDefault(t => t.Id == item.TableId);
                InternalOrderModel internalOrder = new InternalOrderModel()
                {
                    Id = item.Id,
                    WorkShiftID = item.WorkShiftID,
                    EmployeeID = item.EmployeeID,
                    WorkShiftEmployee = workShiftEmployee,
                    OrderStatusId = item.OrderStatusId,
                    CutleryNumber = item.CutleryNumber,
                    TotalPrice = item.TotalPrice,
                    Opened = item.Opened,
                    TableId = item.TableId,
                    Tabel = table
                };
                table.InternalOrders.Add(internalOrder);
                workShiftEmployee.Orders.Add(internalOrder);
                internalOrderModels.Add(internalOrder);
            }
        }
        private void LoadOrdersDishes()
        {
            orderDishModels.Clear();

            var res = UoW.OrderDishRepo.Get(
                filter: od => od.Order.OrderStatusId == 1 && od.Order.WorkShiftID == CurrentWorkShiftEmployee.WorkShiftId,
                includeProperties: "Order.WorkShiftEmployee"
            ).ToList();
            foreach (var item in res)
            {
                var internalOrder = InternalOrderModels.FirstOrDefault(io => io.Id == item.OrderId);
                var dish = Dishes.FirstOrDefault(d => d.Id == item.DishId);
                OrderDishModel orderDishModel = new OrderDishModel()
                {
                    OrderId = item.OrderId,
                    Order = internalOrder,
                    DishId = item.DishId,
                    Dish = dish,
                    Comment = item.Comment,
                    Quantity = item.Quantity,
                };
                internalOrder.OrderDishes.Add(orderDishModel);
                dish.OrderDishes.Add(orderDishModel);
                orderDishModels.Add(orderDishModel);
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
            }
        }
        #endregion
    }
}
