using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    public class ApplicationContext : DbContext
    {
        //public DbSet<MyClass> variable { get; set; } = null!; //For example
        //Connection ---------------------------------------
        public string connectionString;

        public ApplicationContext()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinema;Integrated Security=True;Connect Timeout=2;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        //Connection ---------------------------------------

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            DbInitializer.SeedData(modelBuilder);
        }
    }
}
