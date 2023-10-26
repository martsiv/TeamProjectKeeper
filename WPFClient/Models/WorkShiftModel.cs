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
        public ICollection<WorkShiftEmployee> WorkShiftEmployees { get; set; } = new HashSet<WorkShiftEmployee>();
    }
}
