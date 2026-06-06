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
        public MvcContext(DbContextOptions<MvcContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id=7, Name="micro", Price=40, SerialNumberId=10}
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id=10, Name="MIC150", ItemId=7}
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Clothes"},
                new Category { Id=2, Name="Electronics"}
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers{ get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}