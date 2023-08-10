using BlogAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BlogAppAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlogAppAPI.Requests;

namespace BlogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return BadRequest("Invalid Id");

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostRequest postRequest)
        {
            var post = new Post
            {
                Title = postRequest.Title,
                Content = postRequest.Content,
                Comments = new HashSet<Comment>()
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PostRequest updatedPostRequest) // Use PostRequest class
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return BadRequest("No Such Post");

            post.Title = updatedPostRequest.Title;
            post.Content = updatedPostRequest.Content;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return BadRequest("No Such Post");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
