using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class WorkShiftEmployee : IEntity
    {
        //складений первиний ключ
        public int WorkShiftId { get; set; }
        public WorkShift? WorkShift { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set;}
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
