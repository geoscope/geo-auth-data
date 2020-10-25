using System;
using geo_auth_data.models.domain;
using Microsoft.EntityFrameworkCore;

namespace geo_auth_data
{
    public class AuthDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("AuthConnectionString");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Missing AuthConnectionString environment variable");

            options.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.OwnerId, u.UserName })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(b => b.OwnerId);
                
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInRole> UsersInRoles { get; set; }

    }
}