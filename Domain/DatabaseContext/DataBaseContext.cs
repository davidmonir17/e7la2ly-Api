using Domain.Configuration;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DatabaseContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpShiftConfigration());
            modelBuilder.ApplyConfiguration(new EmpWorkingConfigration());
        }

        public DbSet<Location>? Locations { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Branch>? Branches { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Shift>? Shifts { get; set; }
        public DbSet<EmpShift>? EmpShifts { get; set; }
        public DbSet<EmpWorking>? EmpWorkings { get; set; }
        public DbSet<Client>? Clients { get; set; }

    }
}
