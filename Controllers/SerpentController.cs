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

    // GET: Serprnt
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SerpentDto>>> GetAllSerpents()
    {
        if ( _context.Serpent == null ) return NotFound();
        // return await _context.Serpent.Select( x=>SerpentToSerpentDto(x)).ToListAsync();
        return await _context.Serpent.Select(x => Serpent.CreateSerpentDto(
            x,
            _context.SerpentInstruction.Where(p => p.SerpentId == x.SerpentId).ToList()
        )).ToListAsync();
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
        return Serpent.CreateSerpentDto(serpentDetail, serpentInstructoins);
    }

    // PUT: Serpent/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSerpent(long id, SerpentDto serpentDto)
    {
        if ( id != serpentDto.SerpentId ) return BadRequest();
        var serpent = Serpent.SerpentDtoToSerpent(serpentDto);
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
        var serpent = Serpent.SerpentDtoToSerpent(serpentDto);
        _context.Serpent.Add(serpent);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetSerpentDetail", new { id = serpentDto.SerpentId}, serpentDto );
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
    
}