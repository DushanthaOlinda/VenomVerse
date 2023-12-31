using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class CommunityArticleComment{
        public required long CommunityArticleCommentId { get; set; }
        public required long CommunityArticleId { get; set; }//COmmunityArticle -> communityArticleId
        public required long UserId { get; set; }//User-> userId
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required string Comment { get; set; }

        // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!; 
                [ForeignKey("CommunityArticleId")] public CommunityArticle CommunityArticle { get; set; } = null!; 
    }
}