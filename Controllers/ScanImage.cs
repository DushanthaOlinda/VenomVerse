using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;


[ApiController]
[Route("[controller]")]
public class ScanImageController : ControllerBase
{
    private readonly VenomVerseContext _context;

    public ScanImageController(VenomVerseContext context)
    {
        _context = context;
    }

    // view all community posts
    // HIDDEN POSTS MUST BE HIDDEN
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScannedImageDto>>> GetAllScannedImages()
    {
        if (_context.ScannedImage == null)
        {
            return NotFound();
        }

        // return await _context.CommunityPost.ToListAsync();
        return await _context.ScannedImage.Select(x => new ScannedImageDto(
            x.ScannedImageId, 
            x.UploadedUserId,
            x.ScannedImageMedia,
            x.PredictedSerpentType,
            x.Accuracy,
            x.ActualSerpentType,
            x.PredictionSuccess
            )).ToListAsync();
    }

    // private async Task<ActionResult> getUserById(long id){
    //     var user =  await _context.UserDetail.FindAsync(id);
    //     return user.UserName;
    // }

    // view selected community posts
    [HttpGet("{id}")]
    public async Task<ActionResult<ScannedImageDto>> GetScannedImage(long id)
    {
        if (_context.CommunityPost == null)
        {
            return NotFound();
        }

        var scannedImage = await _context.ScannedImage.FindAsync(id);

        if (scannedImage == null)
        {
            return NotFound();
        }

        var imageDto = new ScannedImageDto(
            scannedImage.ScannedImageId, 
            scannedImage.UploadedUserId,
            scannedImage.ScannedImageMedia,
            scannedImage.PredictedSerpentType,
            scannedImage.Accuracy,
            scannedImage.ActualSerpentType,
            scannedImage.PredictionSuccess
        );
        return imageDto;
    }
    
    // add new community post
    [HttpPost]
    public async Task<ActionResult<ScannedImageDto>> SaveScannedImage(ScannedImageDto imageDto)
    {
        if (_context.ScannedImage == null)
        {
            return Problem("Entity set 'VenomVerseContext.ScannedImage'  is null.");
        }

        if (imageDto.ScannedImageId != null)
        {
            var newImage = new ScannedImage
            {
                ScannedImageId = (long)imageDto.ScannedImageId,
                UploadedUserId = imageDto.UploadedUserId,
                ScannedImageMedia = imageDto.ScannedImageMedia,
                DateTime = default
            };
            
            
            //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
            _context.ScannedImage.Add(newImage);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScannedImage", new { id = newImage.ScannedImageId }, newImage);
        }
        else
        {
            return Problem("Invalid image ID passed");
        }
    }

    
    private bool CommunityPostExists(long id)
    {
        return (_context.CommunityPost?.Any(e => e.CommunityPostId == id)).GetValueOrDefault();
    }
}