namespace VenomVerseApi.DTO;

public class ServiceDto
{
    //when a service request is created
    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImageLink, long? selectedSerpent)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImageLink;
        SelectedSerpent = selectedSerpent;
        DateTime = new DateTime();
    }

    public long RequestServiceId { get; set; } 
    public long ReqUserId { get; set; }
    public long? CatcherId { get; set; }
    public DateTime DateTime { get; set; }
    public string? ScannedImageLink { get; set; } = null; 
    public long? ScannedImageId { get; set; } = null; 
    public long? SelectedSerpent { get; set; } = null;
    public int? Rate { get; set; } = 0; 
    public string? RatingComment { get; set; } = null;
    public string[]? CatcherMedia { get; set; } = null;
    public string? CatcherFeedback { get; set; } = null;
    public string? ServiceFeedback { get; set; } = null;
    public string[]? ServiceFeedbackMedia { get; set; } = null;
}