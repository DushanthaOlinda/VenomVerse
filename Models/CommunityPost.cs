using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VenomVerseApi.Models;

[Index("UserId",IsUnique =false)]

public class CommunityPost{
    public CommunityPost()
    {}

    public CommunityPost(long communityPostId, long userId, string category, string description, string[]? media, long[]? react, int postStatus)
    {
        CommunityPostId = communityPostId;
        UserId = userId;
        Category = category;
        Description = description;
        Media = media;
        React = react;
        PostStatus = postStatus;
    }
    
    public required long CommunityPostId { get; set; }
    public required long UserId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public string[]? Media { get; set;}
    public long[]? React { get; set; }
    public required int PostStatus {get; set; } = 1;
    // 0 - hidden
    // 1 - posted
    // -1 - reported


            // Foreign Key References
            [ForeignKey("React")] public List<UserDetail> UserPostReact { get; set; } = null!;
            [ForeignKey("UserId")] public UserDetail PostUser { get; set; } = null!;
            [InverseProperty("UserSavedPost")] public List<UserDetail> UserSavedPost { get; set; } = null!;
}