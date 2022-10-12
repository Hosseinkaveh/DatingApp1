using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(await context.Users.AnyAsync()) return;

            var Textfile = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = System.Text.Json.JsonSerializer.Deserialize<List<AppUser>>(Textfile);
            if(users == null) return;
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();

               user.PasswordSalt = hmac.Key;
               user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));

               await context.Users.AddAsync(user);
            }
            await context.SaveChangesAsync();


        }
        
    }
}