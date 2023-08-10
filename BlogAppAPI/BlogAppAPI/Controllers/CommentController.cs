using BlogAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BlogAppAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using BlogAppAPI.Requests;

namespace BlogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comments = await _context.Comments.ToListAsync();
            return Ok(comments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return NotFound("No Such Comment");

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommentRequest commentRequest)
        {
            var postExists = await _context.Posts.AnyAsync(p => p.Id == commentRequest.PostId);

            if (!postExists)
                return BadRequest("Invalid PostId");

            var comment = new Comment
            {
                Text = commentRequest.Text,
                PostId = commentRequest.PostId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = comment.Id }, comment);
        }


        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdateCommentRequest updatedCommentRequest) // Use CommentRequest class
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return NotFound("No Such Comment");

            // You Can Only Change The Text
            comment.Text = updatedCommentRequest.Text;
            await _context.SaveChangesAsync();

            return Ok(comment);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return NotFound("No Such Comment");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
