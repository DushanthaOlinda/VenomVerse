namespace VenomVerseApi.DTO;

public class CommunityResearchDto
{
    public required long CommunityResearchId { get; set; }
    public required long UserId { get; set; }       // Uploaded Expert Id - validate from backend whether user has the expert privilleges
    public required string Category { get; set; } = null!;
    public string? Description { get; set; }
    public required string Content { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    public DateOnly? PublishedDate { get; set;}    // Research should have been published before upload as a learning material in the application
    public string[]? ResearchCopyright { get; set; }
}