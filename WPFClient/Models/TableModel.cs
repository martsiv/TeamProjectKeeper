using data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFClient.TransferModel;

namespace WPFClient.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TableModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ICollection<InternalOrderModel> InternalOrders { get; set; } = new HashSet<InternalOrderModel>();
        public int HallId { get; set; }
        public HallModel? Hall { get; set; }
    }
}
