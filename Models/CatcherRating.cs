using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class CatcherRating{
        [Key] public required long UserId { get; set; }
        [Key] public required long CatcherId { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedTime { get; set; } = null;
        public required int Rate { get; set; }        // 1-5
        public string? RatingComment { get; set; }

        // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!; 
                [ForeignKey("CatcherId")] public Catcher Catcher { get; set; } = null!; 
    }
}