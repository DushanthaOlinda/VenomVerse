using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class PostDto
{
    public long PostId { get; set; }
    public long UserId { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    
    public DateTime DateTime { get; set; }
    public string[]? Media { get; set; }
    public long[]? React { get; set; }
    public int PostStatus { get; set; }
    public List<PostCommentDto>? Comments { get; set; }
    public List<ReportDto>? Reports { get; set; }


    public PostDto(long postId, long userId, string category, string description, DateTime dateTime, string[]? media, long[]? react, int postStatus, List<PostCommentDto>? comments, List<ReportDto>? reports)
    {
        PostId = postId;
        UserId = userId;
        Category = category;
        Description = description;
        DateTime = dateTime;
        Media = media;
        React = react;
        PostStatus = postStatus;
        Comments = comments;
        Reports = reports;
    }
}
    