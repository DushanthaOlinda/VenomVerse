namespace VenomVerseApi.DTO;

public class SerpentDto
{

    public SerpentDto(long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string? specialNote, string? specialNoteSinhala, string description, string descriptionSinhala, IEnumerable<Models.SerpentInstruction> serpentInstructions)
    {
        SerpentId = serpentId;
        ScientificName = scientificName;
        EnglishName = englishName;
        SinhalaName = sinhalaName;
        SerpentMedia = serpentMedia;
        Venomous = venomous;
        Family = family;
        SubFamily = subFamily;
        Genus = genus;
        SpecialNote = specialNote;
        SpecialNoteSinhala = specialNoteSinhala;
        Description = description;
        DescriptionSinhala = descriptionSinhala;
    }

    public SerpentDto(long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string? specialNote, string? specialNoteSinhala, string description, string descriptionSinhala, List<SerpentInstructionDto>? instructions)
    {
        SerpentId = serpentId;
        ScientificName = scientificName;
        EnglishName = englishName;
        SinhalaName = sinhalaName;
        SerpentMedia = serpentMedia;
        Venomous = venomous;
        Family = family;
        SubFamily = subFamily;
        Genus = genus;
        SpecialNote = specialNote;
        SpecialNoteSinhala = specialNoteSinhala;
        Description = description;
        DescriptionSinhala = descriptionSinhala;
        Instructions = instructions;
    }

    public required long SerpentId { get; set; }
        public required string ScientificName { get; set; }
        public required string EnglishName { get; set; }
        public required string SinhalaName { get; set; }
        public required string[] SerpentMedia { get; set; } 

        public required int Venomous { get; set; }   // -1 ==> non-venomous,   0 ==> middle-venomous-range,  1 ==> high-venomous

        public required string Family { get; set; }
        public required string SubFamily { get; set; }
        public required string Genus { get; set; }

    public string? SpecialNote { get; set; }
        public string? SpecialNoteSinhala { get; set; }
        public required string Description { get; set; }
        public required string DescriptionSinhala { get; set; }

        public List<SerpentInstructionDto>? Instructions { get; set; } = null;

        // public SerpentDto ( long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string specialNote, string specialNoteSinhala, string description, string descriptionSinhala, List<SerpentInstructionDto>? instructions) {
        //         SerpentId = serpentId;
        //         ScientificName = scientificName;
        //         EnglishName = englishName;
        //         SinhalaName = sinhalaName;
        //         SerpentMedia = serpentMedia;
        //         Venomous = venomous;
        //         Family = family;
        //         SubFamily = subFamily;
        //         Genus = genus;
        //         SpecialNote = specialNote;
        //         SpecialNoteSinhala = specialNoteSinhala;
        //         Description = description;
        //         DescriptionSinhala = descriptionSinhala;
        //         Instructions = instructions;
        // }
}