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
    public async Task<ActionResult<long>> ScanImage(ScannedImageDto scannedImageDto)
    {
        if (_context.ScannedImage == null)
        {
            return NoContent();
        }

        if (scannedImageDto.UploadedUserId == null)
        {
            return NotFound("User not found");
        }

        var image = new ScannedImage()      // CHECK THIS
        {
            ScannedImageId = new Random().NextInt64(),
            UploadedUserId = scannedImageDto.UploadedUserId,
            ScannedImageMedia = scannedImageDto.ScannedImageMedia,
            DateTime = scannedImageDto.DateTime,
            PredictedSerpentType = scannedImageDto.PredictedSerpentType,
            Accuracy = scannedImageDto.Accuracy,
            ActualSerpentType = scannedImageDto.ActualSerpentType,
            PredictionSuccess = scannedImageDto.PredictionSuccess,

        };
        _context.ScannedImage.Add(image);

        await _context.SaveChangesAsync();
        return image.ScannedImageId;
        // return CreatedAtAction("GetCommunityPost", new { id = communityPost.PostId }, communityPost);
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


// select the serpent type for scanned image
        // rearrange the user predictions and select the actual prediction


    
    

}