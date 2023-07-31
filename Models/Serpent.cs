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
        public long Id { get; set; }
        public string ScientificName { get; set; }
        public string EnglishName { get; set; }
        public string SinhalaName { get; set; }

        public int Venomous { get; set; }   // 0 ==> non-venomous,  1 ==> high-venomous,  2 ==> middle-venomous

        public string Family { get; set; }
        public string SubFamily { get; set; }
        public string Genus { get; set; }

        public string? SpecialNote { get; set; }
        public string Description { get; set; }

        public string[,]? SerpentMedia { get; set; }
        public string[,]? SerpentSafetyInstruction { get; set; }
    }
}