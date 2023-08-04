using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityPost{

    public struct PostCommentStruct {        //Try to way to map with catcherRating
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required string Comment { get; set; }
    }

    public struct PostReportStruct {        //Try to way to map with catcherRating
        public required long PostReportId { get; set; }
        public required long UserId { get; set; }
        public required string PostReportContent { get; set; }
    }

    public required long CommunityPostId { get; set; }
    [ForeignKey("User")] public required long UserId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public long[]? React { get; set; }
    public string[,]? Comment { get; set; }
    public string[,]? PostReport { get; set; }


            // Foreign Key References
            public UserDetail User { get; set; } = null!;
}