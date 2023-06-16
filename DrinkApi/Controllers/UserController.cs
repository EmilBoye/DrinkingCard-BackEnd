using DrinkApi.Data;
using DrinkApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public UserController(DatabaseContext databaseContextObj)
        {
            _context = databaseContextObj;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User was not found");
        }

        // Create
        // POST api/User
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var postUser = new User()
            {
                Id = user.Id,
                RoleId = 2,
                Role = user.Role,
                Username = user.Username,
                Alcohol = user.Alcohol,
                NonAlcohol = user.NonAlcohol,
                Passwordhash = user.Passwordhash,
            };
            postUser.Id = new int();
            await _context.AddAsync(postUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = postUser.Id }, postUser);
        }
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        // Update
        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound("User was not found");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // Delete a post
        // DELETE api/User/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return Ok("User was not found");
            }
            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return Ok(existingUser);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
