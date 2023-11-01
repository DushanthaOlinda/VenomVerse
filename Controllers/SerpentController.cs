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
    [HttpGet("Serpent")]
    public async Task<ActionResult<IEnumerable<SerpentDto>>> GetAllSerpents()
    {
        if ( _context.Serpent == null ) return NotFound();
        // return await _context.Serpent.Select( x=>SerpentToSerpentDto(x)).ToListAsync();
        return await _context.Serpent.Select(x => Serpent.CreateSerpentDto(
            x,
            _context.SerpentInstruction.Where(p => p.SerpentId == x.SerpentId).Select(si => si.InstructionToInstructionDto()).ToList().ToList()
        )).ToListAsync();
    }

    // view selected serpent
    [HttpGet("Serpent/{id}")]
    public async Task<ActionResult<SerpentDto>> GetSerpentDetail(long id)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpentDetail =  await _context.Serpent.FindAsync(id);
        if ( serpentDetail == null ) return NotFound();
        var serpentInstructions = _context.SerpentInstruction.Where(p=> p.SerpentId == serpentDetail.SerpentId).Select(si => si.InstructionToInstructionDto()).ToList();
        // return SerpentToSerpentDto(serpentDetail);
        return Serpent.CreateSerpentDto(serpentDetail, serpentInstructions);
    }

    // update serpent details
    [HttpPut("Serpent/{id}")]
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
    [HttpPost("Serpent")]
    public async Task<ActionResult<SerpentDto>> PostSerpent(SerpentDto serpentDto)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpent = Serpent.SerpentDtoToSerpent(serpentDto);
        _context.Serpent.Add(serpent);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetSerpentDetail", new { id = serpentDto.SerpentId}, serpentDto );
    }



    // add new instruction for a serpent
    [HttpPost("SerpentInstruction")]
    public async Task<ActionResult> PostSerpentInstruction(SerpentInstructionDto serpentInstructionDto)
    {
        if ( _context.SerpentInstruction == null ) return NotFound();
        var serpent = SerpentInstruction.InstructionDtoToInstruction(serpentInstructionDto);
        _context.SerpentInstruction.Add(serpent);
        await _context.SaveChangesAsync();
        return CreatedAtAction( "GetSerpentDetail", new { id = serpentInstructionDto.SerpentId}, serpentInstructionDto );
    }

    // delete instruction for a serpent
    [HttpDelete("SerpentInstruction")]
    public async Task<IActionResult> DeleteInstruction(long id)
    {
        if (_context.SerpentInstruction == null) return NotFound();
        var serpentInstruction = await _context.SerpentInstruction.FindAsync(id);
        if (serpentInstruction == null) return NotFound();

        _context.SerpentInstruction.Remove(serpentInstruction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // edit instruction for a serpent
    [HttpPut("EditInstruction/{id}")]
    public async Task<IActionResult> EditQuizDetail(long id, SerpentInstructionDto serpentInstructionDto)
    {
        if (id != serpentInstructionDto.SerpentInstructionId)
        {
            return BadRequest();
        }
        if ( _context.SerpentInstruction == null ) return NotFound();
        var instruction = await _context.SerpentInstruction.FindAsync(id);
        if (instruction==null) 
        {
            return NotFound();
        } 
        else 
        {
            instruction = SerpentInstruction.InstructionDtoToInstruction(serpentInstructionDto);
        }
        _context.Entry(instruction).State = EntityState.Modified;
        try 
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InstructionExists(id))
            {
                return NotFound();
            }

            throw;
        }
        return NoContent();
    }

    // add common instructions - done with null serpentID
    // delete commmon instructions - done with null serpentID


    // view emergency contacts
    [HttpGet("EmergencyContact")]
    public async Task<ActionResult<IEnumerable<EmergencyContactDto>>> GetAllEmergencyContacts()
    {
        if ( _context.EmergencyContact == null ) return NotFound();
        return await _context.EmergencyContact.Select(x => EmergencyContact.EmergencyContactToEmergencyContactDto(x)).ToListAsync();
    }
    
    // add new emergency contact
    [HttpPost("EmergencyContact")]
    public async Task<ActionResult> AddEmergencyContact(EmergencyContactDto emergencyContactDto)
    {
        if ( _context.EmergencyContact == null ) return NotFound();
        var serpent = EmergencyContact.EmergencyContactDtoToEmergencyContact(emergencyContactDto);
        _context.EmergencyContact.Add(serpent);
        await _context.SaveChangesAsync();
        return Ok();
        // return CreatedAtAction( "GetEmergencyDetails", new { id = emergencyContactDto.EmergencyContactId}, emergencyContactDto );
    }

    // delete an emergency contact
    [HttpDelete("EmergencyContact")]
    public async Task<IActionResult> DeleteEmergencyContact(long id)
    {
        if (_context.EmergencyContact == null) return NotFound();
        var emergencyContact = await _context.EmergencyContact.FindAsync(id);
        if (emergencyContact == null) return NotFound();

        _context.EmergencyContact.Remove(emergencyContact);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    // Delete a serpent
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSerpent(long id)
    {
        if ( _context.Serpent == null ) return NotFound();
        var serpent = await _context.Serpent.FindAsync(id);
        if ( serpent == null ) return NotFound();
        if ( _context.SerpentInstruction == null ) return NotFound();
        
        // delete instructions for the relevant serpent
        var serpentInstruction = await _context.SerpentInstruction.Where(instruction => instruction.SerpentId == id ).ToListAsync();
        foreach ( var instruction in serpentInstruction) {
            _context.SerpentInstruction.Remove(instruction);
        }

        _context.Serpent.Remove(serpent);
        await _context.SaveChangesAsync();
        return NoContent();
    }


    private bool SerpentExists(long id)
    {
        return (_context.Serpent?.Any(e => e.SerpentId == id)).GetValueOrDefault();
    }

    private bool InstructionExists(long id)
    {
        return (_context.SerpentInstruction?.Any(e => e.SerpentInstructionId == id)).GetValueOrDefault();
    }
    
}