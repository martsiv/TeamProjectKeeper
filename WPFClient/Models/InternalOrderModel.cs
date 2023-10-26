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
    public class InternalOrderModel
    {
        public int TableId { get; set; }
        public Tabel? Tabel { get; set; }
    }
}
