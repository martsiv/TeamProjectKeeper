﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int WorkShiftID { get; set; }
        public int EmployeeID { get; set; }
        public WorkShiftEmployee? WorkShiftEmployee { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<OrderDish> OrderDishes { get; set; } = new HashSet<OrderDish>();
        public int? CutleryNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }
    }
}
