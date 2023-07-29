namespace VenomVerseApi.Models;

public class CommunityPost{
    public long Id { get; set; }
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    }