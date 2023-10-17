using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    //For example
    //public class MyClassConfiguration : IEntityTypeConfiguration<MyClass>
    //{
    //    public void Configure(EntityTypeBuilder<MyClass> builder)
    //    {
    //        builder.Property(x => x.SomeField).HasColumnName("Some data");
    //        builder.Property(x => x.Status).IsRequired(true);

    //        // Configure Relationships
    //        builder.HasOne(x => x.User)
    //                .WithMany(x => x.Bookings)
    //                .HasForeignKey(x => x.UserId)
    //                .IsRequired(false);
    //    }
    //}
}
