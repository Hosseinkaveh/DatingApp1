using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interfaces;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService
        (this IServiceCollection services,IConfiguration config) 
        {
             services.AddScoped<ITokenService,TokenService>();
             services.AddScoped<IUserRepository,UserRepository>();

            services.AddDbContext<DataContext>(option =>{
                option.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;

        }      
    }
}