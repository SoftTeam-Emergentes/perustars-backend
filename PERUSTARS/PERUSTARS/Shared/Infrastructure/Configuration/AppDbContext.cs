using Microsoft.EntityFrameworkCore;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;

using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

using PERUSTARS.Shared.Extensions;
using System;

using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Reflection.Emit;

namespace PERUSTARS.Shared.Infrastructure.Configuration


{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParticipantEventRegistration> ParticipantEventRegistrations { get; set; }
        public DbSet<ArtistArtworkRecommendation> ArtistRecommendations { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<ArtEvent> ArtEvents { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
     
            builder.Entity<Artist>().ToTable("Artists");
            builder.Entity<Artist>()
            .HasBaseType<User>();
            //builder.Entity<Artist>().Property(a=>a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Artist>()
                    .HasOne(a => a.User)
                    .WithOne(u=>u.artist)
                    .HasForeignKey<Artist>(a => a.ArtistId);
            builder.Entity<Artist>().Property(a => a.Age);
            //builder.Entity<Artist>().Property(a => a.Followers);
            builder.Entity<Artist>().Property(a => a.Description);
            builder.Entity<Artist>().Property(a => a.Genre);
            builder.Entity<Artist>().Property(a => a.Phrase);
            builder.Entity<Artist>().Property(a => a.BrandName).HasMaxLength(50);
            builder.Entity<Artist>().Property(a => a.ContactEmail).HasMaxLength(80);
            builder.Entity<Artist>().Property(a => a.ContactNumber);
            //builder.Entity<Artist>().Property(a => a.SocialMediaLink).HasMaxLength(255);
            builder.Entity<Artist>().Property(a => a.Collected).HasDefaultValue(false);
            

            builder.Entity<Hobbyist>().ToTable("Hobbyists");
            //builder.Entity<Hobbyist>().Property(a => a.HobbyistId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hobbyist>().Property(a => a.Age);
            //builder.Entity<Hobbyist>().HasCheckConstraint("Age <= 120");
            //builder.Entity<Hobbyist>().Property(a => a.User);
            //builder.Entity<Hobbyist>().Property(a => a.Followers);
            builder.Entity<Hobbyist>().Property(a => a.Collected).HasDefaultValue(false);

                  //builder.Entity<Artist>()
                  //        .HasMany(a => a.Followers)
                  //        .WithOne(a => a.Artist)
                  //        .HasForeignKey(a => a.ArtistId);

            builder.Entity<Follower>().ToTable("Followers");
            builder.Entity<Follower>().HasKey(f => f.Id);
            builder.Entity<Follower>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Follower>().Property(f => f.Hobbyist);
            //builder.Entity<Follower>().Property(f => f.Artist);
            builder.Entity<Follower>().Property(f => f.ArtistId);
            builder.Entity<Follower>().Property(f => f.HobbyistId);
            builder.Entity<Follower>().Property(a => a.RegistrationDate);
            builder.Entity<Follower>().Property(a => a.Collected).HasDefaultValue(false);
            

            builder.Entity<ArtEvent>().ToTable("ArtEvents");
            builder.Entity<ArtEvent>().HasKey(a => a.Id);
            builder.Entity<ArtEvent>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtEvent>().Property(a => a.Title).IsRequired();
            builder.Entity<ArtEvent>().Property(a => a.Description).IsRequired();
            builder.Entity<ArtEvent>().Property(a => a.StartDateTime).IsRequired();
            builder.Entity<ArtEvent>().OwnsOne(ae => ae.Location, location =>
            {
                location.Property(l => l.Country).IsRequired();
                location.Property(l => l.City).IsRequired();
                location.Property(l => l.Latitude).IsRequired();
                location.Property(l => l.Longitude).IsRequired();
            });
            builder.Entity<ArtEvent>().Property(a => a.IsOnline).IsRequired();
            builder.Entity<ArtEvent>().Property(a => a.CurrentStatus).HasConversion(v => v.ToString(), v => (ArtEventStatus)Enum.Parse(typeof(ArtEventStatus), v));
            builder.Entity<ArtEvent>().Property(a=>a.Collected).HasDefaultValue(false).IsRequired();
            
            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Participant>().HasKey(p => p.Id);
            builder.Entity<Participant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Participant>().Property(p => p.UserName).IsRequired();
            builder.Entity<Participant>().Property(p=>p.RegisterDateTime).IsRequired();
            builder.Entity<Participant>().Property(p=>p.CheckInDateTime).IsRequired();
            builder.Entity<Participant>().Property(p=>p.ParticipantRegistrationDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<Participant>().Property(p => p.Collected).HasDefaultValue(false).IsRequired();
            builder.Entity<Participant>()//.Property(p => p.HobbyistId);
                .HasOne(p => p.Hobyst)
                .WithMany(h => h.Participants)
                .HasForeignKey(p => p.HobbyistId);

            builder.Entity<ArtEvent>().Property(ae => ae.ArtistId);
                .HasOne(ae => ae.Artist)
                .WithMany(ar => ar.ArtEvents)
                .HasForeignKey(ae => ae.ArtistId);
            builder.Entity<ArtEvent>()
                .HasMany(ae => ae.Participants)
                .WithOne(p => p.ArtEvent)
                .HasForeignKey(p => p.ArtEventId);
            //builder.Entity<Event>().ToTable("events");
            //builder.Entity<Event>().HasKey(e => e.EventId);
            //builder.Entity<Event>().Property(e=>e.EventId).IsRequired().ValueGeneratedOnAdd();
            
            


            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
