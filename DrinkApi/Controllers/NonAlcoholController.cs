﻿using DrinkApi.Data;
using DrinkApi.Models.DTO;
using DrinkApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonAlcoholController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public NonAlcoholController(DatabaseContext context)
        {
            _context = context;
        }
        #region CRUD
        // GET : api/NonAlcohol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonAlcohol>>> GetAllNonAlcohol()
        {
            return await _context.NonAlcohols.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNonAlcoholByID([FromRoute] int id)
        {
            var nonAlcohol = await _context.NonAlcohols.FindAsync(id);
            if (nonAlcohol != null)
            {
                return Ok(nonAlcohol);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNonAlcohol([FromBody] AlcoholFreeRequest request)
        {
            var nonAlcoholPost = new NonAlcohol()
            {
                Author = request.Author,
                Title = request.Title,
                Ingredients = request.Ingredients,
                NonAlcoholType = request.NonAlcoholType,
                Visible = request.Visible,
                PublishDate = request.PublishDate,
                UpdatedDate = request.UpdatedDate
            };
            nonAlcoholPost.NonAlcoId = new int();
            await _context.NonAlcohols.AddAsync(nonAlcoholPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNonAlcoholByID), new { id = nonAlcoholPost.NonAlcoId }, nonAlcoholPost);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateNonAlcohol()
        //{

        //}
        #endregion
    }
}