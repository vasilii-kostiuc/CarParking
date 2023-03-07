using CarParking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
