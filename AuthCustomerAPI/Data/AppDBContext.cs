using AuthCustomerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthCustomerAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.LastName, c.FirstName });

            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.FirstName });

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.TotalAmount);

            //because warning of HasPrecision
            modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.CreatedDate)
                .HasDefaultValueSql("GETDATE()");


            var passwordHasher = new PasswordHasher<User>();
            var admin = new User
            {
                Id = 1,
                UserName = "admin",
                Role = Role.Admin
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123!");
            var user = new User
            {
                Id = 2,
                UserName = "user",
                Role = Role.User
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "User321!");
            modelBuilder.Entity<User>().HasData(admin,user);

            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "User",
                    Phone = "555-123456",
                    Email = "test@example.com",
                    UserName = "user"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "Customer",
                    Phone = "555-654321",
                    Email = "admin@example.com",
                    UserName = "admin"
                });
        }
    }
}
