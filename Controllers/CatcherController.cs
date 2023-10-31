using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Hubs;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CatcherController : ControllerBase
{
    private readonly VenomVerseContext _context;
    private readonly IHubContext<RequestHub> _hubContext;

    public CatcherController(VenomVerseContext context, IHubContext<RequestHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }
    
    // change availability 
    [HttpPut("ChangeAvailability/{id}")]
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
        // return Ok( new{
        //     ssss = catcher,
        //     dasda = "dasda"
        // }); 
    }


    // change charging fee
    [HttpPut("ChangeChargingFee/{id}")]
    public async Task<IActionResult> UpdateChargingFee(long id, float new_charging)
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

        catcher.ChargingFee = new_charging;
        
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


    // view to be catcher requests
    [HttpGet("ViewRequestsToBecomeCatcher")]
    public async Task<ActionResult<List<CatcherReqDto>>> GetAllCatcherRequests()
    {
        //pass user account
        if (_context.Catcher == null)
        {
            return NotFound();
        }
        
        var pendingCatcherList = await _context.Catcher.Where(catcher_req => catcher_req.ApprovedFlag == false).ToListAsync();
        if (pendingCatcherList != null)
        {
            return pendingCatcherList.Select(x =>
            {
                var userDetails = _context.UserDetail.Find(x.ReqCatcher);
                return Catcher.ToCatcherReqDto(x,userDetails);
            }).ToList();
        }
        else
        {
            return NotFound();
        }
    }

    // details of a single to be catcher request
    [HttpGet("ViewToBecatcherRequest/{reqid}")]
    public async Task<ActionResult<CatcherReqDto>> GetToBeCatcherRequestDetails(long reqid)
    {
        if ( _context.Catcher == null ) return NotFound();

        var catcherReq = await _context.Catcher.FindAsync(reqid);
        if ( catcherReq==null ) return NoContent();

        var user = await _context.UserDetail.FindAsync(catcherReq.ReqCatcher);

        return Catcher.ToCatcherReqDto(catcherReq, user);
    }


    // details of a single to be catcher request with quiz
    [HttpGet("ViewToBecatcherRequestWithPost/{reqid}")]
    public async Task<ActionResult> GetToBeCatcherRequestDetailsWithPost(long reqid)
    {
        if ( _context.Catcher == null ) return NotFound();

        var catcherReq = await _context.Catcher.FindAsync(reqid);
        if ( catcherReq==null ) return NoContent();

        var user = await _context.UserDetail.FindAsync(catcherReq.ReqCatcher);
        var quiz = await _context.QuizAttempt.Where(q => q.UserId == catcherReq.ReqCatcher).ToListAsync();

        return Ok
        (
            new
            {
                catcherDetails = Catcher.ToCatcherReqDto(catcherReq, user),
                quizDetails = quiz
            }
        );
    }
    

    // approve or decline catcher requests
    [HttpGet("RespondRequestsToBecomeCatcher")]
    public async Task<ActionResult> RespondRequestsToBecomeCatcher(long catcherId, long approvedUser, bool approveFlag)
    // public async Task<ActionResult<List<CatcherReqDto>>> ResponseRequestsToBecomeCatcher(request karapu catcher, approve karana catcher, approve krada ndda kyana eka true or false)
    {
        if (_context.Catcher == null)
        {
            return NotFound();
        }
        if (_context.UserDetail == null)
        {
            return NotFound();
        }
        var approvingCatcher = await _context.Catcher.Where(catcher => catcher.ReqCatcher == catcherId).OrderByDescending(catcher => catcher.ReqId).FirstOrDefaultAsync();
        if ( approvingCatcher != null )
        {
            if ( approvingCatcher.ApprovedPersonIdOne == null )
            {
                approvingCatcher.ApprovedPersonIdOne = approvedUser;
                approvingCatcher.ApprovedDateOne = new DateOnly();
                approvingCatcher.ApprovedStatusOne = approveFlag;
            }
            else if ( approvingCatcher.ApprovedPersonIdTwo == null )
            {
                approvingCatcher.ApprovedPersonIdTwo = approvedUser;
                approvingCatcher.ApprovedDateTwo = new DateOnly();   
                approvingCatcher.ApprovedStatusTwo = approveFlag;
            }
            else if ( approvingCatcher.ApprovedPersonIdThree == null )
            {
                approvingCatcher.ApprovedPersonIdThree = approvedUser;
                approvingCatcher.ApprovedDateThree = new DateOnly();  
                approvingCatcher.ApprovedStatusThree = approveFlag;

                if (
                    approvingCatcher.ApprovedStatusOne == true &&
                    approvingCatcher.ApprovedStatusTwo == true &&
                    approvingCatcher.ApprovedStatusThree == true 
                )
                {
                    approvingCatcher.JoinedDate = new DateOnly();
                    approvingCatcher.ApprovedFlag = true;
                    var privillaging_user = await _context.UserDetail.FindAsync(catcherId);
                    if ( privillaging_user != null ){
                        privillaging_user.CatcherPrivilege = true;
                        _context.Entry(privillaging_user).State = EntityState.Modified;
                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!CatcherExists(catcherId))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                    //return successful
                }
                else 
                {
                    approvingCatcher.ApprovedFlag = false;
                    //return error saying request has been declined
                }
            }
            else{
                // catcher has been already approved
            }
        }
        else
        {
            return NotFound();
        }
        return NoContent(); 
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

        if (response != true) 
        {
            return NoContent();
        }
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
    
    
    // view accepted requests by the catcher himself
    [HttpGet("AllRequests/{uid}")]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServiceRequestsForCatcher(long uid)
    {
        if ( _context.RequestService == null ) return NotFound();

        var reqServices = await _context.RequestService.Where(req => req.CatcherId == uid && req.CompleteFlag==false).ToListAsync();

        var allRequests = await _context.RequestService.Where(rs => rs.CatcherId == uid && rs.CompleteFlag == false).Select(x => RequestService.ToServiceDto(
            x,
            _context.UserDetail.Where(user => user.UserDetailId == x.ReqUserId).FirstOrDefault(),
            _context.ScannedImage.Where(si => si.ScannedImageId == x.ScannedImage).FirstOrDefault(),
            _context.Serpent.Where(s => s.SerpentId == x.SelectedSerpent).FirstOrDefault()
            // pass  serpent too
        )).ToListAsync();
        return allRequests;
    } 

    // view all service requests which did not have assigned a catcher
    [HttpGet("AllNotAssignedRequests")]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> AllNotAssignedRequests()
    {
        if ( _context.RequestService == null ) return NotFound();

        var reqServices = await _context.RequestService.Where(req => req.CatcherId == null).ToListAsync();

        var allRequests = await _context.RequestService.Where(req => req.CatcherId == null).Select(x => RequestService.ToServiceDto(
            x,
            null,
            _context.ScannedImage.Where(si => si.ScannedImageId == x.ScannedImage).FirstOrDefault(),
            _context.Serpent.Where(s => s.SerpentId == x.SelectedSerpent).FirstOrDefault()
            // pass  serpent too
        )).ToListAsync();
        return allRequests;
    }

    // view relevant request by clicking the card with user details
    [HttpGet("ViewRequest/{reqid}")]
    public async Task<ActionResult<ServiceDto>> GetServiceRequestDetails(long reqid)
    {
        if ( _context.RequestService == null ) return NotFound();

        var requestDetails = await _context.RequestService.FindAsync(reqid);
        if ( requestDetails==null ) return NoContent();
        var user = await _context.UserDetail.FindAsync(requestDetails.ReqUserId);
        var scannedImg = await _context.ScannedImage.FindAsync(requestDetails.ScannedImage) ?? await _context.ScannedImage.FindAsync(Convert.ToInt64(1));
        var serpent = await _context.Serpent.FindAsync(requestDetails.SelectedSerpent);

        return RequestService.ToServiceDto(requestDetails, user, scannedImg, serpent);
    }


    // view all ratings of his services
    [HttpGet("AllRequestsCompleted/{uid}")]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllCompletedServiceRequestsForCatcher(long uid)
    {
        if ( _context.RequestService == null ) return NotFound();

        var reqServices = await _context.RequestService.Where(req => req.CatcherId == uid && req.CompleteFlag==true).ToListAsync();

        var allRequests = await _context.RequestService.Where(rs => rs.CatcherId == uid && rs.CompleteFlag == false).Select(x => RequestService.ToServiceDto(
            x,
            _context.UserDetail.FirstOrDefault(user => user.UserDetailId == x.ReqUserId),
            _context.ScannedImage.FirstOrDefault(si => si.ScannedImageId == x.ScannedImage),
            _context.Serpent.FirstOrDefault(s => s.SerpentId == x.SelectedSerpent)
            // pass  serpent too
        )).ToListAsync();
        return allRequests;
    } 


    // complete service
    [HttpPut("CompleteServiceReq/{serviceReqId}")]
    public async Task<ActionResult<ServiceDto>> CompleteServiceRequest(long catcherId, long serviceReqId, string? feedback, string[]? catcherMedia)
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


        serviceReq.CatcherFeedback = feedback;
        serviceReq.CatcherMedia = catcherMedia;
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


    // give feedbacks for the service requests by user
    [HttpPut("FeedbackRateServiceReq/{serviceReqId}")]
    public async Task<ActionResult<ServiceDto>> FeedbackrateServiceRequest(long userId, long serviceReqId, string? feedback, string[]? feedbackMedia, int? rate, string? ratingComment)
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
                if (serviceReq.ReqUserId != userId)
                {
                    throw new ApplicationException("User id isn't matched");
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
        serviceReq.ServiceFeedbackMedia = feedbackMedia;
        serviceReq.Rate = rate;
        serviceReq.RatingComment = ratingComment;
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


    // get all approved catchers for admin reports
    [HttpGet("GetAllApprovedCatchers")]
    public async Task<ActionResult<List<CatcherReqDto>>> GetAllApprovedCatchers()
    {
        //pass user account
        if (_context.Catcher == null)
        {
            return NotFound();
        }
        
        var pendingCatcherList = await _context.Catcher.Where(catcher_req => catcher_req.ApprovedFlag == true).ToListAsync();
        if (pendingCatcherList != null)
        {
            return pendingCatcherList.Select(x =>
            {
                var userDetails = _context.UserDetail.Find(x.ReqCatcher);
                return Catcher.ToCatcherReqDto(x,userDetails);
            }).ToList();
        }
        else
        {
            return NotFound();
        }
    }
    
    // placing catcher request and their control done here
    
    
    [HttpPost("requestCatcher")]
    public async Task<IActionResult> RequestCatcher(string reqId)
    {
        // TODO: save catcher req
        var image = reqId;
        // Code to save the request in the database...

        await _hubContext.Clients.All.SendAsync("ReceiveOrder", image);
    
        return Ok();
    }

    [HttpPut("acceptRequest/{id}")]
    public async Task<IActionResult> AcceptRequest(string id)
    {
        // Code to update the order in the database...
        
        await _hubContext.Clients.User(id).SendAsync("OrderAccepted", id);

        await _hubContext.Clients.All.SendAsync("SomeOneAccepted", id);
    
        return Ok();
    }
    
    
    // ================================================================= //
    

    

    private bool CatcherExists(long id)
    {
        return (_context.Catcher?.Any(e => e.ReqCatcher == id)).GetValueOrDefault();
    }

    private bool ServiceExists(long id)
    {
        return (_context.RequestService?.Any(e => e.RequestServiceId == id)).GetValueOrDefault();
    }
    

}



    // view service notifications which allocated for the relevant catcher
    // [HttpGet("GetServiceReqList/{uid}")]
    // public async Task<ActionResult<List<ServiceDto>>> GetServiceRequests(long uid)
    // {
    //     //UserDto, reqest details

    //     // check if request services available
    //     if (_context.RequestService == null)
    //     {
    //         return NotFound();
    //     }

    //     // then get a list of request services where accept flag is false
    //     var serviceList = await _context.RequestService.Where(service => service.AcceptFlag == false && service.CatcherId==uid).ToListAsync();

    //     // then map above list to serviceDto
    //     return serviceList.Select(service =>
    //     {
    //         // find image relevant to scanned image id in request service class 
    //         var image = _context.ScannedImage.Find(service.ScannedImage);
    //         return image == null ? RequestService.ToServiceDto(service) : RequestService.ToServiceDto(service, image);
    //     } ).ToList();
        
    // }





    



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



    