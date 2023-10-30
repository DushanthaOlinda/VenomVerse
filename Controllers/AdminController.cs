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

    
    // for dashboard page
    [HttpGet("Dashboard")]
    public async Task<ActionResult> Dashboard()
    {
        var pending_posts = _context.CommunityPost.Where(p => p.PostStatus == (int)PostStatus.PendingApproval).ToList();
        var approved_posts = _context.CommunityPost.Where(p => p.PostStatus == (int)PostStatus.Posted).ToList();

        var requested_services = _context.RequestService.Where(s => s.CompleteFlag==false).ToList();
        var completed_services = _context.RequestService.Where(s => s.CompleteFlag==true).ToList();

        var pending_catcher_req = _context.Catcher.Where(c => c.ApprovedFlag==false).ToList();
        var pending_zoologist_req = _context.Zoologist.Where(z => z.ApprovedDate==null).ToList();
        var scanned_images = _context.ScannedImage.ToList();
        var quiz_attempted = _context.QuizAttempt.ToList();
        
        return Ok
        (
            new
            {
                count_pending_post = pending_posts.Count,
                count_approved_post = approved_posts.Count,

                count_requested_services = requested_services.Count,
                count_completed_services = completed_services.Count,

                count_pending_catcher_req = 1,
                count_pending_zoologist_req = 0,
                count_scanned_images = 104,
                count_quiz_attempted = 30,

                bar_new_registers = new List<int> {40,2,4,1},
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