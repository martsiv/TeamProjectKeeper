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
    public class WorkShiftEmployeeModel
    {
        public int WorkShiftId { get; set; }
        public DateTime WorkShiftDate { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeModel? EmployeeModel { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; } = new HashSet<OrderModel>();
    }
}
