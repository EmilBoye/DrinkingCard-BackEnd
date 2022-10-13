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
        private readonly DatabaseContext databaseContext;
        public UserController(DatabaseContext databaseContextObj)
        {
            databaseContext = databaseContextObj;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await databaseContext.Users.ToListAsync();
            return Ok(user);
        }

        // Get a single User
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUserById")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User was not found");
        }

        // Update


        // Create

        // Delete a post
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var existingUser = await databaseContext.Users.FindAsync(id);
            if (existingUser != null)
            {
                databaseContext.Remove(existingUser);
                await databaseContext.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User not found");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
