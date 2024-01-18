using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Database
{
    public class StoreDbContext : DbContext
    {
        public string connectionString;

        public StoreDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        static StoreDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Host=localhost;Port=5432;Database=FilmStore;Username=postgres;Password=3698741");
        }
    }
}
