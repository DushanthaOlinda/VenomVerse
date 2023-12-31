using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class PostCommentDto
{
    public long CommentId { get; set; }
    public long PostId { get; set; }
    public long UserId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string Comment { get; set; }
    public string? UserFirstName { get; set; } = null;
    public string? UserLastName { get; set; } = null;

    
    public PostCommentDto(long commentId, long postId, long userId, string comment)
    {
        CommentId = commentId;
        PostId = postId;
        UserId = userId;
        Comment = comment;
    }
    
}