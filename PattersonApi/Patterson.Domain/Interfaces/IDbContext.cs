using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Patterson.Domain.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}