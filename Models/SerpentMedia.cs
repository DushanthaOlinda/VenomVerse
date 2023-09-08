using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class SerpentMedia{
        public required long SerpentMediaId { get; set; }
        public required long SerpentId { get; set; }
        public string? SerpentMediaDescription { get; set; }
        public string? SerpentMediaAltText { get; set; }
        public string? SerpentMediaSource { get; set; }

                // Foreign Key References
                // [ForeignKey("SerpentId")] public Serpent Serpent { get; set; } = null!;
    }
}