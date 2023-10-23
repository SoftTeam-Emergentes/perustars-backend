using Microsoft.EntityFrameworkCore;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.Shared.Extensions;
using System;

namespace PERUSTARS.Shared.Infrastructure.Configuration
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Artist> Artists { get; set; }
        //public DbSet<Hobbyist> Hobbyists { get; set; }
        //public DbSet<Follower> Followers { get; set; }
        //public DbSet<Event> Events { get; set; }
        //public DbSet<EventAssistance> EventAssistances { get; set; }
        public DbSet<ParticipantEventRegistration> ParticipantEventRegistrations { get; set; }
        public DbSet<ArtistArtworkRecommendation> ArtistRecommendations { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            // ...Poner más atributos ...


            // builder.Entity<Artist>().ToTable("artists");

            //// builder.Entity<Artist>().HasOne<Artist>(a => a.User)
            //         //.WithOne(u => u.Artist)
            //         //.HasForeignKey<Artist>(a => a.Id);

            //         builder.Entity<Hobbyist>().ToTable("hobbyists");
            //     //.HasOne(u => u.User)
            //    // .WithOne(h => h.Hobbyst)
            //    // .HasForeignKey<Hobbyist>(h => h.Id);

            // //builder.Entity<Hobbyist>().HasOne(h => h.Follower)
            //   //  .WithOne(f => f.Hobbyist)
            //   //  .HasForeignKey<Follower>(f => f.HobbyistId);

            // //builder.Entity<Artist>().HasMany(a => a.Follower)
            //  //   .WithOne(f => f.Artist)
            //  //   .HasForeignKey(f => f.ArtistId);

            // builder.Entity<Follower>().ToTable("followers");

            //builder.Entity<Event>().ToTable("events");
            //builder.Entity<Event>().HasKey(e => e.EventId);
            //builder.Entity<Event>().Property(e=>e.EventId).IsRequired().ValueGeneratedOnAdd();
            #region ParticipantEventRegistrations

            builder.Entity<ParticipantEventRegistration>().ToTable("ParticipantEventRegistrations");
            builder.Entity<ParticipantEventRegistration>().HasKey(p => p.Id);
            builder.Entity<ParticipantEventRegistration>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.EventTitle).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.ArtistId).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.HobyistId).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.RegistrationDate).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.Collected).HasDefaultValue(false).IsRequired();

            #endregion

            #region ArtistRecommendations

            builder.Entity<ArtistArtworkRecommendation>().ToTable("ArtistRecommendations");
            builder.Entity<ArtistArtworkRecommendation>().HasKey(ar => ar.Id);
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.ArtistId).IsRequired();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.HobyistId).IsRequired();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.RecommendationDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.Collected).HasDefaultValue(false).IsRequired();

            #endregion


            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
