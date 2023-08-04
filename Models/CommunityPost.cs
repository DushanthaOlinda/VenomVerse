using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityPost{
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
            [ForeignKey("React")] public List<UserDetail> UserReact { get; set; } = null!;
            [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;
}