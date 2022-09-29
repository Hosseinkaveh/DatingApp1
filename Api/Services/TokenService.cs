using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration conf)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["TokenKey"]));
        }
        public string CreateToken(AppUser user)
        {
           var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName)
            };

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject =new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,

            };

            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(descriptor);
            return    tokenhandler.WriteToken(token);
        }
    }
}