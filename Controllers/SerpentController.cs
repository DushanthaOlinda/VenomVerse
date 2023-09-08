using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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

    // GET: Serprnt
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SerpentDto>>> GetAllSerpents()
    {
        if ( _context.Serpent == null ) return NotFound();
        // return await _context.Serpent.Select( x=>SerpentToSerpentDto(x)).ToListAsync();
        return await _context.CommunityPost.Select(x => CreateSerpentDto(
            x,
            _context.SerpentInstruction.Where(p => p.SerpentId == x.SerpentId).ToList()
        ).ToListAsync();
    }

    // GET: Serpent/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<SerpentDto>> GetSerpentDetail(long id)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpentDetail =  await _context.Serpent.FindAsync(id);
        if ( serpentDetail == null ) return NotFound();
        var serpentInstructoins = _context.SerpentInstruction.Where(p=> p.SerpentId == serpentDetail.SerpentId).ToList();
        // return SerpentToSerpentDto(serpentDetail);
        return CreateSerpentDto(serpentDetail, serpentInstructoins);
    }

    private static SerpentDto CreateSerpentDto(
        Serpent serpentDetail, IEnumerable<SerpentInstruction> serpentInstructions
    ){
        // var serpent = new SerpentDto(
        //     serpentDetail.SerpentId,
        //     serpentDetail.ScientificName,
        //     serpentDetail.EnglishName,
        //     serpentDetail.SinhalaName,
        //     serpentDetail.SerpentMedia,
        //     serpentDetail.Venomous,
        //     serpentDetail.Family,
        //     serpentDetail.SubFamily,
        //     serpentDetail.Genus,
        //     serpentDetail.SpecialNote!,
        //     serpentDetail.SpecialNoteSinhala!,
        //     serpentDetail.Description,
        //     serpentDetail.DescriptionSinhala,
        //     serpentInstructions.Select(i => i.InstructionToInstructionDto()).ToList()
        // )
        // {
        //     SerpentId = serpentDetail.SerpentId
        // };

        // return serpent;

        var serpent = new SerpentDto( 
            serpentDetail.SerpentId,
            serpentDetail.ScientificName,
            serpentDetail.EnglishName,
            serpentDetail.SinhalaName,
            serpentDetail.SerpentMedia,
            serpentDetail.Venomous,
            serpentDetail.Family,
            serpentDetail.SubFamily,
            serpentDetail.Genus,
            serpentDetail.SpecialNote,
            serpentDetail.SpecialNoteSinhala,
            serpentDetail.Description,
            serpentDetail.DescriptionSinhala,
            serpentInstructions

        );
    }

    // PUT: Serpent/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSerpent(long id, SerpentDto serpentDto)
    {
        if ( id != serpentDto.SerpentId ) return BadRequest();
        var serpent = SerpentDtoToSerpent(serpentDto);
        _context.Entry(serpent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SerpentExists(id))
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


    // POST: Serpent
    [HttpPost]
    public async Task<ActionResult<SerpentDto>> PostSerpent(SerpentDto serpentDto)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpent = SerpentDtoToSerpent(serpentDto);
        _context.Serpent.Add(serpent);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetSerpent", new { id = serpentDto.SerpentId}, serpentDto );
    }


    // DELETE: Serpent/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSerpent(long id)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpent = await _context.Serpent.FindAsync(id);
        if ( serpent == null ) return NotFound();
        _context.Serpent.Remove(serpent);
        await _context.SaveChangesAsync();
        return NoContent();
    }


    private bool SerpentExists(long id)
    {
        return (_context.Serpent?.Any(e => e.SerpentId == id)).GetValueOrDefault();
    }
    

    // ============================================================================
    // ============================ DTO CONVERSION ================================
    // ============================================================================

    // private static SerpentDto SerpentToSerpentDto (Serpent serpent, ) =>
    //     new SerpentDto
    //     {
    //         SerpentId = serpent.SerpentId,
    //         ScientificName = serpent.ScientificName,
    //         EnglishName = serpent.EnglishName,
    //         SinhalaName = serpent.SinhalaName,
    //         SerpentMedia = serpent.SerpentMedia,
    //         Venomous = serpent.Venomous,
    //         Family = serpent.Family,
    //         SubFamily = serpent.SubFamily,
    //         Genus = serpent.Genus,
    //         SpecialNote = serpent.SpecialNote,
    //         SpecialNoteSinhala = serpent.SpecialNoteSinhala,
    //         Description = serpent.Description,
    //         DescriptionSinhala = serpent.DescriptionSinhala,
    //         Instructions = null
    //     };

    private static Serpent SerpentDtoToSerpent (SerpentDto serpent) =>
        new()
        {
            SerpentId = serpent.SerpentId,
            ScientificName = serpent.ScientificName,
            EnglishName = serpent.EnglishName,
            SinhalaName = serpent.SinhalaName,
            SerpentMedia = serpent.SerpentMedia,
            Venomous = serpent.Venomous,
            Family = serpent.Family,
            SubFamily = serpent.SubFamily,
            Genus = serpent.Genus,
            SpecialNote = serpent.SpecialNote,
            SpecialNoteSinhala = serpent.SpecialNoteSinhala,
            Description = serpent.Description,
            DescriptionSinhala = serpent.DescriptionSinhala
        };
        
}