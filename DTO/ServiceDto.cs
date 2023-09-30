using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class ServiceDto
{
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

    public string? ReqUserFirstName { get; set; } = null;
    public string? ReqUserLastName { get; set; } = null;

    public string? CatcherFirstName { get; set; } = null;
    public string? CatcherLastName { get; set; } = null;

    public string? ScanImgUrl { get; set; } = null;
    
    public Serpent? SerpentDetails { get; set; } = null;

    
    //when a service request is created
    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImageLink, long? selectedSerpent)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImageLink;
        SelectedSerpent = selectedSerpent;
        DateTime = new DateTime();
    }

    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImageLink, long? selectedSerpent, UserDetail user, ScannedImage scanImg, Serpent serpent)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImageLink;
        SelectedSerpent = selectedSerpent;
        DateTime = new DateTime();
        ReqUserFirstName = user.FirstName;
        ReqUserLastName = user.LastName;
        ScanImgUrl = scanImg.ScannedImageMedia;
        SerpentDetails = serpent;       // Serpent DTO can be retrived
    }

}