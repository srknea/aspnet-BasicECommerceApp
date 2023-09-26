using BasicECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Contexts
{
    public class BasicECommerceAppDbContext : DbContext
    {
        public BasicECommerceAppDbContext(DbContextOptions<BasicECommerceAppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
    }
}
