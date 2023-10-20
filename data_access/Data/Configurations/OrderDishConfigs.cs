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
    public class OrderDishConfigs : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure(EntityTypeBuilder<OrderDish> builder)
        {
			builder.HasKey(x => new { x.OrderId, x.DishId });
			builder.HasOne(x => x.Dish).WithMany(x => x.OrderDishes).HasForeignKey(x => x.DishId).IsRequired(true);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDishes).HasForeignKey(x => x.OrderId).IsRequired(true);
            builder.Property(x => x.Comment).IsRequired(false);
        }
    }
}
