using Microsoft.EntityFrameworkCore;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using PERUSTARS.Domain.Models;
using PERUSTARS.Extensions;

namespace PERUSTARS.Shared.Infrastructure.Configuration
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventAssistance> EventAssistances { get; set; }
        public DbSet<ConductReport> ConductReports { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ConductReport>().ToTable("ConductReport");
            builder.Entity<ConductReport>().HasKey(c => c.id);
            builder.Entity<ConductReport>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ConductReport>().Property(c => c.Title).IsRequired();
            builder.Entity<ConductReport>().Property(c => c.Description).IsRequired();
            builder.Entity<ConductReport>().Property(c => c.DateTimeReport);
            builder.Entity<ConductReport>().Property(c => c.HobbystId).IsRequired();

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
