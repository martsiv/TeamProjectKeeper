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
    public class OrderPositionConfigs : IEntityTypeConfiguration<OrderPosition>
    {
        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
			builder.HasKey(x => new { x.OrderId, x.PositionId });
			builder.HasOne(x => x.Position).WithMany(x => x.OrderPositions).HasForeignKey(x => x.PositionId).IsRequired(true);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderPositions).HasForeignKey(x => x.OrderId).IsRequired(true);
        }
    }
}
