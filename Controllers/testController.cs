using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]

[Route("[controller]")]

public class testController : ControllerBase{
    private VenomVerseContext _context;

    public testController(VenomVerseContext context)
        {
            _context = context;
        }

        // GET: api/VenomVerseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenomVerseItem>>> GetVenomVerseItems()
        {
          if (_context.VenomVerseItems == null)
          {
              return NotFound();
          }
            return await _context.VenomVerseItems.ToListAsync();
        }

}