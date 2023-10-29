using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AdminController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public AdminController(VenomVerseContext context)
    {
        _context = context;
    }

    
    // view requested articles
    [HttpGet("Dashboard")]
    public async Task<ActionResult> Dashboard()
    {
        
        return Ok
        (
            new
            {
                count_pending_post = 2,
                count_approved_post = 12,

                count_requested_services = 25,
                count_completed_services = 15,

                count_pending_catcher_req = 1,
                count_pending_zoologist_req = 0,
                count_scanned_images = 104,
                count_quiz_attempted = 30,

                bar_new_registers = new List<int> [40,2,4,1],
                pie_scanned_images = new Dictionary< string, int > {
                    { "Rat snake", 1 },
                    { "Cobra", 15 },
                    { "Indian Python", 2 },
                    { "Sand Boa", 3 },
                    { "Hump Nosed Viper", 1 },
                    { "Whip Snake", 1 },
                    { "Sri Lankan Krait", 5 },
                    { "Common Krait", 10 },
                    { "Russell’s Viper", 9 },
                    { "Saw-scaled Viper", 5 }
                }
            }
        );
    }


}