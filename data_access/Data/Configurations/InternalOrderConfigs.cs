using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class InternalOrderConfigs : IEntityTypeConfiguration<InternalOrder>
    {
        public void Configure(EntityTypeBuilder<InternalOrder> builder)
        {
            builder.HasOne(x => x.Tabel).WithMany(x => x.InternalOrders).HasForeignKey(x => x.TableId).IsRequired(true);
        }
    }
}
