using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
using PERUSTARS.AtEventManagement.Domain.Model;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;

namespace PERUSTARS.Shared.Infrastructure.Configuration
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<ArtEvent> Events { get; set; }
        public DbSet<Participant> EventAssistances { get; set; }

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
            
           // builder.Entity<Artist>().HasOne<Artist>(a => a.User)
                    //.WithOne(u => u.Artist)
                    //.HasForeignKey<Artist>(a => a.Id);

                    builder.Entity<Hobbyist>().ToTable("hobbyists");
                //.HasOne(u => u.User)
               // .WithOne(h => h.Hobbyst)
               // .HasForeignKey<Hobbyist>(h => h.Id);

            //builder.Entity<Hobbyist>().HasOne(h => h.Follower)
              //  .WithOne(f => f.Hobbyist)
              //  .HasForeignKey<Follower>(f => f.HobbyistId);

            //builder.Entity<Artist>().HasMany(a => a.Follower)
             //   .WithOne(f => f.Artist)
             //   .HasForeignKey(f => f.ArtistId);

            builder.Entity<Follower>().ToTable("followers");

            builder.Entity<ArtEvent>().ToTable("ArtEvents");
            builder.Entity<ArtEvent>().HasKey(a => a.Id);
            builder.Entity<ArtEvent>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtEvent>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.ArtEvents)
                .HasForeignKey(a => a.ArtistId);
            builder.Entity<ArtEvent>()
                .HasMany(a => a.Participants)
                .WithOne(p => p.ArtEvent)
                .HasForeignKey(p => p.ArtEventId);
            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Participant>().HasKey(p => p.Id);
            builder.Entity<Participant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Participant>()
                .HasOne(p => p.Hobyst)
                .WithMany(h => h.Participants)
                .HasForeignKey(p => p.HobystId);



            


        }
    }
}
