using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Smart.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Smart.Data
{
    public class SmartDbContext : DbContext
    {
        public SmartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Info> Infos { set; get; }
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
