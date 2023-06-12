using DrinkApi.Data;
using DrinkApi.Models.DTO;
using DrinkApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public RatingController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/Rating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetAllRatings()
        {
            return await _context.Ratings.ToListAsync();
        }

        // POST: api/Rating
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] Rating user)
        {
            var commentPost = new Rating()
            {
                User = user.User,
                Comment = user.Comment,
                PublishedComment = user.PublishedComment
            };
            commentPost.Id = new int();

            await _context.Ratings.AddAsync(commentPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllRatings), new { id = commentPost.Id }, commentPost);
        }
        //public async Task<ActionResult<Rating>> PostUser(Rating user)
        //{
        //    _context.Ratings.Add(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}
        // PUT api/Comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Rating rating)
        {
            if (id != rating.Id)
            {
                return BadRequest("Id not found");
            }
            _context.Entry(rating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // DELETE api/Rating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var existingComment = await _context.Ratings.FindAsync(id);

            if (existingComment == null)
            {
                return BadRequest("Comment was not found");
            }
            _context.Ratings.Remove(existingComment);
            await _context.SaveChangesAsync();
            return Ok(existingComment);
        }

        private bool CommentExists(int id)
        {
            return _context.Ratings.Any(x => x.Id == id);
        }
    }
}
