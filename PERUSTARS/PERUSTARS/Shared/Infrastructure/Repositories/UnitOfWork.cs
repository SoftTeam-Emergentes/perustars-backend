﻿
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.Shared.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        
        public UnitOfWork(AppDbContext baseDbContext)
        {
            _dbContext = baseDbContext;
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
