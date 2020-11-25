using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.WEB.Entities;


namespace WarehouseManagementSystem.WEB.Data
{

    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Inventory>()
                .ToTable("Inventories")
                .HasOne(x => x.Customer)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.CustomerId);


        }
    }
}

