﻿using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class WorkShiftEmployeeConfigs : IEntityTypeConfiguration<WorkShiftEmployee>
    {
        public void Configure(EntityTypeBuilder<WorkShiftEmployee> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.WorkShiftId });
            builder.HasOne(x => x.Employee).WithMany(x => x.WorkShiftEmployees).HasForeignKey(x => x.EmployeeId).IsRequired(true);
            builder.HasOne(x => x.WorkShift).WithMany(x => x.WorkShiftEmployees).HasForeignKey(x => x.WorkShiftId).IsRequired(true);
            builder.Property(x => x.TimeTo).IsRequired(false);
            builder.Property(x => x.TimeFrom).HasColumnName("Time from");
            builder.Property(x => x.TimeTo).HasColumnName("Time to");
		}
    }
}
