using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Contexts
{
    public class BasicECommerceAppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public BasicECommerceAppDbContext(DbContextOptions<BasicECommerceAppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configurations for entities
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly); // IEntityTypeConfiguration 'ı implement eden class'ları bulduk…

            base.OnModelCreating(builder);
        }
    }
}
