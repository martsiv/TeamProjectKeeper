using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PinCode { get; set; }
        public virtual ICollection<WorkShiftEmployee> WorkShiftEmployees { get; set; } = new HashSet<WorkShiftEmployee>();
    }
}
