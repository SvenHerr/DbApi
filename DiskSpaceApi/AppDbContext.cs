using DiskSpaceApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DiskSpaceApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<DiskSpace> DiskSpaces { get; set; }

        // Inject IConfiguration to access appsettings.json
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiskSpace>().HasKey(d => d.Id); // Define 'Id' as the primary key
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Retrieve connection string from appsettings.json
            var connectionString = _configuration.GetConnectionString("WebApiDatabase");

            if(connectionString == null)
            {
                throw new NullReferenceException("Connection string is null");
            }

            // Use the retrieved connection string
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
