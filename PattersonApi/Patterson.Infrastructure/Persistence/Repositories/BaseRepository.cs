using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patterson.Domain.Common;
using Patterson.Domain.Interfaces;
using Patterson.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterson.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<Entity, ViewModel, PrimaryKeyType> : IBaseRepository<ViewModel, PrimaryKeyType>
        where Entity : BaseEntity<PrimaryKeyType>
        where ViewModel : class
        where PrimaryKeyType : struct
    {
        protected readonly IMapper mapper;
        public readonly IDbContext dbContext;

        public BaseRepository(IDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected DbSet<Entity> DbSet
        {
            get
            {
                return this.dbContext.Set<Entity>();
            }
        }

        public async Task<IEnumerable<ViewModel>> GetAllAsync()
        {
            return await DbSet.Select(a => mapper.Map<Entity, ViewModel>(a))
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<ViewModel> GetAsync(PrimaryKeyType id)
        {
            return mapper.Map<Entity, ViewModel>(await DbSet.FindAsync(id)
                .ConfigureAwait(false));
        }

        public async Task InsertAsync(ViewModel element)
        {
            await DbSet.AddAsync(mapper.Map<ViewModel, Entity>(element));
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(ViewModel element)
        {
            DbSet.Update(mapper.Map<ViewModel, Entity>(element));
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAsync(PrimaryKeyType id)
        {
            var entityToRemove = await DbSet.FindAsync(id).ConfigureAwait(false);
            DbSet.Remove(entityToRemove);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(PrimaryKeyType id)
        {
            return await DbSet.AnyAsync(e => e.Id.Equals(id)).ConfigureAwait(false);
        }
    }
}