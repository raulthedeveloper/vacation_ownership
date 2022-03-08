using Microsoft.EntityFrameworkCore;
using Playground2.Models;

namespace PlaygroundConsole1.Models
{
    public class BusinessContext:DbContext
    {
      public  BusinessContext() 
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Resort> Resort { get; set; }
        public DbSet<Unit> Unit { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=VacationOwnership;Trusted_Connection=True;");
        }


       

    }


      
    

}
