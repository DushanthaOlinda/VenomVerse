namespace VenomVerseApi.DTO;

public class ZoologistRequestsDto
{
    public long? ZoologistId { get; set; }//User->UserId
    public string? FullName { get; set; }
    public string? Description { get; set; }
    public string? SpecialNote { get; set; }   
    public DateTime? RequestedDateTime { get; set; } = DateTime.Now;

    public long? RequestToBeZoologistEvidenceId { get; set; }
    public string? DegreeName { get; set; }
    public string? University { get; set; }
    public string? GraduatedYear { get; set; }
    public string? SpecialDetails { get; set; }
}