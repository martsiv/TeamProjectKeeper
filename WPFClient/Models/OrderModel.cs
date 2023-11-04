using data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.TransferModel;

namespace WPFClient.Models
{
    [AddINotifyPropertyChangedInterface]
    public class OrderModel
    {
        public int Id { get; set; }
        public int WorkShiftID { get; set; }
        public int EmployeeID { get; set; }
        public WorkShiftEmployeeModel? WorkShiftEmployee { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public int? PaymentId { get; set; }
        public PaymentModel? Payment { get; set; }
        public ICollection<OrderDishModel> OrderDishes { get; set; } = new HashSet<OrderDishModel>();
        public int? CutleryNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }
    }
}
