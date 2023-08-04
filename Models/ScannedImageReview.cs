using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class ScannedImageReview {
        public required long ScannedImageReviewId { get; set; }
        public required long ScannedImageId { get; set; }
        public required long ReviewedUserId { get; set; }   // Expert / Zoologist
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public long PredictedSerpentType { get; set; }
        public long? ActualSerpentType { get; set; }          // maximum voted serpent type
        public bool? PredictionSuccess { get; set; }

                // Foreign Key References
                [ForeignKey("ReviewedUserId")] public UserDetail User { get; set; } = null!;
                [ForeignKey("PredictedSerpentType")] public Serpent SerpentPredict { get; set; } = null!;
                [ForeignKey("ActualSerpentType")] public Serpent SerpentActual { get; set; } = null!;
                public RequestService RequestService { get; set; } = null!;
                [ForeignKey("ScannedImageId")] public ScannedImage ScannedImage { get; set; } = null!;
    }
}
