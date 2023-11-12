using AngularAPI.Migrations;
using AngularAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AngularAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Theater> Theater { get; set; }

        public DbSet<Screens> Screens { get; set; }

        public DbSet<Seating> Seating { get; set; }

        public DbSet<Booking> Bookings { get; set; }




        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().ToTable("users");
            modelbuilder.Entity<City>().ToTable("cities");
            modelbuilder.Entity<Movie>().ToTable("movies");
            modelbuilder.Entity<Theater>().ToTable("Theaters");
            modelbuilder.Entity<Screens>().ToTable("Screens");
            modelbuilder.Entity<Seating>().ToTable("Seatings");
            modelbuilder.Entity<Booking>().ToTable("BookingInfo");

        }


    }
}