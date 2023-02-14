using DrinkApi.Data;
using DrinkApi.Models.DTO;
using DrinkApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcoholController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AlcoholController(DatabaseContext context)
        {
            _context = context;
        }

        #region CRUD
        // GET: api/alcohol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alcohol>>> GetAllAlcohol()
        {
            return await _context.Alcohols.ToListAsync();
        }

        // GET api/alcohol/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlcoholById([FromRoute] int id)
        {
            var alcohol = await _context.Alcohols.FindAsync(id);
            if (alcohol != null)
            {
                return Ok(alcohol);
            }
            return NotFound("Alcohol not found");
        }

        // GET api/alcohol/mojito
        //[HttpGet("{alcoholname}")]
        //public async Task<IActionResult> GetAlcoholByName([FromRoute] Alcohol alcoName)
        //{
        //    var alcoholName = await _context.Alcohols.FirstOrDefaultAsync(a => a.Title == alcoName.Title);
        //    if (alcoholName != null)
        //    {
        //        return Ok(alcoholName);
        //    }
        //    return NotFound();
        //}

        // POST api/Alcohol
        [HttpPost]
        public async Task<IActionResult> CreateAlcoholType([FromBody] Alcohol alcohol)
        {
            var alcoholPost = new Alcohol()
            {
                Author = alcohol.Author,
                Title = alcohol.Title,
                Strength = alcohol.Strength,
                Description = alcohol.Description,
                FeaturedImageUrl = alcohol.FeaturedImageUrl,
                Ingredients = alcohol.Ingredients,
                AlcoholType = alcohol.AlcoholType,
                Visible = alcohol.Visible,
                PublishDate = alcohol.PublishDate,
                UpdatedDate = alcohol.UpdatedDate
            };

            alcoholPost.AlcoId = new int();
            await _context.Alcohols.AddAsync(alcoholPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlcoholById), new { id = alcoholPost.AlcoId }, alcoholPost);
        }

        // PUT api/Alcohol/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlcoholType(int id, Alcohol alcohol)
        {
            if (id != alcohol.AlcoId)
            {
                return BadRequest("Id not found");
            }
            _context.Entry(alcohol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcoholExists(id))
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

        // DELETE api/Alcohol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlcohol([FromRoute] int id)
        {
            var existingAlcohol = await _context.Alcohols.FindAsync(id);

            if (existingAlcohol == null)
            {
                return BadRequest("Drink was not found");
            }
            _context.Alcohols.Remove(existingAlcohol);
            await _context.SaveChangesAsync();
            return Ok(existingAlcohol + "");
        }
        private bool AlcoholExists(int id)
        {
            return _context.Alcohols.Any(x => x.AlcoId == id);
        }
        #endregion
    }
}
