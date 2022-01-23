#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EpsicEFCoreAPI;
using EpsicEFCoreAPI.Data;
using EpsicEFCoreAPI.Models;

namespace EpsicEFCoreAPI.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            var users = await _context.Users.Select(u => new UserViewModel
            { 
                Name = u.Name_User,
                Subjects = u.Subjects.Select(s => new SubjectViewModel { Subject = s.Name_Subject })
            })
                .ToListAsync();
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
           
           

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, CreateUserDto request)
        {
            var user = await _context.Users.FindAsync(id);
            user.Name_User = request.Name_User;
            user.Password = request.Password;
            if (id != user.Id_User)
            {
                return BadRequest();
            }

            //_context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto request)
        {
            var newUser = new User
            {
                Name_User = request.Name_User,
                Password = request.Password
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = newUser.Id_User }, newUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id_User == id);
        }
    }
}
