using Patterson.Application.Interfaces.Services;
using Patterson.Domain.Interfaces.Repositories;
using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }
        
        public Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            return this.UserRepository.GetAllAsync();
        }

        public Task<UserViewModel> GetUserAsync(Guid userId)
        {
            return this.UserRepository.GetAsync(userId);
        }
    }
}