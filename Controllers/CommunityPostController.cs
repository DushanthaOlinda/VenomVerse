using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Controllers;

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
    public async Task<ActionResult<IEnumerable<CommunityPostDto>>> GetCommunityPost() {
        if (_context.CommunityPost == null)  return NotFound();
        return await _context.CommunityPost.Select(x=>CommunityPostToCommunityPostDto(x)).ToListAsync();
    }

    // GET: api/CommunityPost/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CommunityPostDto>> GetCommunityPost(long id) {
        if (_context.CommunityPost == null) return NotFound();
        var communityPost = await _context.CommunityPost.FindAsync(id);
        if (communityPost == null) return NotFound();
        return CommunityPostToCommunityPostDto(communityPost);
    }

    // PUT: api/CommunityPost/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommunityPost(long id, CommunityPostDto communityPostDto) { // ( user id, post dto)
        if (id != communityPostDto.UserId) return BadRequest();     // userid != post.userId
        if (_context.CommunityPost == null) return NotFound();
        var communityPost = await _context.CommunityPost.FindAsync(communityPostDto.CommunityPostId);
        if (communityPost == null) return NotFound();
        communityPost = CommunityPostDtoToCommunityPost(communityPostDto, communityPost);
        _context.Entry(communityPost).State = EntityState.Modified;
        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!CommunityPostExists(communityPost.CommunityPostId)) {
                return NotFound();
            } else {
                throw;
            }
        }
        return NoContent();
    }

    // POST: api/CommunityPost
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CommunityPostDto>> PostCommunityPost(CommunityPostDto communityPostDto) {
        if (_context.CommunityPost == null) return Problem("Entity set 'VenomVerseContext.CommunityPost'  is null.");
        var communityPost = CommunityPostDtoToCommunityPost(communityPostDto);
        _context.CommunityPost.Add(communityPost);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetCommunityPost", new { id = communityPost.CommunityPostId }, communityPost);
    }

    // DELETE: api/CommunityPost/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommunityPost(long id) {
        if (_context.CommunityPost == null)  return NotFound();
        var communityPost = await _context.CommunityPost.FindAsync(id);
        if (communityPost == null) return NotFound();
        _context.CommunityPost.Remove(communityPost);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool CommunityPostExists(long CommunityPostId) {
        return (_context.CommunityPost?.Any(e => e.CommunityPostId == CommunityPostId)).GetValueOrDefault();
    }

    // ============================================================================
    // ============================ DTO CONVERSION ================================
    // ============================================================================    

    private static CommunityPostDto CommunityPostToCommunityPostDto ( CommunityPost communityPost ) => new CommunityPostDto {
        CommunityPostId = communityPost.CommunityPostId,
        UserId = communityPost.UserId,
        Category = communityPost.Category,
        Description = communityPost.Description,
        DateTime = communityPost.DateTime,
        Media = communityPost.Media,
        React = communityPost.React,
        PostEdited = communityPost.PostEdited,
        PostStatus = communityPost.PostStatus
    };

    private static CommunityPost CommunityPostDtoToCommunityPost ( CommunityPostDto communityPost ) => new CommunityPost {
        CommunityPostId = (long)communityPost.CommunityPostId!,
        UserId = (long)communityPost.UserId!,
        Category = communityPost.Category!,
        Description = communityPost.Description!,
        DateTime = communityPost.DateTime,
        Media = communityPost.Media,
        React = communityPost.React,
        PostEdited = communityPost.PostEdited,
        PostStatus = communityPost.PostStatus
    };

    private static CommunityPost CommunityPostDtoToCommunityPost ( CommunityPostDto communityPostDto, CommunityPost communityPost ) {
        // communityPost.CommunityPostId = communityPostDto.CommunityPostId!;
        // communityPost.UserId = communityPostDto.UserId!;
        communityPost.DateTime = communityPostDto.DateTime!;
        if ( communityPostDto.Category != null ) {
            communityPost.Category = communityPostDto.Category!;
        }
        if ( communityPostDto.Description != null ) {
            communityPost.Description = communityPostDto.Description!;
        }
        if ( communityPostDto.Media != null ) {
            communityPost.Media = communityPostDto.Media!;
        }
        if ( communityPostDto.PostEdited ) {
            communityPost.PostEdited = communityPostDto.PostEdited!;
        }
        return communityPost;
    }
}

