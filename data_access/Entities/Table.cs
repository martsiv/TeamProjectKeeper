using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Table : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ICollection<InternalOrder> InternalOrders { get; set; } = new HashSet<InternalOrder>();
        public int HallId { get; set; }
        public Hall? Hall { get; set; }
    }
}
