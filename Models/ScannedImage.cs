using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class ScannedImage {
        public required long ScannedImageId { get; set; }
        public required long UploadedUserId { get; set; }//User->UserId
        public required string ScannedImageMedia { get; set; }//ScannedIMage->ScannedImageId
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public long? PredictedSerpentType { get; set; }  // Serpent->SerpentId      ++1
        public float? Accuracy { get; set; }  // 75%

        public long? ActualSerpentType { get; set; }          // Serpent->SerpentId         ++maximum voted serpent type         1
        // public string? OtherSerpentType { get; set; }
        public bool? PredictionSuccess { get; set; }        // T

                // Foreign Key References
                [ForeignKey("UploadedUserId")] public UserDetail User { get; set; } = null!;
                [ForeignKey("PredictedSerpentType")] public Serpent PredictedSerpent { get; set; } = null!;
                [ForeignKey("ActualSerpentType")] public Serpent ActualSerpent { get; set; } = null!;
                public RequestService RequestService { get; set; } = null!;
                public ScannedImageReview ScannedImageReview { get; set; } = null!; 
    }
}
