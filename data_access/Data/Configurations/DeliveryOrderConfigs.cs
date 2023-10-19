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
    public class DeliveryOrderConfigs : IEntityTypeConfiguration<DeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            builder.Property(x => x.ClientName).HasColumnName("Client name");
            builder.Property(x => x.DeliveryTime).HasColumnName("Delivery time");
            builder.Property(x => x.PhoneNumber).HasColumnName("Phone number");
        }
    }
}
