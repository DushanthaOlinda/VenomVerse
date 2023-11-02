using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemFeedbackController : ControllerBase
{
    private readonly VenomVerseContext _context;

    public SystemFeedbackController(VenomVerseContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> AddRating(long userId, float ratingCount, string ratingFeedback)
    {
        if (_context.ApplicationFeedback == null)
        {
            return NotFound();
        }
        
        var user = await _context.UserDetail.FindAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var newFeedback = new ApplicationFeedback
        {
            UserId = userId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Rating = ratingCount,
            Feedback = ratingFeedback
        };

        _context.ApplicationFeedback.Add(newFeedback);
        await _context.SaveChangesAsync();
        return Ok("Feedback Added Successfully");
    }


    [HttpGet]
    public async Task<ActionResult<List<ApplicationFeedback>>> GetRating()
    {
        if ( _context.ApplicationFeedback == null )
        {
            return NotFound();
        }
        var feedbacks = await _context.ApplicationFeedback.ToListAsync();

        return feedbacks;
    }
}