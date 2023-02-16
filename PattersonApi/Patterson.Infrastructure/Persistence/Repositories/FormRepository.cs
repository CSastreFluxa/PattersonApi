using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patterson.Domain.Entities;
using Patterson.Domain.Interfaces;
using Patterson.Domain.Interfaces.Repositories;
using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterson.Infrastructure.Persistence.Repositories
{
    public class FormRepository : BaseRepository<Form, FormViewModel, Guid>, IFormRepository
    {
        public FormRepository(IUserDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<IEnumerable<FormViewModel>> GetFormsAsync(Guid userId)
        {
            return await this.DbSet.Where(f => f.UserId == userId)
                .Select(f => mapper.Map<Form, FormViewModel>(f))
                .ToListAsync();
        }
    }
}