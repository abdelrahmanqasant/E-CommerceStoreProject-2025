using E_CommerceWebApi_Core.Entities;
using E_CommerceWebApi_Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public StoreContext(DbContextOptions options) : base(options)
        {
      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
