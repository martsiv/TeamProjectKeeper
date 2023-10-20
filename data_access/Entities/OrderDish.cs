using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class OrderDish : IEntity
    {
        public int DishId { get; set; }
        public Dish? Dish { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
        public string? Comment { get; set; }
    }
}
