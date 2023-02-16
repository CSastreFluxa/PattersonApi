using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserAsync(Guid userId);
    }
}