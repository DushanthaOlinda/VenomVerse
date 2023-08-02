using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public struct ServiceFeedbackStruct {        //Try to way to map with ServiceFeedback
        public long ServiceFeedbackId { get; set; }
        public long ServiceId { get; set; }
        public long UserId { get; set; }
        public string? ServiceFeedback { get; set; }
        public string[]? ServiceFeedbackMedia { get; set; }
    }

    public struct ServiceRatingStruct {        //Try to way to map with Service Rating
        public required long UserId { get; set; }
        public required float Rate { get; set; }
        public string? RatingComment { get; set; }
    }

    public class RequestService {
        public required long RequestServiceId { get; set; }
        [ForeignKey("User")] public required long ReqUserId { get; set; }
        [ForeignKey("Catcher")] public long? CatcherId { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null; 

        [ForeignKey("ScannedImg")] public string? ScannedImage { get; set; }             // '1', '2', '3', '4'
        [ForeignKey("Serpent")] public string? SelectedSerpent { get; set; }

        public bool AcceptFlag { get; set; } = false;
        public bool CompleteFlag { get; set; } = false;
        public bool FakeReqFlag { get; set; } = false;

        public string[]? ServiceFeedback { get; set; }
        public float? ServiceRating { get; set; } = null;

        // Foreign Key References
        public UserDetail User { get; set; } = null!;
        public Catcher Catcher { get; set; } = null!;
        public Serpent Serpent { get; set; } = null!;
        public ScannedImage ScannedImg { get; set; } = null!;
    }
}
