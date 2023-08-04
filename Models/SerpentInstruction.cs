using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class SerpentInstruction{
        public required long SerpentInstructionId { get; set; }
        public required long SerpentId { get; set; }
        public required string Description { get; set; }
        public required long WittenUser { get; set; }
        public long[]? PositiveVote { get; set; }   
        public long[]? NegativeVote { get; set; }   

                // Foreign Key References
                [ForeignKey("WittenUser")] public UserDetail WrittenUser { get; set; } = null!;
                [ForeignKey("PositiveVote")] public List<UserDetail> UserPos { get; set; } = null!;
                [ForeignKey("NegativeVote")] public List<UserDetail> UserNeg { get; set; } = null!;
                [ForeignKey("SerpentId")] public Serpent Serpent { get; set; } = null!;
    }
}