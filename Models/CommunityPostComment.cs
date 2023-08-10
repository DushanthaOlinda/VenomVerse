using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class CommunityPostComment{
        public required long CommunityPostCommentId { get; set; }
        public required long CommunityPostId { get; set; }
        public required long UserId { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required string Comment { get; set; }

        // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!; 
                [ForeignKey("CommunityPostId")] public CommunityPost CommunityArticle { get; set; } = null!; 
    }
}