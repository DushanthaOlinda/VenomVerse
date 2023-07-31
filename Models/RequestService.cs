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
        public required long Id { get; set; }
        public required long ReqUserId { get; set; }
        public long? CatcherId { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null; 

        public string[]? ScannedImage { get; set; }
        public string? SelectedSerpent { get; set; }

        public bool AcceptFlag { get; set; } = false;
        public bool CompleteFlag { get; set; } = false;
        public bool FakeReqFlag { get; set; } = false;

        public string[]? ServiceFeedback { get; set; }
        public float? ServiceRating { get; set; } = null;
    }
}
