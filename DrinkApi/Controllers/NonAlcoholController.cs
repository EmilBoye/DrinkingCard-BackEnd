using DrinkApi.Data;
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
        public async Task<IActionResult> PostNonAlcohol([FromBody] NonAlcohol nonalcohol)
        {
            var nonAlcoholPost = new NonAlcohol()
            {
                Author = nonalcohol.Author,
                Title = nonalcohol.Title,
                Ingredients = nonalcohol.Ingredients,
                FeaturedImageUrl = nonalcohol.FeaturedImageUrl,
                NonAlcoholType = nonalcohol.NonAlcoholType,
                Visible = nonalcohol.Visible,
                PublishDate = nonalcohol.PublishDate,
                UpdatedDate = nonalcohol.UpdatedDate
            };
            nonAlcoholPost.NonAlcoId = new int();
            await _context.NonAlcohols.AddAsync(nonAlcoholPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNonAlcoholByID), new { id = nonAlcoholPost.NonAlcoId }, nonAlcoholPost);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNonAlcohol(int id, NonAlcohol nonAlcohol)
        {
            if (id != nonAlcohol.NonAlcoId)
            {
                return BadRequest("Drink not found");
            }
            _context.Entry(nonAlcohol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonAlcoholExist(id))
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
        //public async Task<IActionResult> UpdateNonAlcohol(int id, AlcoholFreeRequest alcoholFree)
        //{
        //    var existingAlcoFree = await _context.NonAlcohols.FindAsync(id);
        //    if (existingAlcoFree != null)           
        //    {
        //        existingAlcoFree.Author = alcoholFree.Author;
        //        existingAlcoFree.Title = alcoholFree.Title;
        //        existingAlcoFree.Description = alcoholFree.Description;
        //        existingAlcoFree.Ingredients = alcoholFree.Ingredients;
        //        existingAlcoFree.NonAlcoholType = alcoholFree.NonAlcoholType;
        //        existingAlcoFree.Visible = alcoholFree.Visible;
        //        existingAlcoFree.PublishDate = alcoholFree.PublishDate;
        //        existingAlcoFree.UpdatedDate = alcoholFree.UpdatedDate;

        //        await _context.SaveChangesAsync();
        //        return Ok(existingAlcoFree);
        //    }
        //    return NotFound("Drink was not found");
        //}

        [HttpDelete]
        public async Task<IActionResult> DeleteNonAlcoholic([FromRoute] int id)
        {
            var existingAlcoFree = await _context.NonAlcohols.FindAsync(id);

            if (existingAlcoFree == null)
            {
                return BadRequest("Drink was not found");
            }
            _context.NonAlcohols.Remove(existingAlcoFree);
            await _context.SaveChangesAsync();
            return Ok(existingAlcoFree);
        }
        private bool NonAlcoholExist(int id)
        {
            return _context.NonAlcohols.Any(x => x.NonAlcoId == id);
        }
        #endregion
    }
}
