using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class InternalOrder : Order
    {
        public int TableId { get; set; }
        public Tabel? Tabel { get; set; }
    }
}
