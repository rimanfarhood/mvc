using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Data
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId
            });
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c =>c.ClientId);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 7, Name = "micro", Price = 40, SerialNumberId = 10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150", ItemId = 7 }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothes" },
                new Category { Id = 2, Name = "Electronics" }
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}