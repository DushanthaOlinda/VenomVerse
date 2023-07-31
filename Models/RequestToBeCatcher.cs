namespace VenomVerseApi.Models;

public class RequestToBeCatcher{

    public required long Id { get; set; }
    public required long UserId { get; set; }
    public required DateTime DateTime { get; set; } = DateTime.Now;
    public required string[] CatcherEvidence { get; set; } = null!;
    public string? Description { get; set; }
    public string? SpecialNote { get; set; }   
    // If other necessary details plz mention here

    public long? ApprovedPersonIdOne { get; set; }
    public DateOnly? ApprovedDateOne { get; set; }
    public long? ApprovedPersonIdTwo { get; set; }
    public DateOnly? ApprovedDateTwo { get; set; }
    public long? ApprovedPersonIdThree { get; set; }
    public DateOnly? ApprovedDateThree { get; set; }      
    public DateOnly? JoinedDate { get; set; }   

}