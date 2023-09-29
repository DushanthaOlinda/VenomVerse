using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class ScannedImageDto
{
    public long ScannedImageId { get; set; }
    public long UploadedUserId { get; set; } //User->UserId
    public string ScannedImageMedia { get; set; } //ScannedIMage->ScannedImageId
    public DateTime DateTime { get; set; } = DateTime.Now;
    public long PredictedSerpentType { get; set; } // Serpent->SerpentId      ++1
    public float Accuracy { get; set; } // 75%

    public long? ActualSerpentType { get; set; } // Serpent->SerpentId         ++maximum voted serpent type         1
    public bool? PredictionSuccess { get; set; }    
    public string? UserFirstName {get; set; }
    public string? UserLastName {get; set; }
    public string? ScannedSerpentName {get; set; }


    public ScannedImageDto(long scannedImageId, long uploadedUserId, string scannedImageMedia, DateTime dateTime, long predictedSerpentType, float accuracy, long? actualSerpentType, bool? predictionSuccess, string userfname, string userlname, string serpentName)
    {
        ScannedImageId = scannedImageId;
        UploadedUserId = uploadedUserId;
        ScannedImageMedia = scannedImageMedia;
        DateTime = dateTime;
        PredictedSerpentType = predictedSerpentType;
        Accuracy = accuracy;
        ActualSerpentType = actualSerpentType;
        PredictionSuccess = predictionSuccess;
        UserFirstName = userfname;
        UserLastName = userlname;
        ScannedSerpentName = serpentName;
    }

    // public ScannedImageDto(long scannedImageId, long uploadedUserId, string scannedImageMedia, long predictedSerpentType, float accuracy)
    // {
    //     ScannedImageId = scannedImageId;
    //     UploadedUserId = uploadedUserId;
    //     ScannedImageMedia = scannedImageMedia;
    //     PredictedSerpentType = predictedSerpentType;
    //     Accuracy = accuracy;
    // }


}