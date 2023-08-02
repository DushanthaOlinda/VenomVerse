namespace VenomVerseApi.Models;

public class CommunityBook{

    public required long CommunityBookId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string Content { get; set; } = null!;
    public required bool Availability { get; set;}      // Paid or Free
    
    public string[]? Media { get; set;}
    public required string Author { get; set;}

    public DateOnly? PublishedDate { get; set;}
    public required DateOnly UploadedDate { get; set;}

    public required long UploadedUserId { get; set;}
    public long? ApprovedUserId { get; set;}
    public string[]? BookCopyright { get; set; }

}