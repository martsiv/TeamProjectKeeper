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
    public class PaymentModel
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
