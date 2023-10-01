using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{
        public class Serpent {
        public required long SerpentId { get; set; }
        public required string ScientificName { get; set; }
        public required string EnglishName { get; set; }
        public required string SinhalaName { get; set; } 
        public required string[] SerpentMedia { get; set; } 

        public required int Venomous { get; set; }   // -1 ==> non-venomous,   0 ==> middle-venomous-range,  1 ==> high-venomous

        public required string Family { get; set; }
        public required string SubFamily { get; set; }
        public required string Genus { get; set; }

        public string? SpecialNote { get; set; } = null;
        public string? SpecialNoteSinhala { get; set; } = null;
        public required string Description { get; set; }
        public required string DescriptionSinhala { get; set; }

        public Serpent()
        {}

        public Serpent(long serpentId, string scientificName, string englishName, string sinhalaName, string[] serpentMedia, int venomous, string family, string subFamily, string genus, string description, string descriptionSinhala, string? specialNote, string? specialNoteSinhala)
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
                Description = description;
                DescriptionSinhala = descriptionSinhala;
        }
        public static SerpentDto CreateSerpentDto( 
                Serpent serpentDetail, 
                IEnumerable<SerpentInstruction> serpentInstructions 
        )
        {
                var serpent = new SerpentDto( 
                        serpentDetail.SerpentId,
                        serpentDetail.ScientificName,
                        serpentDetail.EnglishName,
                        serpentDetail.SinhalaName,
                        serpentDetail.SerpentMedia,
                        serpentDetail.Venomous,
                        serpentDetail.Family,
                        serpentDetail.SubFamily,
                        serpentDetail.Genus,
                        serpentDetail.SpecialNote,
                        serpentDetail.SpecialNoteSinhala,
                        serpentDetail.Description,
                        serpentDetail.DescriptionSinhala,
                        serpentInstructions.Select(si => si.InstructionToInstructionDto()).ToList()
                )
                {
                        SerpentId = serpentDetail.SerpentId,
                        ScientificName = serpentDetail.ScientificName,
                        EnglishName = serpentDetail.EnglishName,
                        SinhalaName = serpentDetail.SinhalaName,
                        SerpentMedia = serpentDetail.SerpentMedia,
                        Venomous = serpentDetail.Venomous,
                        Family = serpentDetail.Family,
                        SubFamily = serpentDetail.SubFamily,
                        Genus = serpentDetail.Genus,
                        Description = serpentDetail.Description,
                        DescriptionSinhala = serpentDetail.DescriptionSinhala,
                        Instructions = serpentInstructions.Select(si => si.InstructionToInstructionDto()).ToList()
                };
                return serpent;
        }


        public static Serpent SerpentDtoToSerpent (SerpentDto serpent) =>
        new()
        {
            SerpentId = serpent.SerpentId,
            ScientificName = serpent.ScientificName,
            EnglishName = serpent.EnglishName,
            SinhalaName = serpent.SinhalaName,
            SerpentMedia = serpent.SerpentMedia,
            Venomous = serpent.Venomous,
            Family = serpent.Family,
            SubFamily = serpent.SubFamily,
            Genus = serpent.Genus,
            SpecialNote = serpent.SpecialNote,
            SpecialNoteSinhala = serpent.SpecialNoteSinhala,
            Description = serpent.Description,
            DescriptionSinhala = serpent.DescriptionSinhala
        };



                // Foreign Key References
                public RequestService RequestService { get; set; } = null!;
                [InverseProperty("PredictedSerpent")] public ScannedImage ScannedImagePred { get; set; } = null!;
                [InverseProperty("ActualSerpent")] public ScannedImage ScannedImageAct { get; set; } = null!;
                [InverseProperty("SerpentPredict")] public ScannedImageReview SerpentPredict { get; set; } = null!;
                [InverseProperty("SerpentActual")] public ScannedImageReview SerpentActual { get; set; } = null!;
                public SerpentInstruction SerpentInstruction { get; set; } = null!;
    }
}