using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ZoologistController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public ZoologistController(VenomVerseContext context)
    {
        _context = context;
    }

    
    // view requested articles
    [HttpGet("ViewArticleApproveRequests")]
    public async Task<ActionResult> GetAllArticleApproveRequests()
    {
        if (_context.CommunityArticle == null)
        {
            return NotFound();
        }
        
        var pendingArticleList = await _context.CommunityArticle.Where(article => article.ArticleStatus == (int)ArticleStatus.PendingApproval).ToListAsync();
        if (pendingArticleList != null)
        {
            // return the requested article list
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    // view selected pending article
    [HttpGet("getArticle/{id}")]
    public async Task<ActionResult<CommunityArticle>> GetPendingArticle(int id)
    {
        if (_context.CommunityArticle == null)
        {
            return NoContent();
        }

        var article = await _context.CommunityArticle.FindAsync(id);
        if (article == null)
        {
            return NoContent();
        }

        return article;
    }

    // approve or decline requested articles
    [HttpPut("ArticleReqResponse/{articleReqId}")]
    public async Task<ActionResult<ServiceDto>> AcceptRejectArticle(long zoologist_id, long article_id, bool response)
    {
        // if (response == false)
        // {
        //     // do something to show this request is rejected
        // }

        var article_req = await _context.CommunityArticle.FindAsync(article_id);
        if (article_req == null)
        {
            return NotFound();
        }

        if (response != true) 
        {
            article_req.ArticleStatus = (int)ArticleStatus.Rejected;
            article_req.ApprovedUserId = zoologist_id;
            // Diplay pop up
            return NoContent();
        }
        article_req.ArticleStatus = (int)ArticleStatus.Approved;
        article_req.ApprovedUserId = zoologist_id;
         // Diplay pop up

        _context.Entry(article_req).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArticleExists(article_id))
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


    // publish research -> learn content controller
    [HttpPost]
    public async Task<ActionResult<CommunityResearch>?> PostCommunityResearch(ResearchDto research)
    {
        if (_context.CommunityResearch == null)
        {
            return Problem("Entity set 'VenomVerseContext.CommunityResearch'  is null.");
        }
        
        //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
        _context.CommunityResearch.Add(CommunityResearch.ResearchDtoToResearch(research));

        await _context.SaveChangesAsync();
        return null;
        // return CreatedAtAction("GetCommunityResearch", new { id = research.CommunityResearchId }, research);
    }


    // HANDLE LEARNING MATERIALS
    
    // view to be zoologist requests
    [HttpGet("ViewRequestsToBecomeZoologist")]
    public async Task<ActionResult<List<ZoologistRequestsDto>>> GetAllZoologistRequests()
    {
        //pass user account
        if (_context.Zoologist == null)
        {
            return NotFound();
        }
        
        var pendingZoologistList = await _context.Zoologist.Where(zr => zr.ApprovedDate == null).ToListAsync();
        if (pendingZoologistList != null)
        {
            return pendingZoologistList.Select(x =>
            {
                var userDetails = _context.UserDetail.Find(x.ZoologistId);
                return Zoologist.ToZoologistRequestsDto(x,userDetails);
            }).ToList();
        }
        else
        {
            return NotFound();
        }
    }

    // view selected to be zoologist requests
    [HttpGet("ViewToBeZoologistRequest/{reqid}")]
    public async Task<ActionResult<ZoologistRequestsDto>> GetToBeZoologistRequestDetails(long reqid)
    {
        if ( _context.Zoologist == null ) return NotFound();

        var zoologistReq = await _context.Zoologist.FindAsync(reqid);
        if ( zoologistReq==null ) return NoContent();

        var user = await _context.UserDetail.FindAsync(zoologistReq.User);

        return Zoologist.ToZoologistRequestsDto(zoologistReq, user);
    }


    // accept or decline
    [HttpGet("RespondRequestsToBecomeZoologist")]
    public async Task<ActionResult> RespondRequestsToBecomeZoologist(long zoologistId, long approvedUser, bool approveFlag)
    // public async Task<ActionResult<List<ZoologistReqDto>>> ResponseRequestsToBecomeZoologist(request karapu Zoologist, approve karana Zoologist, approve krada ndda kyana eka true or false)
    {
        if (_context.Zoologist == null)
        {
            return NotFound();
        }
        if (_context.UserDetail == null)
        {
            return NotFound();
        }
        var approvingZoologist = await _context.Zoologist.Where(z => z.ZoologistId == zoologistId).OrderByDescending(zoologist => zoologist.ZoologistId).FirstOrDefaultAsync();
        if ( approvingZoologist != null )
        {
            if ( approveFlag == true )
            {
                approvingZoologist.ApprovedPersonId = approvedUser;
                approvingZoologist.ApprovedDate = new DateOnly();
                approvingZoologist.Status = 1;
            }
            else
            {
                approvingZoologist.ApprovedPersonId = approvedUser;
                approvingZoologist.ApprovedDate = new DateOnly();
                approvingZoologist.Status = 0;
            } 
            _context.Entry(approvingZoologist).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var privillaging_user = await _context.UserDetail.FindAsync(zoologistId);
            if ( privillaging_user != null )
            {
                privillaging_user.ZoologistPrivilege = true;
                _context.Entry(privillaging_user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        else
        {
            return NotFound();
        }
        return NoContent(); 
    }
    




    private bool ZoologistExists(long id)
    {
        return (_context.Zoologist?.Any(zoologist => zoologist.ZoologistId == id)).GetValueOrDefault();
    }

    private bool ArticleExists(long id)
    {
        return (_context.CommunityArticle?.Any(article => article.CommunityArticleId == id)).GetValueOrDefault();
    }

}