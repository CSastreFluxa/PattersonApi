using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<ViewModel, PrimaryKeyType>
        where ViewModel : class
        where PrimaryKeyType : struct
    {
        Task<IEnumerable<ViewModel>> GetAllAsync();
        Task<ViewModel> GetAsync(PrimaryKeyType id);
        Task InsertAsync(ViewModel element);
        Task UpdateAsync(ViewModel element);
        Task RemoveAsync(PrimaryKeyType id);
        Task<bool> ExistsAsync(PrimaryKeyType id);
    }
}