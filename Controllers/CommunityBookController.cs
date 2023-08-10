using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommunityBookController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public CommunityBookController(VenomVerseContext context)
        {
            _context = context;
        }

        // GET: api/CommunityBook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityBook>>> GetCommunityBook()
        {
          if (_context.CommunityBook == null)
          {
              return NotFound();
          }
          return await _context.CommunityBook.ToListAsync();
        }

        // GET: api/CommunityBook/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityBook>> GetCommunityBook(long id)
        {
          if (_context.CommunityBook == null)
          {
              return NotFound();
          }
          var communityBook = await _context.CommunityBook.FindAsync(id);

          if (communityBook == null)
          {
              return NotFound();
          }

          return communityBook;
        }

        // PUT: api/CommunityBook/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityBook(long id, CommunityBook communityBook)
        {
            if (id != communityBook.CommunityBookId)
            {
                return BadRequest();
            }

            _context.Entry(communityBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityBookExists(id))
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

        // POST: api/CommunityBook
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityBook>> PostCommunityBook(CommunityBook communityBook)
        {
          if (_context.CommunityBook == null)
          {
              return Problem("Entity set 'VenomVerseContext.CommunityBook'  is null.");
          }
          _context.CommunityBook.Add(communityBook);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetCommunityBook", new { id = communityBook.CommunityBookId }, communityBook);
        }

        // DELETE: api/CommunityBook/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityBook(long id)
        {
            if (_context.CommunityBook == null)
            {
                return NotFound();
            }
            var communityBook = await _context.CommunityBook.FindAsync(id);
            if (communityBook == null)
            {
                return NotFound();
            }

            _context.CommunityBook.Remove(communityBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityBookExists(long id)
        {
            return (_context.CommunityBook?.Any(e => e.CommunityBookId == id)).GetValueOrDefault();
        }
    }
}