using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class SerpentController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public SerpentController(VenomVerseContext context)
    {
        _context = context;
    }

    // GET: Serpent
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SerpentDto>>> GetAllSerpents() {
        if ( _context.Serpent == null ) return NotFound();
        return await _context.Serpent.Select( x=>SerpentToSerpentDto(x)).ToListAsync();
    }

    // GET: Serpent/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<SerpentDto>> GetSerpentDetail(long id) {
        if ( _context.Serpent == null ) return NotFound();
        var serpentDetail =  await _context.Serpent.FindAsync(id);
        if ( serpentDetail == null ) return NotFound();
        var serpentImage = File(serpentDetail.SerpentImage, "serpentImage/jpeg");
        // serpentDetail.SerpentImage = serpentImage;
        var serpentDto = SerpentToSerpentDto(serpentDetail);
        // serpentDto.SerpentImageFile = serpentImage;
        // serpentDto.SerpentImage =
        return serpentDto;
    }

    // PUT: Serpent/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSerpent(long id, SerpentDto serpentDto) {
        if ( id != serpentDto.SerpentId ) return BadRequest();
        if (_context.Serpent == null) return BadRequest();
        var serpent = await _context.Serpent.FindAsync(serpentDto.SerpentId);
        if ( serpent == null ) return NotFound();
        serpent = SerpentDtoToSerpent(serpentDto, serpent);
        _context.Entry(serpent).State = EntityState.Modified;
        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!SerpentExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }
        return NoContent();
    }


    // POST: Serpent
    [HttpPost]
    public async Task<ActionResult<SerpentDto>> PostSerpent([FromForm] SerpentDto serpentDto) {
        if (serpentDto.SerpentImageFile != null) {
            using (var memoryStream = new MemoryStream()) {
                await serpentDto.SerpentImageFile.CopyToAsync(memoryStream);
                serpentDto.SerpentImage = memoryStream.ToArray();
            }
        }
        if ( _context.Serpent == null ) return NotFound();
        var serpent = SerpentDtoToSerpent(serpentDto);
        _context.Serpent.Add(serpent);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetSerpentDetail", new { id = serpent.SerpentId }, serpent );
    }


    // DELETE: Serpent/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSerpent(long id) {
        if ( _context.Serpent == null ) return NotFound();
        var serpent = await _context.Serpent.FindAsync(id);
        if ( serpent == null ) return NotFound();
        _context.Serpent.Remove(serpent);
        await _context.SaveChangesAsync();
        return NoContent();
    }


    private bool SerpentExists(long id) {
        return (_context.Serpent?.Any(e => e.SerpentId == id)).GetValueOrDefault();
    }
    

    // ============================================================================
    // ============================ DTO CONVERSION ================================
    // ============================================================================

    private static SerpentDto SerpentToSerpentDto (Serpent serpent) => new SerpentDto {
        SerpentId = serpent.SerpentId,
        SerpentImage = serpent.SerpentImage,
        ScientificName = serpent.ScientificName,
        EnglishName = serpent.EnglishName,
        SinhalaName = serpent.SinhalaName,
        Venomous = serpent.Venomous,
        Family = serpent.Family,
        SubFamily = serpent.SubFamily,
        Genus = serpent.Genus,
        SpecialNote = serpent.SpecialNote,
        SpecialNoteSinhala = serpent.SpecialNoteSinhala,
        Description = serpent.Description,
        DescriptionSinhala = serpent.DescriptionSinhala,
        // SerpentImageFile = File(serpent.SerpentImage, "serpentImage/jpeg")
    };

    private static Serpent SerpentDtoToSerpent (SerpentDto serpent) => new Serpent {
        SerpentId = (long)serpent.SerpentId!,
        SerpentImage = serpent.SerpentImage!,
        ScientificName = serpent.ScientificName!,
        EnglishName = serpent.EnglishName!,
        SinhalaName = serpent.SinhalaName!,
        Venomous = serpent.Venomous,
        Family = serpent.Family!,
        SubFamily = serpent.SubFamily!,
        Genus = serpent.Genus!,
        SpecialNote = serpent.SpecialNote,
        SpecialNoteSinhala = serpent.SpecialNoteSinhala,
        Description = serpent.Description!,
        DescriptionSinhala = serpent.DescriptionSinhala!
    };

    public static Serpent SerpentDtoToSerpent ( SerpentDto serpentDto, Serpent serpent ) {
        if ( serpentDto.SerpentImage != null ) {
            serpent.SerpentImage = serpentDto.SerpentImage;
        }
        if ( serpentDto.ScientificName != null ) {
            serpent.ScientificName = serpentDto.ScientificName;
        }
        if ( serpentDto.EnglishName != null ) {
            serpent.EnglishName = serpentDto.EnglishName;
        }
        if ( serpentDto.SinhalaName != null ) {
            serpent.SinhalaName = serpentDto.SinhalaName;
        }
        if ( serpentDto.Venomous != serpent.Venomous ) {
            serpent.Venomous = serpentDto.Venomous;
        }
        if ( serpentDto.Family != null ) {
            serpent.Family = serpentDto.Family;
        }
        if ( serpentDto.SubFamily != null ) {
            serpent.SubFamily = serpentDto.SubFamily;
        }
        if ( serpentDto.Genus != null ) {
            serpent.Genus = serpentDto.Genus;
        }
        if ( serpentDto.SpecialNote != null ) {
            serpent.SpecialNote = serpentDto.SpecialNote;
        }
        if ( serpentDto.SpecialNoteSinhala != null ) {
            serpent.SpecialNoteSinhala = serpentDto.SpecialNoteSinhala;
        }
        if ( serpentDto.Description != null ) {
            serpent.Description = serpentDto.Description;
        }
        if ( serpentDto.DescriptionSinhala != null ) {
            serpent.DescriptionSinhala = serpentDto.DescriptionSinhala;
        }
        return serpent;
    }
}