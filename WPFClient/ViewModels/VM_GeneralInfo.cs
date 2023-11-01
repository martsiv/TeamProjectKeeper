using data_access.Repositories;
using PropertyChanged;
using System;
using System.Linq;
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
        //private ObservableCollection<EmployeeModel> employeeModels = new ObservableCollection<EmployeeModel>();
        //private ObservableCollection<CategoryModel> categoryModels = new ObservableCollection<CategoryModel>();
        //private ObservableCollection<DeliveryOrderModel> deliveryOrderModels = new ObservableCollection<DeliveryOrderModel>();
        //private ObservableCollection<DishModel> dishModels = new ObservableCollection<DishModel>();
        //private ObservableCollection<InternalOrderModel> internalOrderModels = new ObservableCollection<InternalOrderModel>();
        //private ObservableCollection<OrderDishModel> orderDishModels = new ObservableCollection<OrderDishModel>();
        //private ObservableCollection<OrderModel> orderModels = new ObservableCollection<OrderModel>();
        //private ObservableCollection<OrderStatusModel> orderStatusModels = new ObservableCollection<OrderStatusModel>();
        //private ObservableCollection<PaymentModel> paymentModels = new ObservableCollection<PaymentModel>();
        //private ObservableCollection<PositionModel> positionModels = new ObservableCollection<PositionModel>();
        //private ObservableCollection<SubcategoryModel> subcategoryModels = new ObservableCollection<SubcategoryModel>();
        //private ObservableCollection<TableModel> tableModels = new ObservableCollection<TableModel>();
        //private ObservableCollection<WorkShiftEmployeeModel> workShiftEmployeeModels = new ObservableCollection<WorkShiftEmployeeModel>();
        //private ObservableCollection<WorkShiftModel> workShiftModels = new ObservableCollection<WorkShiftModel>();
        //public IEnumerable<EmployeeModel> EmployeeModels => employeeModels;
        //public IEnumerable<CategoryModel> CategoryModels => categoryModels;
        //public IEnumerable<DeliveryOrderModel> DeliveryOrderModels => deliveryOrderModels;
        //public IEnumerable<DishModel> DishModels => dishModels;
        //public IEnumerable<InternalOrderModel> InternalOrderModels => internalOrderModels;
        //public IEnumerable<OrderDishModel> OrderDishModels => orderDishModels;
        //public IEnumerable<OrderModel> OrderModels => orderModels;
        //public IEnumerable<OrderStatusModel> OrderStatusModels => orderStatusModels;
        //public IEnumerable<PaymentModel> PaymentModels => paymentModels;
        //public IEnumerable<PositionModel> PositionModels => positionModels;
        //public IEnumerable<SubcategoryModel> SubcategoryModels => subcategoryModels;
        //public IEnumerable<TableModel> TableModels => tableModels;
        //public IEnumerable<WorkShiftEmployeeModel> WorkShiftEmployeeModels => workShiftEmployeeModels;
        //public IEnumerable<WorkShiftModel> WorkShiftModels => workShiftModels;
        public event EventHandler<EventArgs<BaseTransferModel>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }
        public BaseTransferModel TransferModel { get; set; }
        public UnitOfWork UoW { get; set; }
        [DependsOn(nameof(TransferModel))]
        public EmployeeModel CurrentEmployeeModel => TransferModel.CurrentEmployee;
        public WorkShiftModel CurrentWorkShift { get; set; }
        public OrderModel CurrentOrderModel { get; set; }

        public VM_GeneralInfo(string pageIndex = "2")
        {
            PageId = pageIndex;
            Title = "Загальна інформація";
        }
        #region Navigation
        private ICommand? _goToLogin;
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, new BaseTransferModel() { UoW = UoW, PageNumber = UserControlsEnum.Login.ToString() });
                });
            }
        }
        private ICommand? _goToOrders;
        public ICommand GoToOrders
        {
            get
            {
                return _goToOrders ??= new RelayCommand(x =>
                {
                    TransferModel.PreviousPages.Add(PageId);
                    ViewChanged?.Raise(this, new BaseTransferModel() { CurrentEmployee = CurrentEmployeeModel, UoW = UoW, CurrentOrder = CurrentOrderModel, PreviousPages = TransferModel.PreviousPages, PageNumber = UserControlsEnum.Orders.ToString() });
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
        #endregion
    }
}
