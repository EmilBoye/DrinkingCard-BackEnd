﻿using DrinkApi.Data;
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

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await databaseContext.Users.ToListAsync();
        }

        // GET: api/user/5
        [HttpGet]
        [Route("{id:id}")]
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
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {

            var existingUser = await databaseContext.Users.FindAsync(id);

            if (existingUser == null)
            {
                return BadRequest("User not found");
            }
            databaseContext.Users.Remove(existingUser);
            await databaseContext.SaveChangesAsync();
            return Ok(existingUser);
            
        }

        private bool UserExists(int id)
        {
            return databaseContext.Users.Any(x => x.UserId == id);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}