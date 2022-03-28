using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }


          [Authorize]
 // api/users/1,2,3
          [HttpGet("{id}")]
        public async  Task<ActionResult<AppUser>> GetUsers(int id)
        {
           // var users = await _context.Users.FindAsync(id);
            //return users;
            return await _context.Users.FindAsync(id);
        }


    }
}