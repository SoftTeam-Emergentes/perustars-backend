using Microsoft.EntityFrameworkCore;
using PERUSTARS.Extensions;
using PERUSTARS.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Persistence.Context
{
    public class IAMDbContext: BaseDbContext
    {
        public DbSet<User> Users { get; set; }

        public IAMDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //*******************************************//
            /*USERS*/
            //*******************************************//

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired();

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}