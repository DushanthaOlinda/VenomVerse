namespace VenomVerseApi.DTO;

public class CommunityVideoDto
{
    public required long CommunityVideoId { get; set; }
    public required long UserId { get; set; }
    public required string VideoTitle { get; set; }
    public required string VideoDescription { get; set; }
    public required string VideoLink { get; set; }
}