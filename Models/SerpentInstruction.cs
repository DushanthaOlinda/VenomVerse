using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{
    public class SerpentInstruction{
        public required long SerpentInstructionId { get; set; }
        public required long SerpentId { get; set; }//Serpent->SerpentId 
        public required string InsDetail { get; set; }
        public required string InsDetailSinhala { get; set; }
        public required long WittenUser { get; set; } // User -> Written User
        // public long[]? PositiveVote { get; set; }   
        // public long[]? NegativeVote { get; set; }   


        
        public static SerpentInstructionDto InstructionToInstructionDto(SerpentInstruction serpentInstructions)
        {
            return new SerpentInstructionDto(
                serpentInstructions.SerpentInstructionId,
                serpentInstructions.SerpentId,
                serpentInstructions.WittenUser,
                serpentInstructions.InsDetail,
                serpentInstructions.InsDetailSinhala
            );
        }

        public SerpentInstructionDto InstructionToInstructionDto()
        {
            return new SerpentInstructionDto(
                this.SerpentInstructionId,
                this.SerpentId,
                this.WittenUser,
                this.InsDetail,
                this.InsDetailSinhala
            );
        }


                // Foreign Key References
                [ForeignKey("WittenUser")] public Zoologist WrittenUser { get; set; } = null!;
                // [ForeignKey("PositiveVote")] public List<UserDetail> UserPos { get; set; } = null!;
                // [ForeignKey("NegativeVote")] public List<UserDetail> UserNeg { get; set; } = null!;
                [ForeignKey("SerpentId")] public Serpent Serpent { get; set; } = null!;
    }
}