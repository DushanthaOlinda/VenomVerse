using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class ScannedImage {
        public required long ScannedImageId { get; set; }
        [ForeignKey("User")] public required long UploadedUserId { get; set; }
        public required string ScannedImageMedia { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public long? PredictedSerpentType { get; set; }
        public long[]? ActualSerpentType { get; set; }          // To store best suitable verification from several users such as experts or zoologists - maximum voted serpent type
        public string? OtherSerpentType { get; set; }
        public float? Accuracy { get; set; }
        public bool? PredictionSuccess { get; set; }

        public string[,]? PredictionVerification { get; set; }      // [userId,serpent_type,prediction_success]

                // Foreign Key References
                public UserDetail User { get; set; } = null!;
                [ForeignKey("PredictedSerpentType, ActualSerpentType")] public Serpent Serpent { get; set; } = null!;
                public RequestService RequestService { get; set; } = null!;
    }
}
