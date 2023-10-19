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
        public int SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
        public ICollection<OrderPosition> OrderPositions { get; set; } = new HashSet<OrderPosition>();
    }
}
