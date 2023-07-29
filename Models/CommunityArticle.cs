namespace VenomVerseApi.Models;

public class CommunityArticle{

    public struct ArticleCommentStruct {        //Try to way to map with catcherRating
        public long ArticleCommentId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; }
    }

    public struct ArticleReportStruct {        //Try to way to map with catcherRating
        public long ArticleReportId { get; set; }
        public long UserId { get; set; }
        public string ArticleReportContent { get; set; }
    }

    public long Id { get; set; }
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public string? Author { get; set;}
    public long? ApprovedUserId { get; set;}
    public long[]? React { get; set; }
    public string[,]? Comment { get; set; }
    public string[,]? ArticleReport { get; set; }
    public string[]? ArticleCopyright { get; set; }
}