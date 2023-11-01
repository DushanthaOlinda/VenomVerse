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

    // Get all scanned images
    [HttpGet]
    public async Task<ActionResult<List<ScannedImageDto>>> GetAllScannedImages()
    {
        if (_context.ScannedImage == null)
        {
            return NotFound();
        }

        // return await _context.CommunityPost.ToListAsync();
        return await _context.ScannedImage.Select(x => PrepareDto(x, _context.UserDetail.FirstOrDefault(detail => detail.UserDetailId == x.UploadedUserId))).ToListAsync();
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

        var scannedUser = await _context.UserDetail.FindAsync(scannedImage.UploadedUserId);

        var imageDto = new ScannedImageDto(
            scannedImage.ScannedImageId,
            scannedImage.UploadedUserId,
            scannedImage.ScannedImageMedia,
            scannedImage.DateTime,
            scannedImage.PredictedSerpentType,
            scannedImage.Accuracy,
            scannedImage.ActualSerpentType,
            scannedImage.PredictionSuccess,
            scannedUser?.FirstName,
            scannedUser?.LastName,
            scannedImage.PredictedSerpentType.ToString()
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
                DateTime = default,
                PredictedSerpentType = imageDto.PredictedSerpentType,
                Accuracy = imageDto.Accuracy,
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

    private static ScannedImageDto PrepareDto(ScannedImage image, UserDetail? user)
    {
        var snakeNames = new Dictionary<long, string>
        {
            { 1, "Cobra"},
            { 2, "Indian Python"}, 
            { 3, "Sand Boa" },
            { 4, "Hump Nosed Viper" },
            { 5, "Whip Snake" },
            { 6, "Sri Lankan Krait" },
            { 7, "Common Krait" },
            { 8, "Russell's Viper" },
            { 9, "Saw-scaled Viper" }
            // Add more id-snakeName mappings as needed
        };

        // var user = userTask.Result;

        var snakeName = snakeNames.TryGetValue(image.PredictedSerpentType, out var name) ? name : "Unknown Snake";

        // var user = _context.UserDetail.FindAsync(image.UploadedUserId).Result;

        var imageDto = ScannedImage.ToScannedImageDto(image, user?.FirstName ?? "USER", user?.LastName ?? "NOT FOUND", snakeName);

        return imageDto;
    }
}