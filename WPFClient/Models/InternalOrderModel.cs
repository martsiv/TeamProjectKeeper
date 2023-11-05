using data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Models
{
    [AddINotifyPropertyChangedInterface]
    public class InternalOrderModel : OrderModel
    {
        public int TableId { get; set; }
        public TableModel? Tabel { get; set; }
    }
}
