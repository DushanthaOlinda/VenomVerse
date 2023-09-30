using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Models;

[Index("UploadedUserId", IsUnique = false)]
public class ScannedImage
{
    public required long ScannedImageId { get; set; }
    public required long UploadedUserId { get; set; } //User->UserId
    public required string ScannedImageMedia { get; set; } //ScannedIMage->ScannedImageId
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public required long PredictedSerpentType { get; set; } // Serpent->SerpentId      ++1
    public required float Accuracy { get; set; } // 75%

    public long? ActualSerpentType { get; set; } // Serpent->SerpentId         ++maximum voted serpent type         1

    // public string? OtherSerpentType { get; set; }
    public bool? PredictionSuccess { get; set; } // T

    public ScannedImage()
    {
    }

    public ScannedImage(long scannedImageId, long uploadedUserId, string scannedImageMedia, long predictedSerpentType,
        float accuracy)
    {
        ScannedImageId = scannedImageId;
        UploadedUserId = uploadedUserId;
        ScannedImageMedia = scannedImageMedia;
        // DateTime = dateTime; 
        PredictedSerpentType = predictedSerpentType;
        Accuracy = accuracy;
    }

    public static ScannedImageDto ToScannedImageDto(ScannedImage scannedImage, string userfname, string userlname,
        string serpentName)
    {
        // var userDetails = await _context.UserDetail.FindAsync(catcher.CatcherId);
        // var fullName = userDetail!.FirstName + ' ' + userDetail.LastName;
        var newScanImg = new ScannedImageDto(
            scannedImage.ScannedImageId,
            scannedImage.UploadedUserId,
            scannedImage.ScannedImageMedia,
            scannedImage.DateTime,
            scannedImage.PredictedSerpentType,
            scannedImage.Accuracy,
            scannedImage.ActualSerpentType,
            scannedImage.PredictionSuccess,
            userfname,
            userlname,
            serpentName
        );
        return newScanImg;
    }

    public static ScannedImage ScannedImageDtoToScannedImage(ScannedImageDto scannedImageDto)
    {
        var scannedImage = new ScannedImage(
            scannedImageDto.ScannedImageId,
            scannedImageDto.UploadedUserId,
            scannedImageDto.ScannedImageMedia,
            // scannedImageDto.DateTime,
            scannedImageDto.PredictedSerpentType,
            scannedImageDto.Accuracy
        )
        {
            ScannedImageId = scannedImageDto.ScannedImageId,
            UploadedUserId = scannedImageDto.UploadedUserId,
            ScannedImageMedia = scannedImageDto.ScannedImageMedia,
            DateTime = scannedImageDto.DateTime,
            PredictedSerpentType = scannedImageDto.PredictedSerpentType,
            Accuracy = scannedImageDto.Accuracy
        };
        return scannedImage;
    }

    // Foreign Key References
    [ForeignKey("UploadedUserId")] public UserDetail User { get; set; } = null!;
    [ForeignKey("PredictedSerpentType")] public Serpent PredictedSerpent { get; set; } = null!;
    [ForeignKey("ActualSerpentType")] public Serpent ActualSerpent { get; set; } = null!;
    public RequestService RequestService { get; set; } = null!;
    public ScannedImageReview ScannedImageReview { get; set; } = null!;

    public static ScannedImageDto ToImageDto(ScannedImage image, UserDetail? scannedUser)
    {
        // throw new NotImplementedException();

        var newDto = new ScannedImageDto(
            image.ScannedImageId,
            image.UploadedUserId,
            image.ScannedImageMedia,
            image.DateTime,
            image.PredictedSerpentType,
            image.Accuracy,
            image.ActualSerpentType,
            image.PredictionSuccess,
            scannedUser?.FirstName,
            scannedUser?.LastName,
            image.ActualSerpentType.ToString()
        );

        return newDto;
    }
}