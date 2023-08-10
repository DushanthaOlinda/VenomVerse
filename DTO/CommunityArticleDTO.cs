namespace VenomVerseApi.DTO;

public class CommunityArticleDto
{
        public required long CommunityArticleId { get; set; }
    public required long UserId { get; set; }       // Uploaded Expert Id - validate from backend whether user has the expert privilleges AND Zoologists
    public required string Category { get; set; } = null!;
    public string? Description { get; set; }
    public required string Content { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    public required int ArticleStatus {get; set; } = 0;
    public string[]? ArticleCopyright { get; set; }
    public long? ApprovedUserId { get; set;}
}