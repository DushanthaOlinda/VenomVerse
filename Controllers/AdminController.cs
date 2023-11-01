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


    // activate/deactivate user account
    [HttpPut("ChangeStatusUser/{uid}")]
    public async Task<IActionResult> ChangeStatusUser(long uid, bool activeStatus)
    {
        if ( _context.UserDetail == null )
        {
            return NotFound();
        }

        var updating_user = await _context.UserDetail.FindAsync(uid);

        if ( updating_user==null )
        {
            return NotFound();
        }

        if ( activeStatus == true )
        {
            updating_user.AccountStatus = "Active";
        }
        else
        {
            updating_user.AccountStatus = "Deactive";
        }

        _context.Entry(updating_user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok("StatusModified");
    }


    // provide/remove catcher privillege
    [HttpPut("CatcherPrivillege/{uid}")]
    public async Task<IActionResult> CatcherPrivillege(long uid, bool activeStatus)
    {
        if ( _context.UserDetail == null )
        {
            return NotFound();
        }

        if ( _context.Catcher == null )
        {
            return NotFound();
        }

        var updating_user = await _context.UserDetail.FindAsync(uid);

        if ( updating_user==null )
        {
            return NotFound();
        }

        if ( activeStatus == true )
        {
            updating_user.CatcherPrivilege = true;
            _context.Entry(updating_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            // _context.Entry(updating_user).State = EntityState.Modified;
            // await _context.SaveChangesAsync();

            // check whether catcher exists
            var existing_catcher = await _context.Catcher.FindAsync(uid);

            // if does not exist enter detils as catcher
            if ( existing_catcher == null )
            {

                var catcherEntry = new Catcher
                {
                    ReqId = updating_user.UserDetailId,
                    ReqCatcher = updating_user.UserDetailId,
                    Availability=true,
                    ChargingFee=0,
                    RequestedDateTime=DateTime.Now,
                    CatcherEvidence=null,
                    Description=null,
                    SpecialNote=null,
                    ApprovedPersonIdOne=null, ApprovedDateOne=null, ApprovedStatusOne=false,
                    ApprovedPersonIdTwo=null, ApprovedDateTwo=null, ApprovedStatusTwo=false,
                    ApprovedPersonIdThree=null, ApprovedDateThree=null, ApprovedStatusThree=false,
                    JoinedDate=DateOnly.FromDateTime(DateTime.Now),
                    ApprovedFlag=true
                };
                _context.Catcher.Add(catcherEntry);
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            updating_user.CatcherPrivilege = false;
            _context.Entry(updating_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Ok("StatusModified");
    }


    // provide/remove zoologist privillege
    [HttpPut("ZoologistPrivillege/{uid}")]
    public async Task<IActionResult> ZoologistPrivillege(long uid, bool activeStatus, long sysid)
    {
        if ( _context.UserDetail == null )
        {
            return NotFound();
        }

        if ( _context.Zoologist == null )
        {
            return NotFound();
        }

        var updating_user = await _context.UserDetail.FindAsync(uid);

        if ( updating_user==null )
        {
            return NotFound();
        }

        if ( activeStatus == true )
        {
            updating_user.ZoologistPrivilege = true;
            _context.Entry(updating_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            // _context.Entry(updating_user).State = EntityState.Modified;
            // await _context.SaveChangesAsync();

            // check whether catcher exists
            var existing_zoologist = await _context.Zoologist.FindAsync(uid);

            // if does not exist enter detils as catcher
            if ( existing_zoologist == null )
            {

                var zoologistEntry = new Zoologist
                {
                    ZoologistId = updating_user.UserDetailId,
                    Description = null,
                    SpecialNote=null,
                    RequestedDateTime=DateTime.Now,
                    Status=1,
                    ApprovedPersonId=sysid,
                    ApprovedDate=DateOnly.FromDateTime(DateTime.Now),
                    Certificate="https://firebasestorage.googleapis.com/v0/b/venomverse-ba46f.appspot.com/o/ScannedImages%2F2023-10-31%2014%3A59%3A33.805464Z.png?alt=media&token=282a65c1-66f7-42ad-ab1b-367fd0604265",
                    DegreeName="Assigned by the Admin Panel",
                    University="Assigned by the Admin Panel",
                    GraduatedYear="Assigned by the Admin Panel",
                    SpecialDetails="Assigned by the Admin Panel"
                };
                _context.Zoologist.Add(zoologistEntry);
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            updating_user.ZoologistPrivilege = false;
            _context.Entry(updating_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Ok("StatusModified");
    }


    // provide/remove com admin privillege
    [HttpPut("ComAdminPrivillege/{uid}")]
    public async Task<IActionResult> ComAdminPrivillege(long uid, bool activeStatus)
    {
        if ( _context.UserDetail == null )
        {
            return NotFound();
        }

        if ( _context.CommunityAdmin == null )
        {
            return NotFound();
        }

        var updating_user = await _context.UserDetail.FindAsync(uid);

        if ( updating_user==null )
        {
            return NotFound();
        }

        if ( activeStatus == true )
        {
            updating_user.CommunityAdminPrivilege = true;
            _context.Entry(updating_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            // _context.Entry(updating_user).State = EntityState.Modified;
            // await _context.SaveChangesAsync();

            // check whether catcher exists
            var existing_com_admin = await _context.CommunityAdmin.FindAsync(uid);

            // if does not exist enter detils as catcher
            if ( existing_com_admin == null )
            {

                var comAdminEntry = new CommunityAdmin
                {
                    CommunityAdminId = updating_user.UserDetailId,
                    JoinedDate=DateOnly.FromDateTime(DateTime.Now)
                };
                _context.CommunityAdmin.Add(comAdminEntry);
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            updating_user.CommunityAdminPrivilege = false;
            _context.Entry(updating_user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Ok("StatusModified");
    }

}