using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class CashRegister : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<CashierShift> CashierShifts { get; set; } = new HashSet<CashierShift>();
    }
}
