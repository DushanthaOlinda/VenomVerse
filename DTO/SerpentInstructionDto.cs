using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class SerpentInstructionDto
{
    public long SerpentInstructionId { get; set; }
    public long SerpentId { get; set; }
    public long WrittenUser { get; set; }
    public string Description { get; set; }
    // public long[]? PositiveVote { get; set; }   
    // public long[]? NegativeVote { get; set; }  

    public SerpentInstructionDto( long serpentInstructionId, long serpentId, long writtenUser, string description )
    {
       SerpentInstructionId = serpentInstructionId;
       SerpentId = serpentId;
       WrittenUser = writtenUser;
       Description = description;
    }
    
}