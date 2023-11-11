using AngularAPI.Models;
using Microsoft.EntityFrameworkCore;
using MovieTicketBookingApp.Models;
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

        public DbSet<Seat> seats { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }

        public DbSet<Booking> Bookings { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().ToTable("users");

            modelbuilder.Entity<City>().ToTable("cities");

            modelbuilder.Entity<Movie>().ToTable("movies");



            modelbuilder.Entity<CinemaHall>()
            .HasOne(ch => ch.Movie)
            .WithMany()
            .HasForeignKey(ch => ch.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelbuilder);

        }
    }
}
