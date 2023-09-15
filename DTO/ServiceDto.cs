namespace VenomVerseApi.DTO;

public class ServiceDto
{
    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImage, long? selectedSerpent)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImage;
        SelectedSerpent = selectedSerpent;
    }

    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImage, long? selectedSerpent, int rate, string? ratingComment, string? serviceFeedback, string[]? serviceFeedbackMedia)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImage;
        SelectedSerpent = selectedSerpent;
        Rate = rate;
        RatingComment = ratingComment;
        ServiceFeedback = serviceFeedback;
        ServiceFeedbackMedia = serviceFeedbackMedia;
    }

    public long RequestServiceId { get; set; } 
    public long ReqUserId { get; set; }//User->UserId
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string? ScannedImageLink { get; set; } = null; //ScannedImage->ScannedImageId           
    public long? SelectedSerpent { get; set; } = null;//Serpent->SerpentId
    public int Rate { get; set; } = 0; // 1-5
    public string? RatingComment { get; set; } = null;
    public string? ServiceFeedback { get; set; } = null;
    public string[]? ServiceFeedbackMedia { get; set; } = null;
}