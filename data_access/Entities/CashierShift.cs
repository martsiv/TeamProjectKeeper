using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class CashierShift : IEntity
    {
        public int Id { get; set; }
        public int CashRegisterId { get; set; }
        public CashRegister? CashRegister { get; set; }
        public int WorkShiftId { get; set; }
        public WorkShift? WorkShift { get; set; }
        public DateTime OpeningDateTime { get; set; }
        public DateTime? ClosingDateTime { get; set; }
        public decimal? DepositedCash { get; set; }
        public decimal? WithdrawnCash { get; set; }
    }
}
