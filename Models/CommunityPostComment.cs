using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Models
{
    public class CommunityPostComment{
        public required long CommunityPostCommentId { get; set; }
        public required long CommunityPostId { get; set; }//CommunityPost->CommunityPostId
        public required long UserId { get; set; } // User --> UserID
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required string Comment { get; set; }     // english or sinhala or singlish



        public static PostCommentDto CommentToCommentDto(CommunityPostComment comment)
        {
            return new PostCommentDto(
                comment.CommunityPostCommentId,
                comment.CommunityPostId,
                comment.UserId,
                comment.Comment
            );
        }

        public PostCommentDto CommentToCommentDto()
        {
            return new PostCommentDto(
                this.CommunityPostCommentId,
                this.CommunityPostId,
                this.UserId,
                this.Comment
            );
        }

        
        // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!; 
                [ForeignKey("CommunityPostId")] public CommunityPost CommunityArticle { get; set; } = null!;
        
    }
}