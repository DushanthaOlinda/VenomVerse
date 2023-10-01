using Newtonsoft.Json;

namespace VenomVerseApi.DTO;

public class SerpentDto
{
        
        public SerpentDto()
        {
                // Parameterless constructor
        }
        
        public SerpentDto(long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string? specialNote, string? specialNoteSinhala, string description, string descriptionSinhala)
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
                Instructions = serpentInstructions;
        }

        [JsonConstructor]
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

        public  long SerpentId { get; set; }
        public  string ScientificName { get; set; }
        public  string EnglishName { get; set; }
        public  string SinhalaName { get; set; }
        public  string[] SerpentMedia { get; set; } 
        public  int Venomous { get; set; }   // -1 ==> non-venomous,   0 ==> middle-venomous-range,  1 ==> high-venomous
        public  string Family { get; set; }
        public  string SubFamily { get; set; }
        public  string Genus { get; set; }
        public string? SpecialNote { get; set; }
        public string? SpecialNoteSinhala { get; set; }
        public  string Description { get; set; }
        public  string DescriptionSinhala { get; set; }
        public List<SerpentInstructionDto>? Instructions { get; set; }


        //Constructor with instructions => retrive
        // public SerpentDto(long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string? specialNote, string? specialNoteSinhala, string description, string descriptionSinhala, IEnumerable<Models.SerpentInstruction> serpentInstructions)
        // {
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
        // }
        //
        // //Constructor without instructions => inserting a new serpent
        // public SerpentDto(long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string? specialNote, string? specialNoteSinhala, string description, string descriptionSinhala, List<SerpentInstructionDto>? instructions)
        // {
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