namespace VenomVerseApi.DTO;

public class SerpentDto
{
        public long? SerpentId { get; set; }
        public IFormFile? SerpentImageFile { get; set; }    // Include a property to hold the uploaded profile picture file
        public byte[]? SerpentImage { get; set; }           // Property to hold the converted profile picture as a byte array
        public string? ScientificName { get; set; }
        public string? EnglishName { get; set; }
        public string? SinhalaName { get; set; }

        public int Venomous { get; set; }   // -1 ==> non-venomous,   0 ==> middle-venomous-range,  1 ==> high-venomous

        public string? Family { get; set; }
        public string? SubFamily { get; set; }
        public string? Genus { get; set; }

        public string? SpecialNote { get; set; }
        public string? SpecialNoteSinhala { get; set; }
        public string? Description { get; set; }
        public string? DescriptionSinhala { get; set; }
}