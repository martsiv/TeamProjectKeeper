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
    public class WorkShiftModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<WorkShiftEmployeeModel> WorkShiftEmployees { get; set; } = new HashSet<WorkShiftEmployeeModel>();
        public ICollection<CashierShiftModel> CashierShifts { get; set; } = new HashSet<CashierShiftModel>();
    }
}
