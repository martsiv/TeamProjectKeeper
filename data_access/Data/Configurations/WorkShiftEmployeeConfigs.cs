﻿using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class WorkShiftEmployeeConfigs : IEntityTypeConfiguration<WorkShiftEmployee>
    {
        public void Configure(EntityTypeBuilder<WorkShiftEmployee> builder)
        {
            builder.HasOne(x => x.Employee).WithMany(x => x.WorkShiftEmployees).HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.WorkShift).WithMany(x => x.WorkShiftEmployees).HasForeignKey(x => x.WorkShiftId);
        }
    }
}
