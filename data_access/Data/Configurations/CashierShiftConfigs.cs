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
    public class CashierShiftConfigs : IEntityTypeConfiguration<CashierShift>
    {
        public void Configure(EntityTypeBuilder<CashierShift> builder)
        {
            builder.HasOne(x => x.CashRegister).WithMany(x => x.CashierShifts).HasForeignKey(x => x.CashRegisterId).IsRequired(true);
            builder.HasOne(x => x.WorkShift).WithMany(x => x.CashierShifts).HasForeignKey(x => x.WorkShiftId).IsRequired(true);
            builder.Property(x => x.ClosingDateTime).IsRequired(false);
            builder.Property(x => x.DepositedCash).IsRequired(false);
            builder.Property(x => x.WithdrawnCash).IsRequired(false);
        }
    }
}
