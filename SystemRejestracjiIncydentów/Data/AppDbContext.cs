using Microsoft.EntityFrameworkCore;
using SystemRejestracjiIncydentów.Entities;

namespace SystemRejestracjiIncydentów.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Location)
                .WithMany()
                .HasForeignKey(i => i.LocationId);

            modelBuilder.Entity<Incident>()
                .Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Incident>()
                .Property(x => x.Priority)
                .HasConversion<string>();

            modelBuilder.Entity<Location>()
                .Property(x => x.Status)
                .HasConversion<string>();
        }
    }

}
