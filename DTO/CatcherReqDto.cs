namespace VenomVerseApi.DTO;

public class CatcherReqDto
{
    public CatcherReqDto(long reqId, long catcherId, string catcherName, string[] catcherEvidence, string? description, string? specialNote, long? approvedPersonIdOne, DateOnly? approvedDateOne, long? approvedPersonIdTwo, DateOnly? approvedDateTwo, long? approvedPersonIdThree, DateOnly? approvedDateThree, DateOnly? joinedDate, bool approvedFlag)
    {
        ReqId = reqId;
        ReqCatcher = catcherId;
        CatcherName = catcherName;
        CatcherEvidence = catcherEvidence;
        Description = description;
        SpecialNote = specialNote;
        ApprovedPersonIdOne = approvedPersonIdOne;
        ApprovedDateOne = approvedDateOne;
        ApprovedPersonIdTwo = approvedPersonIdTwo;
        ApprovedDateTwo = approvedDateTwo;
        ApprovedPersonIdThree = approvedPersonIdThree;
        ApprovedDateThree = approvedDateThree;
        JoinedDate = joinedDate;
        ApprovedFlag = approvedFlag;
    }

    public long ReqId { get; set; } 
    public long ReqCatcher { get; set; }
    public string CatcherName { get; set; }
    public string[] CatcherEvidence { get; set; }
    public string? Description { get; set; }
    public string? SpecialNote { get; set; }   

    public long? ApprovedPersonIdOne { get; set; } //catcher -> catcherId
    public DateOnly? ApprovedDateOne { get; set; }
    public long? ApprovedPersonIdTwo { get; set; }//catcher -> catcherId
    public DateOnly? ApprovedDateTwo { get; set; }
    public long? ApprovedPersonIdThree { get; set; }//catcher -> catcherId
    public DateOnly? ApprovedDateThree { get; set; }     
    public DateOnly? JoinedDate { get; set; }
    public bool ApprovedFlag { get; set; }
}