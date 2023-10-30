using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ImageDetectionController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public ImageDetectionController(VenomVerseContext context)
    {
        _context = context;
    }

    // save scanned image, prediction, accuracy
    [HttpPost("ScanImage")]
    public async Task<ActionResult<ScannedImage>> ScanImage(ScannedImageDto scannedImageDto)
    {
        // return Ok("function inside");
        if (_context.ScannedImage == null)
        {
            return NoContent();
        }

        Console.WriteLine("Reach Here");

        var image = ScannedImage.ScannedImageDtoToScannedImage(scannedImageDto);
        _context.ScannedImage.Add(image);

        await _context.SaveChangesAsync();
        // return CreatedAtAction("GetCommunityPost", new { id = scannedImageDto.ScannedImageId }, scannedImageDto);
        return image;

        // if (scannedImageDto.UploadedUserId == null)
        // {
        //     return NotFound("User not found");
        // }

        // var image = new ScannedImage()      // CHECK THIS
        // {
        //     ScannedImageId = new Random().NextInt64(),
        //     UploadedUserId = scannedImageDto.UploadedUserId,
        //     ScannedImageMedia = scannedImageDto.ScannedImageMedia,
        //     DateTime = scannedImageDto.DateTime,
        //     PredictedSerpentType = scannedImageDto.PredictedSerpentType,
        //     Accuracy = scannedImageDto.Accuracy,
        //     // ActualSerpentType = scannedImageDto.ActualSerpentType,
        //     // PredictionSuccess = scannedImageDto.PredictionSuccess,

        // };
        // return CreatedAtAction("GetCommunityPost", new { id = communityPost.PostId }, communityPost);
        // return NoContent();
    }

    // view scanned images
    [HttpGet("ScannedImages")]
    public ActionResult<List<ScannedImage>> GetScannedImages(){
        if (_context.ScannedImage == null)
        {
            return NoContent();
        }
        
        var images = _context.ScannedImage.ToList();
        if (images == null || images.Count == 0)
        {
            return NoContent();
        }

        return images;
    }


    // create a new service request
    // SERVICE CAN BE WITH OR WITHOUT SCANNED IMAGE - DISCUSS THAT
    [HttpPost("CreateService/{sid}")]
    public async Task<IActionResult> CreateNewServiceRequest(ServiceDto serviceDto)
    {
        if ( _context.RequestService == null ) return NotFound();
        var service = RequestService.ToService(serviceDto);
        _context.RequestService.Add(service);
        await _context.SaveChangesAsync();

        // tappara 3 rauma karakenwa
        // select catchers according to the district
        var req_user = await _context.UserDetail.FindAsync(serviceDto.ReqUserId);

        if ( req_user==null )
        {
            return NotFound();
        }

        var nearby_catchers = await _context.UserDetail.Where( u => u.CatcherPrivilege==true && u.District==req_user.District).ToListAsync();

        // selected catcherslata call eka ywanna
        // loop through the ' nearby_catchers ' and send the call


        // when call is accepted or rejected,  they have seperate functions

        return Ok("Request Created");
    }


// select the serpent type for scanned image
        // rearrange the user predictions and select the actual prediction


    
    

}