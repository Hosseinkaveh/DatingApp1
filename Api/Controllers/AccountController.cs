using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenservice;
        public AccountController(DataContext context,ITokenService tokerService)
        {
            _context = context;
            _tokenservice = tokerService;
            
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await ExistUsername(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var User = new AppUser{
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
                };

                 _context.Users.Add(User);
                 await _context.SaveChangesAsync();

             return new UserDto{
                Username = User.UserName,
                TokenKey = _tokenservice.CreateToken(User)
            };

             
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user =await _context.Users
            .SingleOrDefaultAsync(x =>x.UserName == loginDto.Username.ToLower());

            if(user == null) return Unauthorized("Invalid username");

           using var hmac = new HMACSHA512(user.PasswordSalt);
           var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0;i < user.PasswordHash.Length;i++)
            {
                if(user.PasswordHash[i] != computeHash[i])
                return Unauthorized("Invalid password");
            }

            return new UserDto{
                Username = user.UserName,
                TokenKey = _tokenservice.CreateToken(user)
            };



        }

        private async Task<bool> ExistUsername(string username)
        {
           return await _context.Users.AnyAsync(x =>x.UserName == username.ToLower());
        }
    }
}