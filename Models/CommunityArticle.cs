using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityArticle{
    public required long CommunityArticleId { get; set; }
    public required long UserId { get; set; }       // Uploaded Expert Id - validate from backend whether user has the expert privilleges AND Zoologists
    public required string Category { get; set; } = null!;
    public string? Description { get; set; }
    public required string Content { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    public required int ArticleStatus {get; set; } = 0;
    // 0 - pending approval
    // 1 - approved
    // -1 - rejected
    public long? ApprovedUserId { get; set;}     // Community admins approves the articles
    public long[]? React { get; set; }

    public string[]? ArticleCopyright { get; set; }


            // Foreign Key References
            [ForeignKey("React")] public List<UserDetail> UserReact { get; set; } = null!;
            [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;
            [InverseProperty("UserSavedArticle")] public List<UserDetail> UserSavedArticle { get; set; } = null!;
            [ForeignKey("ApprovedUserId")] public CommunityAdmin CommunityAdmin { get; set; } = null!;
}