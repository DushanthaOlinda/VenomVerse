namespace VenomVerseApi.Models;

public class CommunityBook{

    public long Id { get; set; }
    public string? Category { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool Availability { get; set;}
    
    public string[]? Media { get; set;}
    public string? Author { get; set;}

    public DateOnly? PublishedDate { get; set;}
    public DateOnly UploadedDate { get; set;}

    public long? UploadedUserId { get; set;}
    public long? ApprovedUserId { get; set;}
    public string[]? BookCopyright { get; set; }

}