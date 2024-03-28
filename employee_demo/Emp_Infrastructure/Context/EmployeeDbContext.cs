using Emp_Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_Infrastructure.context
{
    public  class EmployeeDbContext: DbContext
    {
       

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
          : base(options)
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
       .HasOne(e => e.Department)
       .WithMany()
       .HasForeignKey(e => e.DepartmentID)
       .HasConstraintName("FK_Employees_Departments");

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorId)
                .HasConstraintName("FK_Employees_Supervisors");

            


            base.OnModelCreating(modelBuilder);
        }


    }
}
