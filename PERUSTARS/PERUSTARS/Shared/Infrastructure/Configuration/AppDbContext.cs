using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;

namespace PERUSTARS.Shared.Infrastructure.Configuration
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

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


        }
    }
}
