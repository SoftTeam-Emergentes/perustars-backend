using Microsoft.EntityFrameworkCore;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.IdentityAndAccountManagement.Infrastructure.Context;

public class IdentityAccountManagementDbContext: BaseDbContext
{
    public DbSet<User> Users { get; set; }

    public IdentityAccountManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
}