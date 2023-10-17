using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    public class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tabel>().HasData(new Tabel[]
            {
                new Tabel() { Id = 1},
                new Tabel() { Id = 2},
                new Tabel() { Id = 3},
                new Tabel() { Id = 4},
                new Tabel() { Id = 5},
                new Tabel() { Id = 6},
                new Tabel() { Id = 7},
                new Tabel() { Id = 8},
                new Tabel() { Id = 9},
                new Tabel() { Id = 10},
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category() { Id = 1, Name = "Kitchen" },
                new Category() { Id = 2, Name = "Bar" },
            });
            // І так далі.....
        }
    }
}
