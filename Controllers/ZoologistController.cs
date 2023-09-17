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
    public async Task<ActionResult<CommunityResearch>> PostCommunityResearch(ResearchDto research)
    {
        if (_context.CommunityResearch == null)
        {
            return Problem("Entity set 'VenomVerseContext.CommunityResearch'  is null.");
        }
        
        //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
        _context.CommunityResearch.Add(CommunityResearch.ResearchDtoToResearch(research));

        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCommunityResearch", new { id = research.CommunityResearchId }, research);
    }


    // HANDLE LEARNING MATERIALS
    



    

    




    private bool ZoologistExists(long id)
    {
        return (_context.Zoologist?.Any(zoologist => zoologist.ZoologistId == id)).GetValueOrDefault();
    }

    private bool ArticleExists(long id)
    {
        return (_context.CommunityArticle?.Any(article => article.CommunityArticleId == id)).GetValueOrDefault();
    }

}