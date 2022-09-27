using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
[ApiController]
 [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
         private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }
     
        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppUser>>>  Get()
        {
            return await _context.AppUsers.ToListAsync();
        }
           [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }
    }
}