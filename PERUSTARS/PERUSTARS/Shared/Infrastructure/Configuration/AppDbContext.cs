using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;

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

        }
    }
}
