using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Position : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ServiceId { get; set; }
        public virtual Subcategory Service { get; set; }
        public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new HashSet<OrderPosition>();
    }
}
