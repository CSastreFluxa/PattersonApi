using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.Domain.Interfaces.Repositories
{
    public interface IFormRepository : IBaseRepository<FormViewModel, Guid>
    {
        Task<IEnumerable<FormViewModel>> GetFormsAsync(Guid userId);
    }
}