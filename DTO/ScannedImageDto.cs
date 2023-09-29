namespace VenomVerseApi.DTO;

public class ScannedImageDto
{
    public ScannedImageDto(long? scannedImageId, long uploadedUserId, string scannedImageMedia, long? predictedSerpentType, float? accuracy, long? actualSerpentType, bool? predictionSuccess)
    {
        ScannedImageId = scannedImageId;
        UploadedUserId = uploadedUserId;
        ScannedImageMedia = scannedImageMedia;
        PredictedSerpentType = predictedSerpentType;
        Accuracy = accuracy;
        ActualSerpentType = actualSerpentType;
        PredictionSuccess = predictionSuccess;
    }

    public ScannedImageDto(long? scannedImageId, long uploadedUserId, string scannedImageMedia, long? predictedSerpentType, float? accuracy)
    {
        ScannedImageId = scannedImageId;
        UploadedUserId = uploadedUserId;
        ScannedImageMedia = scannedImageMedia;
        PredictedSerpentType = predictedSerpentType;
        Accuracy = accuracy;
    }


    public long? ScannedImageId { get; set; }
    public long UploadedUserId { get; set; } //User->UserId
    public string ScannedImageMedia { get; set; } //ScannedIMage->ScannedImageId
    public DateTime DateTime { get; set; } = DateTime.Now;
    public long? PredictedSerpentType { get; set; } // Serpent->SerpentId      ++1
    public float? Accuracy { get; set; } // 75%

    public long? ActualSerpentType { get; set; } // Serpent->SerpentId         ++maximum voted serpent type         1
    public bool? PredictionSuccess { get; set; }    
}