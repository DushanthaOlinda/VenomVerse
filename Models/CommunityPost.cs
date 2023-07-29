namespace VenomVerseApi.Models;

public class CommunityPost{

    public struct PostCommentStruct {        //Try to way to map with catcherRating
        public long PostCommentId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; }
    }

    public struct PostReportStruct {        //Try to way to map with catcherRating
        public long PostReportId { get; set; }
        public long UserId { get; set; }
        public string PostReportContent { get; set; }
    }

    public long Id { get; set; }
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public long[]? React { get; set; }
    public string[,]? Comment { get; set; }
    public string[,]? PostReport { get; set; }
}