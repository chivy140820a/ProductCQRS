using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductSQRS.API.Configuration;
using ProductSQRS.API.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSQRS.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new ProductManagerConfiguration());
            base.OnModelCreating(builder);
        }
        public DbSet<ProductManager> ProductManagers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
    }
}
