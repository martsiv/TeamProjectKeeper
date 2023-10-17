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
            builder.HasOne(x => x.WorkShiftEmployee).WithMany(x => x.Orders).HasForeignKey(x => x.WorkShiftEmployeeId);
            builder.HasOne(x => x.Tabel).WithMany(x => x.Orders).HasForeignKey(x => x.TableId).IsRequired(false);
            builder.HasOne(x => x.OrderStatus).WithMany(x => x.Orders).HasForeignKey(x => x.OrderStatusId);
            builder.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentId).IsRequired(false);

        }
    }
}
