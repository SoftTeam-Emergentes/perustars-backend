using Microsoft.EntityFrameworkCore;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Extensions;
using System;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;

namespace PERUSTARS.Shared.Infrastructure.Configuration


{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.UserId);
            builder.Entity<User>().Property(u => u.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.FirstName);
            builder.Entity<User>().Property(u => u.LastName).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            #endregion
            
     
            
             builder.Entity<Artist>().ToTable("Artists");
            builder.Entity<Artist>().HasKey(a => a.ArtistId);
            builder.Entity<Artist>().Property(a => a.Age);
            //builder.Entity<Artist>().Property(a => a.FollowersArtist);
            builder.Entity<Artist>().Property(a => a.Description);
            builder.Entity<Artist>().Property(a => a.Genre);
            builder.Entity<Artist>().Property(a => a.Phrase);
            builder.Entity<Artist>().Property(a => a.BrandName).HasMaxLength(50);
            builder.Entity<Artist>().Property(a => a.ContactEmail).HasMaxLength(80);
            builder.Entity<Artist>().Property(a => a.ContactNumber);
            builder.Entity<Artist>().Property(a => a.SocialMediaLink).HasMaxLength(255);
            builder.Entity<Artist>().Property(a => a.Collected).HasDefaultValue(false);
            

            builder.Entity<Hobbyist>().ToTable("Hobbyists");
            builder.Entity<Hobbyist>().HasKey(a => a.HobbyistId);
            builder.Entity<Hobbyist>().Property(a => a.HobbyistId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hobbyist>().Property(a => a.Age);
            builder.Entity<Hobbyist>().Property(a => a.Collected);
            //builder.Entity<Hobbyist>().Property(a => a.FollowedArtists);
            builder.Entity<Hobbyist>().Property(a => a.Collected).HasDefaultValue(false);
            
            builder.Entity<Artist>()
                .HasOne(a=>a.User)
                .WithOne()
                .HasForeignKey<Artist>(a => a.UserId);
                    
            builder.Entity<Hobbyist>()
                    .HasOne(u => u.User)
                    .WithOne()
                    .HasForeignKey<Hobbyist>(u => u.UserId);

            /*builder.Entity<Follower>()
                    .HasOne(f =>f.Artist)
                    .WithMany(a => a.FollowersArtist)
                    .HasForeignKey(h => h.ArtistId);*/
            
            /*builder.Entity<Follower>()
                .HasOne(f =>f.Hobbyist)
                .WithMany(a => a.FollowedArtists)
                .HasForeignKey(h => h.HobbyistId);*/
            builder.Entity<Hobbyist>()
                .HasMany(a => a.FollowedArtists)
                .WithOne()
                .HasForeignKey(f => f.HobbyistId);
            
            

            builder.Entity<Artist>()
                    .HasMany(a => a.FollowersArtist)
                    .WithOne()
                    .HasForeignKey(f => f.ArtistId);

            builder.Entity<Follower>().ToTable("Followers");
            builder.Entity<Follower>().HasKey(f => f.FollowerId);
            builder.Entity<Follower>().Property(f => f.ArtistId);
            builder.Entity<Follower>().Property(f => f.HobbyistId);
            builder.Entity<Follower>().Property(a => a.RegistrationDate);
            builder.Entity<Follower>().Property(a => a.Collected).HasDefaultValue(false);


            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
