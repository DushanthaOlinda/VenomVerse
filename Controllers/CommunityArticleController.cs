using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommunityArticleController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public CommunityArticleController(VenomVerseContext context)
        {
            _context = context;
        }

        // GET: api/CommunityArticle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityArticle>>> GetCommunityArticle() {
          if (_context.CommunityArticle == null) return NotFound(); 
          return await _context.CommunityArticle.ToListAsync();
        }

        // GET: api/CommunityArticle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityArticle>> GetCommunityArticle(long id) {
          if (_context.CommunityArticle == null)  return NotFound();
          var communityArticle = await _context.CommunityArticle.FindAsync(id);
          if (communityArticle == null) return NotFound(); 
          return communityArticle;
        }

        // PUT: api/CommunityArticle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityArticle(long id, CommunityArticle communityArticle)
        {
            if (id != communityArticle.CommunityArticleId) return BadRequest();
            _context.Entry(communityArticle).State = EntityState.Modified;
            try  {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CommunityArticleExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/CommunityArticle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityArticle>> PostCommunityArticle(CommunityArticle communityArticle) {
          if (_context.CommunityArticle == null) {
              return Problem("Entity set 'VenomVerseContext.CommunityArticle'  is null.");
          }
          _context.CommunityArticle.Add(communityArticle);
          await _context.SaveChangesAsync();
          return CreatedAtAction("GetCommunityArticle", new { id = communityArticle.CommunityArticleId }, communityArticle);
        }

        // DELETE: api/CommunityArticle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityArticle(long id) {
            if (_context.CommunityArticle == null) return NotFound(); 
            var communityArticle = await _context.CommunityArticle.FindAsync(id);
            if (communityArticle == null)  return NotFound();
            _context.CommunityArticle.Remove(communityArticle);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        // PUT: api/CommunityArticle/Approve/{id}
        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> ApproveArticle( long id, CommunityArticle communityArticle ) {
            if (id != communityArticle.CommunityArticleId) return BadRequest();
            _context.Entry(communityArticle).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CommunityArticleExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return NoContent();
        }

        private bool CommunityArticleExists(long id) {
            return (_context.CommunityArticle?.Any(e => e.CommunityArticleId == id)).GetValueOrDefault();
        }

        // ============================================================================
        // ============================ DTO CONVERSION ================================
        // ============================================================================

        private static CommunityArticleDto ArticleDtoToArticle(CommunityArticle communityArticle) => new CommunityArticleDto {
            CommunityArticleId = communityArticle.CommunityArticleId,
            UserId = communityArticle.UserId,
            Category = communityArticle.Category,
            Description = communityArticle.Description,
            Content = communityArticle.Content,
            DateTime = communityArticle.DateTime,
            Media = communityArticle.Media,
            Author = communityArticle.Author,
            ArticleStatus = communityArticle.ArticleStatus,
            ArticleCopyright = communityArticle.ArticleCopyright,
            ApprovedUserId = communityArticle.ApprovedUserId
        };

        // private static CommunityArticle ArticleToArticleDto(CommunityArticleDto communityArticleDto) => new CommunityArticle {

        // };





    }
}