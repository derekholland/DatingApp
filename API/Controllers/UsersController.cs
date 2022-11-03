using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
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
        //asynchronous 
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //return list of users s
            return await _context.Users.ToListAsync();
        }

        //api/users/3
        //asynchronous
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //find id and return that user 
           return await _context.Users.FindAsync(id);
        }
    }
}