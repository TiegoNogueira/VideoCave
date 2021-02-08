using Microsoft.EntityFrameworkCore;
using System.Linq;
using VC.Data.Mappings;
using VC.Domain.Models;

namespace VC.Data.Contexts
{
    public class VideoCaveContext : DbContext
    {
        public VideoCaveContext(DbContextOptions<VideoCaveContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new VideoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}