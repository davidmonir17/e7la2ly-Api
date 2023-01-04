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
    public class EmpWorkingConfigration : IEntityTypeConfiguration<EmpWorking>
    {
        public void Configure(EntityTypeBuilder<EmpWorking> builder)
        {
            builder.HasKey(o => new { o.empid, o.from, o.To });
            builder.HasOne(x => x.client).WithMany(x => x.empWorkings).HasForeignKey(x => x.clientId);
        }
    }
}
