using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommunityResearchController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public CommunityResearchController(VenomVerseContext context)
        {
            _context = context;
        }

        // GET: api/CommunityResearch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityResearch>>> GetCommunityResearch()
        {
          if (_context.CommunityResearch == null)
          {
              return NotFound();
          }
          return await _context.CommunityResearch.ToListAsync();
        }

        // GET: api/CommunityResearch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityResearch>> GetCommunityResearch(long id)
        {
          if (_context.CommunityResearch == null)
          {
              return NotFound();
          }
          var communityResearch = await _context.CommunityResearch.FindAsync(id);

          if (communityResearch == null)
          {
              return NotFound();
          }

          return communityResearch;
        }

        // PUT: api/CommunityResearch/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityResearch(long id, CommunityResearch communityResearch)
        {
            if (id != communityResearch.CommunityResearchId)
            {
                return BadRequest();
            }

            _context.Entry(communityResearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityResearchExists(id))
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

        // POST: api/CommunityResearch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityResearch>> PostCommunityResearch(CommunityResearch communityResearch)
        {
          if (_context.CommunityResearch == null)
          {
              return Problem("Entity set 'VenomVerseContext.CommunityResearch'  is null.");
          }
          _context.CommunityResearch.Add(communityResearch);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetCommunityResearch", new { id = communityResearch.CommunityResearchId }, communityResearch);
        }

        // DELETE: api/CommunityResearch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityResearch(long id)
        {
            if (_context.CommunityResearch == null)
            {
                return NotFound();
            }
            var communityResearch = await _context.CommunityResearch.FindAsync(id);
            if (communityResearch == null)
            {
                return NotFound();
            }

            _context.CommunityResearch.Remove(communityResearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityResearchExists(long id)
        {
            return (_context.CommunityResearch?.Any(e => e.CommunityResearchId == id)).GetValueOrDefault();
        }
    }
}