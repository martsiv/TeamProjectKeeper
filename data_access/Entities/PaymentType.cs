using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class PaymentType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
