using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public class EmpShiftConfigration : IEntityTypeConfiguration<EmpShift>
    {
        public void Configure(EntityTypeBuilder<EmpShift> builder)
        {
            builder.HasKey(o => new { o.empid, o.shiftDate });
            //builder.HasOne(x => x.shift).WithMany(x => x.EmpShifts).HasForeignKey(x => x.shiftId).OnDelete(DeleteBehavior.SetNull);
           // builder.HasOne(x => x.employee).WithMany(x => x.EmpShifts).HasForeignKey(x => x.empid).OnDelete(DeleteBehavior.SetNull);


        }
    }
}
