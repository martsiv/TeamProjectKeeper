﻿using data_access.Data.Configurations;
using data_access.Entities;
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
        public string connectionString;
        public ApplicationContext()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KeeperDB;Integrated Security=True;Connect Timeout=2;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeliveryOrderConfigs());
            modelBuilder.ApplyConfiguration(new InternalOrderConfigs());
            modelBuilder.ApplyConfiguration(new OrderConfigs());
            modelBuilder.ApplyConfiguration(new SubcategoryConfigs());
            modelBuilder.ApplyConfiguration(new OrderPositionConfigs());
            modelBuilder.ApplyConfiguration(new WorkShiftEmployeeConfigs());
            modelBuilder.Entity<Employee>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Position>().Property(x => x.Price).HasColumnType("money");
            DbInitializer.SeedData(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrdersPositions { get; set; }
        public DbSet<OrderStatus> OrdersStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Tabel> Tabels { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<WorkShiftEmployee> WorkShiftsEmployees { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<InternalOrder> InternalOrders { get; set; }
    }
}
