using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityArticle{

    public struct ArticleCommentStruct {        //Try to way to map with catcherRating
        public required long ArticleCommentId { get; set; }
        public required long UserId { get; set; }
        public required string Comment { get; set; }
    }

    public struct ArticleReportStruct {        //Try to way to map with catcherRating
        public required long ArticleReportId { get; set; }
        public required long UserId { get; set; }
        public required string ArticleReportContent { get; set; }
    }

    public required long CommunityArticleId { get; set; }
    [ForeignKey("User")] public required long UserId { get; set; }       // Uploaded Expert Id - validate from backend whether user has the expert privilleges AND Zoologists
    public required string Category { get; set; } = null!;
    public string? Description { get; set; }
    public required string Content { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    [ForeignKey("CommunityAdmin")] public long? ApprovedUserId { get; set;}     // Community admins approves the articles
    public long[]? React { get; set; }
    public string[,]? Comment { get; set; }
    public string[,]? ArticleReport { get; set; }
    public string[]? ArticleCopyright { get; set; }


            // Foreign Key References
            public UserDetail User { get; set; } = null!;
            public CommunityAdmin CommunityAdmin { get; set; } = null!;
}