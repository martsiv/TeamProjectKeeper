using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_access.Entities;

namespace data_access.Data.Configurations
{
    public class ServiceConfigs : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder) 
        { 
            builder.HasOne(x => x.Category).WithMany(x => x.Services).HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.Positions).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId);
        }
    }
}
