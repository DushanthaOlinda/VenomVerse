using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class PostCommentDto
{
    public PostCommentDto(long commentId, long postId, long userId, string comment)
    {
        CommentId = commentId;
        PostId = postId;
        UserId = userId;
        Comment = comment;
    }

    public long CommentId { get; set; }
    public long PostId { get; set; }
    public long UserId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string Comment { get; set; }
    
}