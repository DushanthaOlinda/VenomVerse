namespace VenomVerseApi.DTO;

public class CommunityBookDto
{
    public required long CommunityBookId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string Content { get; set; } = null!;
    public required bool Availability { get; set;} = true;      // Paid->false or Free->true
    
    public string[]? Media { get; set;}             // pdf location -> directly load from the app
    public required string Author { get; set;}

    public DateOnly? PublishedDate { get; set;}
    public required DateOnly UploadedDate { get; set;}

    public required long UploadedUserId { get; set;}         // Zoologists upload books
    public string[]? BookCopyright { get; set; }
}