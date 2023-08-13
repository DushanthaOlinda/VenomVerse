namespace VenomVerseApi.DTO;

public class CommunityPostDto
{
    public long? CommunityPostId { get; set; }
    public long? UserId { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public long[]? React { get; set; }
    public bool PostEdited { get; set; } = false;
    public int PostStatus {get; set; } 
}
