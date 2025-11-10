using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    public class MainDBcontext
    {
        public class MainDatabaseContext : DbContext
        {
            public DbSet<User> User { get; set; }

            public DbSet<Employee> Employee { get; set; }

            public DbSet<PayrollManagement> PayrollManagement { get; set; }
            public DbSet<AttendanceManagement> AttendanceManagement { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlite(@"Data Source=C:\Users\hp\Downloads\HR-Management-System-master\HR-Management-System-master\HR Management System\MainDB.db");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

               
                modelBuilder.Entity<AttendanceManagement>().HasNoKey();
               // modelBuilder.Entity<PayrollManagement>().HasNoKey();
            }
        }
    }
}
