using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityPostController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public CommunityPostController(VenomVerseContext context)
        {
            _context = context;
        }

        // GET: api/CommunityPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityPost>>> GetCommunityPost()
        {
          if (_context.CommunityPost == null)
          {
              return NotFound();
          }
            return await _context.CommunityPost.ToListAsync();
        }

        // GET: api/CommunityPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityPost>> GetCommunityPost(long id)
        {
          if (_context.CommunityPost == null)
          {
              return NotFound();
          }
            var communityPost = await _context.CommunityPost.FindAsync(id);

            if (communityPost == null)
            {
                return NotFound();
            }

            return communityPost;
        }

        // PUT: api/CommunityPost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityPost(long id, CommunityPost communityPost)
        {
            if (id != communityPost.CommunityPostId)
            {
                return BadRequest();
            }

            _context.Entry(communityPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityPostExists(id))
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

        // POST: api/CommunityPost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityPost>> PostCommunityPost(CommunityPost communityPost)
        {
          if (_context.CommunityPost == null)
          {
              return Problem("Entity set 'VenomVerseContext.CommunityPost'  is null.");
          }
            _context.CommunityPost.Add(communityPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityPost", new { id = communityPost.CommunityPostId }, communityPost);
        }

        // DELETE: api/CommunityPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityPost(long id)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            var communityPost = await _context.CommunityPost.FindAsync(id);
            if (communityPost == null)
            {
                return NotFound();
            }

            _context.CommunityPost.Remove(communityPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityPostExists(long id)
        {
            return (_context.CommunityPost?.Any(e => e.CommunityPostId == id)).GetValueOrDefault();
        }
    }
}
