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
        // Henter alle drinks der er i databasen. Den henter det fra tabellen Alcohols.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alcohol>>> GetAllAlcohol()
        {
            return await _context.Alcohols.ToListAsync();
        }

        // GET api/alcohol/5
        // Henter en specifik drink med hjælp af et Id
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
        // Opretter en bruger i databasen ved at modtage brugeroplysninger og gemme dem
        [HttpPost]
        public async Task<IActionResult> CreateAlcoholType([FromBody] Alcohol alcohol)
        {
            // Opretter et nyt Alkohol-objekt med de nødvendige attributter
            var alcoholPost = new Alcohol()
            {
                Author = alcohol.Author,
                AuthorId = alcohol.AuthorId,
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
            //Nulstiller Id for at sikre, auto generation af id.
            alcoholPost.Id = new int();
            //Tilføjer den oprettede drink til konteksten og gemmer ændringerne i databasen
            await _context.Alcohols.AddAsync(alcoholPost);
            await _context.SaveChangesAsync();

            // CreatedAtAction er en status 201 metode.
            return CreatedAtAction(nameof(GetAlcoholById), new { id = alcoholPost.Id }, alcoholPost);
        }

        // PUT api/Alcohol/5
        // Opdaterer en eksisterende drink.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlcoholType(int id, Alcohol alcohol)
        {
            // Tjekker om angivne drink id matcher med drinkens id
            if (id != alcohol.Id)
            {
                return BadRequest("Id not found");
            }
            // Markerer drink som ændret i konteksten
            _context.Entry(alcohol).State = EntityState.Modified;

            try
            {
                // Gemmer til databasen.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Håndterer mulig konflikt.
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
        // Sletter en drink som er i databasen
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlcohol([FromRoute] int id)
        {
            //  Finder den eksisterende drink i databasen baseret på id
            var existingAlcohol = await _context.Alcohols.FindAsync(id);

            // Tjek om drinken blev fundet
            if (existingAlcohol == null)
            {
                return BadRequest("Drink was not found");
            }
            // Fjerner drinken.
            _context.Alcohols.Remove(existingAlcohol);
            // Gemmer til Databasen
            await _context.SaveChangesAsync();
            return Ok(existingAlcohol);
        }
        // En bool som vi benytter i Updaten.
        private bool AlcoholExists(int id)
        {
            return _context.Alcohols.Any(x => x.Id == id);
        }
        #endregion
    }
}
