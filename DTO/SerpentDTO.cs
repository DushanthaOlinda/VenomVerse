namespace VenomVerseApi.DTO;

public class SerpentDto
{
        public required long SerpentId { get; set; }
        public required byte[] SerpentImage { get; set; }
        public required string ScientificName { get; set; }
        public required string EnglishName { get; set; }
        public required string SinhalaName { get; set; }

        public required int Venomous { get; set; }   // -1 ==> non-venomous,   0 ==> middle-venomous-range,  1 ==> high-venomous

        public required string Family { get; set; }
        public required string SubFamily { get; set; }
        public required string Genus { get; set; }

        public string? SpecialNote { get; set; }
        public string? SpecialNoteSinhala { get; set; }
        public required string Description { get; set; }
        public required string DescriptionSinhala { get; set; }
}