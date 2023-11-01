using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class ResearchDto
{
    public long CommunityResearchId { get; set; }
    public long UserId { get; set; }
    public string Category { get; set; }
    public string? Description { get; set; }
    
    public string Content { get; set; } = null!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    public DateOnly? PublishedDate { get; set;}    // Research should have been published before upload as a learning material in the application
    public string[]? ResearchCopyright { get; set; }



    public ResearchDto(long researchId, long userId, string category, string description, string content, DateTime dateTime, string[]? media, string author, DateOnly? publishedDate, string[]? copyright)
    {
        CommunityResearchId = researchId;
        UserId = userId;
        Category = category;
        Description = description;
        Content = content;
        DateTime = dateTime;
        Media = media;
        Author = author;
        PublishedDate = publishedDate;
        ResearchCopyright = copyright;
    }
}
    