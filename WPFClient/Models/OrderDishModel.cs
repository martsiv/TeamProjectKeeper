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
    public class OrderDishModel
    {
        public int DishId { get; set; }
        public DishModel? Dish { get; set; }
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public int Quantity { get; set; }
        public string? Comment { get; set; }
    }
}
