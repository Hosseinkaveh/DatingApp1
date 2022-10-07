using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    
    public class BuggyController : BaseApiController
    {
      private readonly DataContext _context;
      public BuggyController(DataContext context)
      {
        _context = context;
      }

      [Authorize]
      [HttpGet("auth")]
      public ActionResult<string> GetSecret()
      {
        return "secret text";
      }
       [HttpGet("not-found")]
      public ActionResult<AppUser> GetNotFound()
      {
       var user = _context.Users.Find(-1);
       if(user == null) return NotFound();
       return Ok(user);
      }
       [HttpGet("server-error")]
      public ActionResult<string> GetServerError()
      {
        var thing = _context.Users.Find(-1);
        var thingToReturn = thing.ToString();
        return thingToReturn;
        
      }
       [HttpGet("bad-request")]
      public ActionResult<string> GetBadRequest()
      {
        return BadRequest("This was not good request");
      }

    }
}