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
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubcategoryModel> Subcategories { get; set; } = new HashSet<SubcategoryModel>();
    }
}
