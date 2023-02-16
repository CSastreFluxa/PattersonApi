using Microsoft.AspNetCore.Mvc;
using Patterson.Application.Interfaces.Services;
using Patterson.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterson.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            return await UserService.GetUsersAsync();
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<UserViewModel> GetUserAsync(Guid userId)
        {
            return await UserService.GetUserAsync(userId);
        }
    }
}