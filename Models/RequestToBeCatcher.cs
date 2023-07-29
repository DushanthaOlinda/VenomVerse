namespace VenomVerseApi.Models;

public class RequestToBeCatcher{

    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string[] CatcherEvidence { get; set; } = null!;
    public string Description { get; set; }
    public string SpecialNote { get; set; }   
    // If other necessary details plz mention here

    public long? ApprovedPersonIdOne { get; set; }
    public DateOnly? ApprovedDateOne { get; set; }
    public long? ApprovedPersonIdTwo { get; set; }
    public DateOnly? ApprovedDateTwo { get; set; }
    public long? ApprovedPersonIdThree { get; set; }
    public DateOnly? ApprovedDateThree { get; set; }      
    public DateOnly? JoinedDate { get; set; }   

}