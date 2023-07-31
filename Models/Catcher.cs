namespace VenomVerseApi.Models
{
    public struct RatingStruct {        //Try to way to map with catcherRating
        public required long UserId { get; set; }
        public required float Rate { get; set; }
        public string? RatingComment { get; set; }
    }

    public class Catcher {
        public required long Id { get; set; }
        public required bool Availability { get; set; } = true;
        //public string? LiveLocation { get; set; } = null;   
        public required DateOnly? JoinedDate { get; set; }
        public required long RequestId { get; set; }   
        public float? ChargingFee { get; set; } = null;
        public string[,]? CatcherRating { get; set; }       // size equals to 3 for inner element array -> user_id, rate, comment
    }
}
