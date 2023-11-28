using _19070006008_midterm.Models;
using Microsoft.EntityFrameworkCore;

namespace _19070006008_midterm.Data.EntityFramework
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=19070006008_midtermDB;Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            
            modelBuilder.Entity<House>()
                .HasKey(h => h.Id);

            
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.Id);
        }

        
        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
