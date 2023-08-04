using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class ScannedImage {
        public required long ScannedImageId { get; set; }
        public required long UploadedUserId { get; set; }
        public required string ScannedImageMedia { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        [ForeignKey("PredictedSerpent")]
        public long? PredictedSerpentType { get; set; }
        [ForeignKey("ActualSerpent")]
        public long[]? ActualSerpentType { get; set; }          // To store best suitable verification from several users such as experts or zoologists - maximum voted serpent type
        public string? OtherSerpentType { get; set; }
        public float? Accuracy { get; set; }

        // public long? ActualSerpentType { get; set; }          // maximum voted serpent type
        // public string? OtherSerpentType { get; set; }
        public bool? PredictionSuccess { get; set; }

                // Foreign Key References
        [ForeignKey("UploadedUserId")] public UserDetail User { get; set; } = null!;
        public Serpent? PredictedSerpent { get; set; } = null;
        public List<Serpent>? ActualSerpent { get; set; }
        public RequestService RequestService { get; set; } = null!;
    }
}
