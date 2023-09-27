using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CommunityAdminController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public CommunityAdminController(VenomVerseContext context)
    {
        _context = context;
    }

    
    // view zoology requests

    [HttpGet("ToBeZoologistRequests")]
    public async Task<ActionResult<IEnumerable<ZoologistRequestsDto>>> GetZoologistRequests()
    {
        if (_context.Zoologist == null)
        {
            return NoContent();
        }

        var pendingList = await _context.Zoologist.Where(zoologist => zoologist.Status == 1).ToListAsync();

        var results = new List<ZoologistRequestsDto>();

        foreach (var zoologist in pendingList)
        {
            try
            {
                var evidence = await _context.RequestToBeZoologistEvidence
                    .FirstOrDefaultAsync(zoologistEvidence => zoologistEvidence.ZoologistId == zoologist.ZoologistId);

                var userDetail = await _context.UserDetail.FindAsync(zoologist.ZoologistId);

                if (evidence == null)
                {
                    throw new ApplicationException("No evidence Found");
                }

                if (userDetail == null)
                {
                    throw new ApplicationException("No relevant user Account found");
                }

                results.Add(Zoologist.ToZoologistRequestsDto(zoologist, userDetail, evidence));
            }
            catch (ApplicationException ex)
            {
                var errorResponse = new CustomError
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        return results;
    }
    

    // approve or decline zoology requests
    [HttpPut("ZoologistRequest/{zoologistId}")]
    public async Task<ActionResult<ObjectResult>> ZoologistRequestRes(int zoologistId, int comAdminId, int approvalState)
    {
        if (_context.Zoologist == null)
        {
            return NoContent();
        }

        var comAdmin = await _context.CommunityAdmin.FindAsync(comAdminId);
        var zoologist = await _context.Zoologist.FindAsync(zoologistId);
        try
        {
            if (comAdmin == null)
            {
                throw new ApplicationException("Community Admin Not Found");
            }

            if (zoologist == null)
            {
                throw new AggregateException("Zoologist Not Found");
            }
        }
        catch (ApplicationException ex)
        {
            var errorResponse = new CustomError
            {
                ErrorCode = "500",
                ErrorMessage = ex.Message
            };
            return StatusCode(500, errorResponse);
        }

        zoologist.ApprovedDate = new DateOnly();
        zoologist.ApprovedPersonId = comAdmin.CommunityAdminId;
        zoologist.Status = 2;
        
        _context.Entry(zoologistId).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var errorResponse = new CustomError
            {
                ErrorCode = "500",
                ErrorMessage = "Try Again"
            };
            return StatusCode(500, errorResponse);
            
        }

        return NoContent();
    }

    // view requested post 
    [HttpGet("RequestedPosts")]
    public async Task<ActionResult<List<CommunityPost>>> GetRequestedPosts()
    {
        if (_context.CommunityPost == null)
        {
            return NoContent();
        }
        var posts = await _context.CommunityPost.Where(post => post.PostStatus == 0).ToListAsync();

        if (posts == null)
        {
            return NotFound();
        }

        return posts;
    }


    // approve, decline posts

    [HttpPut("PostAction/{postId}")]
    public async Task<ActionResult<ObjectResult>> PostAction(int postId, int postStatus, int comAdminId)
    {
        if (_context.CommunityPost == null)
        {
            return NoContent();
        }
        
        var post = await _context.CommunityPost.FindAsync(postId);

        if (post == null)
        {
            return NotFound();
        }
        
        post.PostStatus = postStatus;
        post.ApprovedAdmin = comAdminId;
        
        _context.Entry(post).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var errorResponse = new CustomError
            {
                ErrorCode = "500",
                ErrorMessage = "Try Again"
            };
            return StatusCode(500, errorResponse);
            
        }

        return NoContent();
        
    }
    


    // view declined posts

    [HttpGet("DeclinedPosts")]
    public async Task<ActionResult<List<CommunityPost>>> DeclinedPosts()
    {
        if (_context.CommunityPost == null)
        {
            return NoContent();
        }

        var declinedPosts = await _context.CommunityPost.Where(post => post.PostStatus == (int)PostStatus.Hidden)
            .ToListAsync();

        return declinedPosts;
    }

    // view complaints ( fake request service )

    [HttpGet("Complaints")]
    public async Task<ActionResult<List<ReportDto>>> ViewComplaints()
    {
        if (_context.CommunityPostReport == null)
        {
            return NoContent();
        }

        var reports = await _context.CommunityPostReport.Where(report => report.Response == null).ToListAsync();

        return reports.Select(report => report.ReportToReportDto()).ToList();
    }

    // actions on complaints - ban accounts
    

    // activate banned accounts


    // deactivate banned accounts -> send notification





    // private static ZoologistRequestsDto ToZoologistRequestsDto(Zoologist zoologist, UserDetail userDetail,
    //     RequestToBeZoologistEvidence evidence)
    // {
    //     var zoologistReq = new ZoologistRequestsDto()
    //     {
    //         FullName = userDetail.FirstName + " " + userDetail.LastName,
    //         ZoologistId = zoologist.ZoologistId,
    //         Description = zoologist.Description,
    //         SpecialNote = zoologist.SpecialNote,
    //         RequestedDateTime = zoologist.RequestedDateTime,
    //         RequestToBeZoologistEvidenceId = evidence.RequestToBeZoologistEvidenceId,
    //         DegreeName = evidence.DegreeName,
    //         University = evidence.University,
    //         GraduatedYear = evidence.GraduatedYear,
    //         SpecialDetails = evidence.SpecialDetails
    //     };

    //     return zoologistReq;
    // }

}