namespace VenomVerseApi.DTO;

public class CommunityPostDto
{
    public required long CommunityPostId { get; set; }
    public required long UserId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public long[]? React { get; set; }
    public required int PostStatus {get; set; } 
}
