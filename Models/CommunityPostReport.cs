using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class CommunityPostReport{
        public required long CommunityPostReportId { get; set; }
        public required long CommunityPostId { get; set; }
        public required long UserId { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required string Description { get; set; }
        public long? ComAdminId {get; set; }
        public string? Response {get; set; }    // rejected, deleted, no action

        // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!; 
                [ForeignKey("CommunityPostId")] public CommunityPost CommunityPost { get; set; } = null!; 
    }
}

