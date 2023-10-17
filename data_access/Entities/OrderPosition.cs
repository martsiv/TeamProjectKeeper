using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class OrderPosition : IEntity
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
