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
        var pending_posts = await _context.CommunityPost.Where(p => p.PostStatus == (int)PostStatus.PendingApproval).ToListAsync();
        var approved_posts = await _context.CommunityPost.Where(p => p.PostStatus == (int)PostStatus.Posted).ToListAsync();

        var requested_services = await _context.RequestService.Where(s => s.CompleteFlag==false).ToListAsync();
        var completed_services = await _context.RequestService.Where(s => s.CompleteFlag==true).ToListAsync();

        var pending_catcher_req = await _context.Catcher.Where(c => c.ApprovedFlag==false).ToListAsync();
        var pending_zoologist_req = await _context.Zoologist.Where(z => z.ApprovedDate==null).ToListAsync();
        var scanned_images = await _context.ScannedImage.ToListAsync();
        var quiz_attempted = await _context.QuizAttempt.ToListAsync();

        var users =  await _context.UserDetail.ToListAsync();
        var zoologists =  await _context.UserDetail.ToListAsync();
        var catchers =  await _context.UserDetail.ToListAsync();
        var com_admins =  await _context.UserDetail.ToListAsync();

        var snake0 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 0).ToListAsync();
        var snake1 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 1).ToListAsync();
        var snake2 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 2).ToListAsync();
        var snake3 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 3).ToListAsync();
        var snake4 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 4).ToListAsync();
        var snake5 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 5).ToListAsync();
        var snake6 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 6).ToListAsync();
        var snake7 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 7).ToListAsync();
        var snake8 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 8).ToListAsync();
        var snake9 = await _context.ScannedImage.Where(sc => sc.PredictedSerpentType == 9).ToListAsync();
        
        return Ok
        (
            new
            {
                count_pending_post = pending_posts.Count,
                count_approved_post = approved_posts.Count,

                count_requested_services = requested_services.Count,
                count_completed_services = completed_services.Count,

                count_pending_catcher_req = pending_catcher_req.Count,
                count_pending_zoologist_req = pending_zoologist_req.Count,
                count_scanned_images = scanned_images.Count,
                count_quiz_attempted = quiz_attempted.Count,

                bar_new_registers = new List<int> { users.Count, zoologists.Count, catchers.Count, com_admins.Count },
                pie_scanned_images = new Dictionary< string, int > {
                    { "Rat snake", snake0.Count },
                    { "Cobra", snake1.Count },
                    { "Indian Python", snake2.Count },
                    { "Sand Boa", snake3.Count },
                    { "Hump Nosed Viper", snake4.Count },
                    { "Whip Snake.Count", snake5.Count },
                    { "Sri Lankan Krait", snake6.Count },
                    { "Common Krait", snake7.Count },
                    { "Russell’s Viper", snake8.Count },
                    { "Saw-scaled Viper", snake9.Count }
                }
            }
        );
    }


}