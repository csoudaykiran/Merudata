using AngularAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().ToTable("users");
        }
    }
}
