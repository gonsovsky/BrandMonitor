using Microsoft.EntityFrameworkCore;
using BrandMonitor.API.Domain.Models;

namespace BrandMonitor.API.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<BrandTask> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<BrandTask>().ToTable("Tasks");
            builder.Entity<BrandTask>().HasKey(p => p.Id);
            builder.Entity<BrandTask>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<BrandTask>().Property(p => p.TimeStamp);

            builder.Entity<BrandTask>().Property(p => p.Status);
        }
    }
}