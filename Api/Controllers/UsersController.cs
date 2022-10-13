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
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> Get()
        { 
            return Ok(await _userRepository.GetMembersAsync());
        }

      
        [HttpGet("{userName}")]
        public async Task<ActionResult<MemberDto>> GetUsers(string userName)
        {
            return await _userRepository.GetMemberByUsername(userName);
          
        }
    }
}