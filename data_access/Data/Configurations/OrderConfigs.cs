using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class OrderConfigs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.WorkShiftEmployee).WithMany(x => x.Orders).HasForeignKey(x => x.WorkShiftEmployeeId).IsRequired(true);
            builder.HasOne(x => x.OrderStatus).WithMany(x => x.Orders).HasForeignKey(x => x.OrderStatusId).IsRequired(true);
            builder.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentId).IsRequired(false);
            builder.Property(x => x.CutleryNumber).IsRequired(false);
            builder.Property(x => x.CutleryNumber).HasColumnName("Number of cutlery");
            builder.Property(x => x.TotalPrice).HasColumnName("Total amount of money");
            builder.Property(x => x.TotalPrice).HasColumnType("money");
            builder.Property(x => x.Closed).IsRequired(false);

        }
    }
}
