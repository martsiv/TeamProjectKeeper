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
    public class SubcategoryConfigs : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder) 
        { 
            builder.HasOne(x => x.Category).WithMany(x => x.Subcategories).HasForeignKey(x => x.CategoryId).IsRequired(true);
            builder.HasMany(x => x.Positions).WithOne(x => x.Subcategory).HasForeignKey(x => x.SubcategoryId).IsRequired(true);
        }
    }
}
