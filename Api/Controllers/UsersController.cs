using Api.Data;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    public class UsersController : BaseApiController
    {
        
         private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }

        [Authorize]
        [HttpGet("{userName}")]
        public async Task<ActionResult<AppUser>> GetUsers(string userName)
        {
            return await _userRepository.GetUserByUsername(userName);
        }
    }
}