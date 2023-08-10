namespace VenomVerseApi.DTO;

public class CommunityPostDto
{
    public required long CommunityPostId { get; set; }
    public required long UserId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public required int PostStatus {get; set; } = 1;
}