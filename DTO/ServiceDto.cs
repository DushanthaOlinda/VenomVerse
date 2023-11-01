using Newtonsoft.Json;
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
    public string? ReqUserContact { get; set; } = null;
    public string? ReqUserAddress { get; set; } = null;

    public string? CatcherFirstName { get; set; } = null;
    public string? CatcherLastName { get; set; } = null;

    public string? ScanImgUrl { get; set; } = null;
    
    
    //when a service request is created

    public ServiceDto()
    {
        DateTime = DateTime.UtcNow;
    }
    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImageLink, long? selectedSerpent)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImageLink;
        SelectedSerpent = selectedSerpent;
        DateTime = DateTime.UtcNow;
    }

    [JsonConstructor]
    public ServiceDto(long requestServiceId, long reqUserId, string? scannedImageLink, long? selectedSerpent, UserDetail user, ScannedImage scanImg)
    {
        RequestServiceId = requestServiceId;
        ReqUserId = reqUserId;
        ScannedImageLink = scannedImageLink;
        SelectedSerpent = selectedSerpent;
        DateTime = DateTime.UtcNow;
        ReqUserFirstName = user.FirstName;
        ReqUserLastName = user.LastName;
        ReqUserContact = user.ContactNo;
        ReqUserAddress = user.Address~;
        ScanImgUrl = scanImg.ScannedImageMedia;
    }

}