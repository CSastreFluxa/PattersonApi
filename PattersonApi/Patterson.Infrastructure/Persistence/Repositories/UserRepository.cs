using AutoMapper;
using Patterson.Domain.Entities;
using Patterson.Domain.Interfaces;
using Patterson.Domain.Interfaces.Repositories;
using Patterson.Domain.ViewModel;
using System;

namespace Patterson.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User, UserViewModel, Guid>, IUserRepository
    {
        public UserRepository(IUserDbContext context, IMapper mapper)
            : base (context, mapper)
        {

        }
    }
}