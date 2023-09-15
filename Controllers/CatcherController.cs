using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CatcherController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public CatcherController(VenomVerseContext context)
    {
        _context = context;
    }
    // change availability 
    
    [HttpPut("changeAvailability/{id}")]
    public async Task<IActionResult> UpdateAvailability(long id, bool availability)
    {
        if (_context.Catcher == null)
        {
            return NotFound();
        }
        
        var catcher = await _context.Catcher.FindAsync(id);
        
        if (catcher == null)
        {
            return NotFound();
        }

        catcher.Availability = availability;
        
        _context.Entry(catcher).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CatcherExists(id))
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


    // view catcher requests
    [HttpGet("RequestsToBecomeCatcher")]
    public async Task<ActionResult<List<CatcherReqDto>>> GetAllCatcherRequests()
    {
        if (_context.Catcher == null)
        {
            return NotFound();
        }
        
        var pendingCatcherList = await _context.Catcher.Where(catcher => catcher.ApprovedFlag == false).ToListAsync();
        if (pendingCatcherList != null)
        {
            return pendingCatcherList.Select(x =>
            {
                var userDetails = _context.UserDetail.Find(x.CatcherId);
                return ToCatcherReqDto(x,userDetails);
            }).ToList();
        }
        else
        {
            return NotFound();
        }
    }

    // approve or decline catcher requests


    // view service notifications
    [HttpGet("GetServiceReqList")]
    public async Task<ActionResult<List<ServiceDto>>> GetServiceRequests()
    {
        // check if request services available
        if (_context.RequestService == null)
        {
            return NotFound();
        }

        // then get a list of request services where accept flag is false
        var serviceList = await _context.RequestService.Where(service => service.AcceptFlag == false).ToListAsync();

        // then map above list to serviceDto
        return serviceList.Select(service =>
        {
            // find image relevant to scanned image id in request service class 
            var image = _context.ScannedImage.Find(service.ScannedImage);
            return image == null ? ToServiceDto(service) : ToServiceDto(service, image);
        } ).ToList();
        
    }
    
    // approve or decline service 

    [HttpPut("ServiceReqResponse/{serviceReqId}")]
    public async Task<ActionResult<ServiceDto>> AcceptRejectService(long catcherId, long serviceReqId, bool response)
    {
        if (response == false)
        {
            // do something to show this request is rejected
        }

        var serviceReq = await _context.RequestService.FindAsync(serviceReqId);
        if (serviceReq == null)
        {
            return NotFound();
        }

        if (response != true) return NoContent();
        serviceReq.AcceptFlag = response;
        serviceReq.CatcherId = catcherId;
        
        _context.Entry(serviceReq).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceExists(serviceReqId))
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


    // complete service

    [HttpPut("CompleteServiceReq/{serviceReqId}")]
    public async Task<ActionResult<ServiceDto>> CompleteServiceRequest(long catcherId, long serviceReqId, string? feedback)
    {
        var serviceReq = await _context.RequestService.FindAsync(serviceReqId);
        if (serviceReq == null)
        {
            return NotFound();
        }

        try
        {
            if (serviceReq.AcceptFlag != true)
            {
                throw new ApplicationException("Service isn't accepted yet.");
            }
            else
            {
                if (serviceReq.CatcherId != catcherId)
                {
                    throw new ApplicationException("Catcher id isn't matched");
                }
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


        serviceReq.ServiceFeedback = feedback;
        serviceReq.CompleteFlag = true;
        _context.Entry(serviceReq).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceExists(serviceReqId))
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

    
    
    
    
    private static CatcherReqDto ToCatcherReqDto(Catcher catcher, UserDetail? userDetail)
    {
        // var userDetails = await _context.UserDetail.FindAsync(catcher.CatcherId);
        var fullName = userDetail!.FirstName + ' ' + userDetail.LastName;
        var newReq = new CatcherReqDto(
            catcher.CatcherId,
            fullName, 
            catcher.CatcherEvidence, 
            catcher.Description, 
            catcher.SpecialNote, 
            catcher.ApprovedPersonIdOne, 
            catcher.ApprovedDateOne, 
            catcher.ApprovedPersonIdTwo, 
            catcher.ApprovedDateTwo, 
            catcher.ApprovedPersonIdThree, 
            catcher.ApprovedDateThree, 
            catcher.JoinedDate
        );
        return newReq;
    }

    private static ServiceDto ToServiceDto(RequestService service, ScannedImage? image)
    {
        
        var serviceReq = new ServiceDto(
            service.RequestServiceId, 
            service.ReqUserId,
            image!.ScannedImageMedia,
            service.SelectedSerpent
            );

        return serviceReq;
    }
    
    private static ServiceDto ToServiceDto(RequestService service)
    {
        var serviceReq = new ServiceDto(
            service.RequestServiceId, 
            service.ReqUserId,
            null,
            service.SelectedSerpent
        );

        return serviceReq;    }
    
    

    private bool CatcherExists(long id)
    {
        return (_context.Catcher?.Any(e => e.CatcherId == id)).GetValueOrDefault();
    }

    private bool ServiceExists(long id)
    {
        return (_context.RequestService?.Any(e => e.RequestServiceId == id)).GetValueOrDefault();
    }
    

}



    // [HttpGet]
    //     public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPost()
    //     {
    //         if (_context.CommunityPost == null)
    //         {
    //             return NotFound();
    //         }
    //         // return await _context.CommunityPost.ToListAsync();
    //         return await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
    //             x,
    //             _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
    //             _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList())
    //         ).ToListAsync();
    //     }
    //
    //     // view selected community posts
    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<PostDto>> GetCommunityPost(long id)
    //     {
    //       if (_context.CommunityPost == null)
    //       {
    //           return NotFound();
    //       }
    //       var communityPost = await _context.CommunityPost.FindAsync(id);
    //
    //       if (communityPost == null)
    //       {
    //           return NotFound();
    //       }
    //       
    //       var comments = _context.CommunityPostComment.Where(p => p.CommunityPostId == communityPost.CommunityPostId).ToList();
    //       var reports = _context.CommunityPostReport.Where(p => p.CommunityPostId == communityPost.CommunityPostId).ToList();
    //
    //       var postDetails = CommunityPost.CreatePostDto(communityPost, comments, reports);
    //
    //       return postDetails;
    //     }
    //     
    //     
    //     // To protect from attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //
    //     // edit 
    //     [HttpPut("{id}")]
    //     public async Task<IActionResult> PutCommunityPost(long id, CommunityPost communityPost)
    //     {
    //         if (id != communityPost.CommunityPostId)
    //         {
    //             return BadRequest();
    //         }
    //
    //         _context.Entry(communityPost).State = EntityState.Modified;
    //
    //         try
    //         {
    //             await _context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!CommunityPostExists(id))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }
    //
    //         return NoContent();
    //     }
    //
    //     // To protect from  attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //
    //     // add new community post
    //     [HttpPost]
    //     public async Task<ActionResult<CommunityPost>> PostCommunityPost(PostDto communityPost)
    //     {
    //       if (_context.CommunityPost == null)
    //       {
    //           return Problem("Entity set 'VenomVerseContext.CommunityPost'  is null.");
    //       }
    //       
    //       //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
    //       _context.CommunityPost.Add(CommunityPost.PostDtoToPost(communityPost));
    //
    //       await _context.SaveChangesAsync();
    //
    //       return CreatedAtAction("GetCommunityPost", new { id = communityPost.PostId }, communityPost);
    //     }
    //
    //     
    //
    //     // delete a community post
    //     [HttpDelete("{id}")]
    //     public async Task<IActionResult> DeleteCommunityPost(long id)
    //     {
    //         if (_context.CommunityPost == null)
    //         {
    //             return NotFound();
    //         }
    //         var communityPost = await _context.CommunityPost.FindAsync(id);
    //         if (communityPost == null)
    //         {
    //             return NotFound();
    //         }
    //
    //         _context.CommunityPost.Remove(communityPost);
    //         await _context.SaveChangesAsync();
    //
    //         return NoContent();
    //     }
    //     
    //     // add a new comment to a community post
    //     [HttpPost("AddComment/{id}")]
    //     public async Task<ActionResult<CommunityPost>> PostCommunityPostComment(long id, PostCommentDto commentDto)
    //     {
    //         if (_context.CommunityPost == null)
    //         {
    //             return Problem("Entity set 'VenomVerseContext.CommunityPost'  is null.");
    //         }
    //
    //         if (id != commentDto.PostId)
    //         {
    //             return Problem("Id Mismatch");
    //         }
    //
    //         var communityPost = await _context.CommunityPost.FindAsync(id);
    //         if (communityPost == null)
    //         {
    //             return NotFound();
    //         }
    //
    //         var comment = new CommunityPostComment
    //         {
    //             CommunityPostCommentId = commentDto.CommentId,
    //             CommunityPostId = commentDto.PostId,
    //             UserId = commentDto.UserId,
    //             DateTime = commentDto.DateTime,
    //             Comment = commentDto.Comment
    //         };
    //
    //         _context.CommunityPostComment.Add(comment);
    //       
    //         //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
    //         // _context.CommunityPost.Add(CommunityPost.PostDtoToPost(communityPost));
    //
    //         await _context.SaveChangesAsync();
    //
    //         return CreatedAtAction("GetCommunityPost", new { id = commentDto.PostId }, comment);
    //     }
    //
    //     