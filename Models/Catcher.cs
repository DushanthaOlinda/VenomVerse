namespace VenomVerseApi.Models
{
    public struct RatingStruct {        //Try to way to map with catcherRating
        public long UserId { get; set; }
        public float Rate { get; set; }
        public string? RatingComment { get; set; }
    }

    public class Catcher {
        public long Id { get; set; }
        public bool Availability { get; set; }
        //public string? LiveLocation { get; set; } = null;   
        public DateOnly? JoinedDate { get; set; }
        public long RequestId { get; set; }   
        public float? ChargingFee { get; set; } = null;
        public string[,]? CatcherRating { get; set; }       // size equals to 3 for inner element array -> user_id, rate, comment
    }
}
