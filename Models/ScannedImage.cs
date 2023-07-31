namespace VenomVerseApi.Models
{
    public class ScannedImage {
        public required long Id { get; set; }
        public required long UploadedUserId { get; set; }
        public required string ScannedImageMedia { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public long? PredictedSerpentType { get; set; }
        public long? ActualSerpentType { get; set; }
        public string? OtherSerpentType { get; set; }
        public float? Accuracy { get; set; }
        public bool? PredictionSuccess { get; set; }

        public string[,]? PredictionVerification { get; set; }      // [userId,serpent_type,prediction_success]
    }
}