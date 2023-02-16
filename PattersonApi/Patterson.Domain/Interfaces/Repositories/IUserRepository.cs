using Patterson.Domain.ViewModel;
using System;

namespace Patterson.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UserViewModel, Guid>
    {

    }
}