using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace DAL.DbContexts
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> EmployeeDboptions)
        :base(EmployeeDboptions)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity<EmployeeInfo>().ToTable("Employees_Tbl");
            base.OnModelCreating(mb);
        }
    }
}
