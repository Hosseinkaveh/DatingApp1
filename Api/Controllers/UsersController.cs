using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

      [Authorize]
    public class UsersController : BaseApiController
    {
        
         private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> Get()
        {
            var users = await _userRepository.GetUsersAsync();
            
            return Ok(_mapper.Map<IEnumerable<MemberDto>>(users));
        }

      
        [HttpGet("{userName}")]
        public async Task<ActionResult<AppUser>> GetUsers(string userName)
        {
            var user = await _userRepository.GetUserByUsername(userName);
            return Ok(_mapper.Map<MemberDto>(user));
        }
    }
}