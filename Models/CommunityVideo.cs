using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityVideo{
    public required long CommunityVideoId { get; set; }
    public required long UserId { get; set; }
    public required string VideoTitle { get; set; }
    public required string VideoDescription { get; set; }
    public required string VideoLink { get; set; }

        // Foreign Key References
        [ForeignKey("UserId")] public UserDetail VideoUser { get; set; } = null!;   //provide reference to the userdetail table
}

//saved videos for the users