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
        public int WorkShiftEmployeeId { get; set; }
        public WorkShiftEmployee WorkShiftEmployee { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<OrderPosition> OrderPositions { get; set; } = new HashSet<OrderPosition>();
        public int? CutleryNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
