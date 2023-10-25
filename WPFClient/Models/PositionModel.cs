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
    public class PositionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
