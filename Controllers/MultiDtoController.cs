using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;
[ApiController]
[Route("[controller]")]

public class MultiDtoController : ControllerBase
{
    private readonly VenomVerseContext _context;

    public MultiDtoController(VenomVerseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<(List<UserDetail> users, List<Serpent> snakes)> GetAllUsers()
    {
        // if (_context.UserDetail == null) return NotFound();
        var users = await _context.UserDetail.ToListAsync();
        var snakes = await _context.Serpent.ToListAsync();
        return (users, snakes);
    }
}