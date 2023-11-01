using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class WorkShift : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<WorkShiftEmployee> WorkShiftEmployees { get; set; } = new HashSet<WorkShiftEmployee>();
        public ICollection<CashierShift> CashierShifts { get; set; } = new HashSet<CashierShift>();
    }
}
