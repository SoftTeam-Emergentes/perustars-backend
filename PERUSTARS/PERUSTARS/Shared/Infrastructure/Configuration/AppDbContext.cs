using Microsoft.EntityFrameworkCore;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using Artist = PERUSTARS.ProfileManagement.Domain.Model.Entities.Artist;
using Follower = PERUSTARS.ProfileManagement.Domain.Model.Entities.Follower;
using Hobbyist = PERUSTARS.ProfileManagement.Domain.Model.Entities.Hobbyist;

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

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            // ...Poner más atributos ...


            builder.Entity<Artist>().ToTable("artists");
            
            builder.Entity<Artist>()
                    .HasOne(a => a.User)
                    .WithOne(a=>a.Artist)
                    .HasForeignKey<Artist>(a => a.ArtistId).IsRequired();

            builder.Entity<Hobbyist>().ToTable("hobbyists");
                    
            builder.Entity<Hobbyist>()
                    .HasOne(u => u.User)
                    .WithOne(u => u.Hobbyist)
                    .HasForeignKey<Hobbyist>(u => u.HobbyistId).IsRequired();

            builder.Entity<Hobbyist>()
                    .HasMany(h => h.Followers)
                    .WithOne(h => h.Hobbyist)
                    .HasForeignKey(h => h.HobbyistId);

            builder.Entity<Artist>()
                    .HasMany(a => a.Followers)
                    .WithOne(a => a.Artist)
                    .HasForeignKey(a => a.ArtistId);

            builder.Entity<Follower>().ToTable("followers");

            builder.Entity<Event>().ToTable("events");
            builder.Entity<Event>().HasKey(e => e.EventId);
            builder.Entity<Event>().Property(e=>e.EventId).IsRequired().ValueGeneratedOnAdd();


        }
    }
}
