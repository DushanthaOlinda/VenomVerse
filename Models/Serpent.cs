using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public struct SerpentMediaStruct {        //Try to way to map with catcherRating
        public long SerpentMediaId { get; set; }
        public string? SerpentMediaDescription { get; set; }
        public string? SerpentMediaAltText { get; set; }
        public string? SerpentMediaSource { get; set; }
    }

    public struct SerpentSafetyInstructionStruct {        //Try to way to map with catcherRating
        public long SerpentSafetyInstructionId { get; set; }
        public string? SerpentSafetyInstructionTitle { get; set; }
        public string? SerpentSafetyInstructionDescription { get; set; }
        public string? SerpentSafetyInstructionWriterId { get; set; }
        public long[]? SerpentSafetyInstructionPositiveVote { get; set; }   
        public long[]? SerpentSafetyInstructionNegativeVote { get; set; }   
    }

    public class Serpent {
        public required long SerpentId { get; set; }
        public required string ScientificName { get; set; }
        public required string EnglishName { get; set; }
        public required string SinhalaName { get; set; }

        public required float Venomous { get; set; }   // 0 ==> non-venomous,   0.1~0.9 ==> middle-venomous-range,  1 ==> high-venomous

        public required string Family { get; set; }
        public required string SubFamily { get; set; }
        public required string Genus { get; set; }

        public string? SpecialNote { get; set; }
        public required string Description { get; set; }

        public string[,]? SerpentMedia { get; set; }
        public string[,]? SerpentSafetyInstruction { get; set; }



        // Foreign Key References
        public RequestService RequestService { get; set; } = null!;
    }
}