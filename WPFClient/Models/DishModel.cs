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
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SubcategoryId { get; set; }
        public SubcategoryModel? Subcategory { get; set; }
        public ICollection<OrderDishModel> OrderDishes { get; set; } = new HashSet<OrderDishModel>();
    }
}
