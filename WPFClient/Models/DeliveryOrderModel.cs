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
    public class DeliveryOrderModel : OrderModel
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
