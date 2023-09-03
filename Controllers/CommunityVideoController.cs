using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CommunityVideoController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public CommunityVideoController(VenomVerseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommunityVideoDto>>> GetAllVideos() {
        if ( _context.CommunityVideo == null ) return NotFound();
        return await _context.CommunityVideo.Select( x=>CommunityVideoToCommunityVideoDto(x)).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommunityVideoDto>> GetVideoDetail(long id) {
        if ( _context.CommunityVideo == null ) return NotFound();
        var communityVideo = await _context.CommunityVideo.FindAsync(id);
        if ( communityVideo == null ) return NotFound();
        return CommunityVideoToCommunityVideoDto(communityVideo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommunityVideo(long id, CommunityVideoDto communityVideoDto) {
        if ( id != communityVideoDto.CommunityVideoId ) return BadRequest();
        if (_context.CommunityVideo == null) return BadRequest();
        var communityVideo = await _context.CommunityVideo.FindAsync(communityVideoDto.CommunityVideoId);
        if ( communityVideo == null ) return NotFound();
        communityVideo = CommunityVideoDtoToCommunityVideo(communityVideoDto, communityVideo);
        _context.Entry(communityVideo).State = EntityState.Modified;
        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!CommunityVideoExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<CommunityVideoDto>> PostCommunityVideo( CommunityVideoDto communityVideoDto ) {
        if (_context.CommunityVideo == null) return NotFound();
        var communityVideo = CommunityVideoDtoToCommunityVideo(communityVideoDto);
        _context.CommunityVideo.Add(communityVideo);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetVideoDetail", new { id = communityVideo.CommunityVideoId }, communityVideo );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommunityVideo(long id) {
        if (_context.CommunityVideo == null) return NotFound();
        var communityVideo = await _context.CommunityVideo.FindAsync(id);
        if (communityVideo == null) return NotFound();
        _context.CommunityVideo.Remove(communityVideo);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool CommunityVideoExists(long id) {
        return (_context.CommunityVideo?.Any(e => e.CommunityVideoId == id)).GetValueOrDefault();
    }


    // ============================================================================
    // ============================ DTO CONVERSION ================================
    // ============================================================================

    private static CommunityVideoDto CommunityVideoToCommunityVideoDto (CommunityVideo communityVideo) => new CommunityVideoDto {
        CommunityVideoId = communityVideo.CommunityVideoId,
        UserId = communityVideo.UserId,
        VideoTitle = communityVideo.VideoTitle,
        VideoDescription = communityVideo.VideoDescription,
        VideoLink = communityVideo.VideoLink
    };

    private static CommunityVideo CommunityVideoDtoToCommunityVideo (CommunityVideoDto communityVideo) => new CommunityVideo {
        CommunityVideoId = communityVideo.CommunityVideoId!,
        UserId = communityVideo.UserId!,
        VideoTitle = communityVideo.VideoTitle!,
        VideoDescription = communityVideo.VideoDescription!,
        VideoLink = communityVideo.VideoLink!
    };

    public static CommunityVideo CommunityVideoDtoToCommunityVideo ( CommunityVideoDto communityVideoDto, CommunityVideo communityVideo ) {
        if ( communityVideoDto.VideoLink != null ) {
            communityVideo.VideoLink = communityVideoDto.VideoLink;
        }
        if ( communityVideoDto.VideoTitle != null ) {
            communityVideo.VideoTitle = communityVideoDto.VideoTitle;
        }
        if ( communityVideoDto.VideoDescription != null ) {
            communityVideo.VideoDescription = communityVideoDto.VideoDescription;
        }
        return communityVideo;
    }
}