namespace VenomVerseApi.DTO;

public class CommunityBookDto
{
    public CommunityBookDto(long communityBookId, string category, string description, string content, bool availability, string[]? media, string author, DateOnly? publishedDate, DateOnly uploadedDate, long uploadedUserId, string[]? bookCopyright)
    {
        CommunityBookId = communityBookId;
        Category = category;
        Description = description;
        Content = content;
        Availability = availability;
        Media = media;
        Author = author;
        PublishedDate = publishedDate;
        UploadedDate = uploadedDate;
        UploadedUserId = uploadedUserId;
        BookCopyright = bookCopyright;
    }
    
    
    public long CommunityBookId { get; set; }
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool Availability { get; set;} = true;      // Paid->false or Free->true
    
    public string[]? Media { get; set;}             // pdf location -> directly load from the app
    public string Author { get; set; } = null!; 

    public DateOnly? PublishedDate { get; set;}
    public DateOnly UploadedDate { get; set;}
    
    public long UploadedUserId { get; set;}         // zoologist->zoologistId   ++Zoologists upload books
    public string[]? BookCopyright { get; set; }
}