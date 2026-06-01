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
        public DbSet<Item> Items { get; set; }
    }
}