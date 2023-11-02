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
    public class CashierShiftModel
    {
        public int Id { get; set; }
        public int CashRegisterId { get; set; }
        public string CashRegistryDescription { get; set; }
        public int WorkShiftId { get; set; }
        public DateTime OpeningDateTime { get; set; }
        public DateTime? ClosingDateTime { get; set; }
        public decimal? DepositedCash { get; set; }
        public decimal? WithdrawnCash { get; set; }
    }
}
