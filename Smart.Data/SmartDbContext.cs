using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Smart.Core.Domain;
using Smart.Data.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Smart.Data.Extensions;

namespace Smart.Data
{
    public class SmartDbContext : DbContext
    {
        public SmartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<AttachFile> AttachFiles { set; get; }
        public DbSet<Info> Infos { set; get; }
        public DbSet<Setting> Settings { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<Logging> Loggings { set; get; }
        public DbSet<Document> Documents { set; get; }
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<Lesson> Lessons { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Subject> Subjects { set; get; }
        public DbSet<BlogCategory> BlogCategories { set; get; }
        public DbSet<CustomerRole> CustomerRoles { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Employer> Employers { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Config
            builder.Entity<Product>().ToTable("Products").HasKey(x => x.Id);
            #endregion 

            builder.AddConfiguration(new ProductConfiguration());

            base.OnModelCreating(builder);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SmartDbContext>
    {
        public SmartDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<SmartDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new SmartDbContext(builder.Options);
        }
    }
}
