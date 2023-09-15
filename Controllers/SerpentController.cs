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

    // view all serpents
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

    // view selected serpent
    [HttpGet("{id}")]
    public async Task<ActionResult<SerpentDto>> GetSerpentDetail(long id)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpentDetail =  await _context.Serpent.FindAsync(id);
        if ( serpentDetail == null ) return NotFound();
        var serpentInstructions = _context.SerpentInstruction.Where(p=> p.SerpentId == serpentDetail.SerpentId).ToList();
        // return SerpentToSerpentDto(serpentDetail);
        return Serpent.CreateSerpentDto(serpentDetail, serpentInstructions);
    }

    // update serpent details
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


    // insert a new serpent
    [HttpPost]
    public async Task<ActionResult<SerpentDto>> PostSerpent(SerpentDto serpentDto)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpent = Serpent.SerpentDtoToSerpent(serpentDto);
        _context.Serpent.Add(serpent);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetSerpentDetail", new { id = serpentDto.SerpentId}, serpentDto );
    }



    // add new instruction for a serpent


    // delete instruction for a serpent


    // add common instructions


    // delete commmon instructions


    // view emergency contacts

    
    // add new emergency contact


    // delete an emergency contact


    // Delete a serpent - 
    //delete insructions too
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSerpent(long id)
    {
        if ( _context.Serpent == null ) return NotFound();
        // delete instrucctions before deleting the serpent
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