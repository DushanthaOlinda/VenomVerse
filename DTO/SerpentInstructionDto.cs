using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class SerpentInstructionDto
{
    public long SerpentInstructionId { get; set; }
    public long SerpentId { get; set; }
    public long WrittenUser { get; set; }
    public string InsDetail { get; set; }
    public string InsDetailSinhala { get; set; }

    public string? WrittenUserFirstName { get; set; } = null;
    public string? WrittenUserLastName { get; set; } = null;
    // public long[]? PositiveVote { get; set; }   
    // public long[]? NegativeVote { get; set; }  

    public SerpentInstructionDto( long serpentInstructionId, long serpentId, long writtenUser, string insDetail, string insDetailSinhala )
    {
       SerpentInstructionId = serpentInstructionId;
       SerpentId = serpentId;
       WrittenUser = writtenUser;
       InsDetail = insDetail;
       InsDetailSinhala = insDetailSinhala;
    }
    
}