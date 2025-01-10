using CarParking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarParking.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();   // создаем базу данных при первом обращении
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parking>()
                .Navigation(p => p.Zone).AutoInclude();
            modelBuilder.Entity<Parking>()
                .Navigation(p => p.Vehicle).AutoInclude();
            modelBuilder.Entity<Parking>()
                .Navigation(p => p.User).AutoInclude();


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Vasea",
                    Email = "test@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456")
                },
                new User
                {
                    Id = 2,
                    Name = "Drenton",
                    Email = "drenton@drentron.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("12345678")
                }
            );

            modelBuilder.Entity<Zone>().HasData(
                new Zone
                {
                    Id = 1,
                    Name = "Green Zone",
                    PricePerHour = 100
                },
                new Zone
                {
                    Id=2,
                    Name = "Yellow Zone",
                    PricePerHour = 200
                },
                new Zone
                {
                    Id = 3,
                    Name = "Red Zone",
                    PricePerHour = 300
                }
            );

        }

    }
}
