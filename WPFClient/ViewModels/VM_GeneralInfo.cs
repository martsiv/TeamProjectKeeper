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

namespace WPFClient.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_GeneralInfo : IPageViewModel
    {
        private ObservableCollection<EmployeeModel> employeeModels = new ObservableCollection<EmployeeModel>();
        private ObservableCollection<CategoryModel> categoryModels = new ObservableCollection<CategoryModel>();
        private ObservableCollection<DeliveryOrderModel> deliveryOrderModels = new ObservableCollection<DeliveryOrderModel>();
        private ObservableCollection<DishModel> dishModels = new ObservableCollection<DishModel>();
        private ObservableCollection<InternalOrderModel> internalOrderModels = new ObservableCollection<InternalOrderModel>();
        private ObservableCollection<OrderDishModel> orderDishModels = new ObservableCollection<OrderDishModel>();
        private ObservableCollection<OrderModel> orderModels = new ObservableCollection<OrderModel>();
        private ObservableCollection<OrderStatusModel> orderStatusModels = new ObservableCollection<OrderStatusModel>();
        private ObservableCollection<PaymentModel> paymentModels = new ObservableCollection<PaymentModel>();
        private ObservableCollection<PositionModel> positionModels = new ObservableCollection<PositionModel>();
        private ObservableCollection<SubcategoryModel> subcategoryModels = new ObservableCollection<SubcategoryModel>();
        private ObservableCollection<TableModel> tableModels = new ObservableCollection<TableModel>();
        private ObservableCollection<WorkShiftEmployeeModel> workShiftEmployeeModels = new ObservableCollection<WorkShiftEmployeeModel>();
        private ObservableCollection<WorkShiftModel> workShiftModels = new ObservableCollection<WorkShiftModel>();
        public IEnumerable<EmployeeModel> EmployeeModels => employeeModels;
        public IEnumerable<CategoryModel> CategoryModels => categoryModels;
        public IEnumerable<DeliveryOrderModel> DeliveryOrderModels => deliveryOrderModels;
        public IEnumerable<DishModel> DishModels => dishModels;
        public IEnumerable<InternalOrderModel> InternalOrderModels => internalOrderModels;
        public IEnumerable<OrderDishModel> OrderDishModels => orderDishModels;
        public IEnumerable<OrderModel> OrderModels => orderModels;
        public IEnumerable<OrderStatusModel> OrderStatusModels => orderStatusModels;
        public IEnumerable<PaymentModel> PaymentModels => paymentModels;
        public IEnumerable<PositionModel> PositionModels => positionModels;
        public IEnumerable<SubcategoryModel> SubcategoryModels => subcategoryModels;
        public IEnumerable<TableModel> TableModels => tableModels;
        public IEnumerable<WorkShiftEmployeeModel> WorkShiftEmployeeModels => workShiftEmployeeModels;
        public IEnumerable<WorkShiftModel> WorkShiftModels => workShiftModels;
        public EmployeeModel CurrentEmployeeModel {  get; set; }
        public WorkShiftModel CurrentWorkShift { get; set; }
        public UnitOfWork UoW { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public OrderModel CurrentOrderModel { get; set; }
        private ICommand? _goToLogin;
        private ICommand? _goToOrders;

        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public VM_GeneralInfo(string pageIndex = "2")
        {
            PageId = pageIndex;
            Title = "Загальна інформація";
        }
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new LoginTM() { UoW = UoW, PageNumber = "1" });
                });
            }
        }
        public ICommand GoToOrders
        {
            get
            {
                return _goToOrders ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPage = PageId, PageNumber = "3" });
                });
            }
        }
    }
}
