using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class CatcherReqDto
{
    // dto constructor for retrieve
    public CatcherReqDto(long reqId, long catcherId, string[] catcherEvidence, string? description, string? specialNote, long? approvedPersonIdOne, DateOnly? approvedDateOne, long? approvedPersonIdTwo, DateOnly? approvedDateTwo, long? approvedPersonIdThree, DateOnly? approvedDateThree, DateOnly? joinedDate, bool approvedFlag, UserDetail? user)
    {
        ReqId = reqId;
        ReqCatcher = catcherId;
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
        UserFirstName = user.FirstName;
        UserFirstName = user.LastName;
        UserEmail = user.UserEmail;
        Nic = user.Nic;
        Dob = user.Dob;
        District = user.District;
        Address = user.Address;
        ContactNo = user.ContactNo;
        WorkingStatus = user.WorkingStatus;
        ExpertPrivilege = user.ExpertPrivilege;
        ZoologistPrivilege = user.ZoologistPrivilege;
        CatcherPrivilege = user.CatcherPrivilege;
        CommunityAdminPrivilege = user.CommunityAdminPrivilege;
        AccountStatus = user.AccountStatus;
    }

    // dto constructor for insert
    public CatcherReqDto(long reqId, long catcherId, string[] catcherEvidence, string? description, string? specialNote)
    {
        ReqId = reqId;
        ReqCatcher = catcherId;
        // CatcherName = catcherName;
        CatcherEvidence = catcherEvidence;
        Description = description;
        SpecialNote = specialNote;
    }

    // public CatcherReqDto(long reqId, long catcherId, string[] catcherEvidence, string? description, string? specialNote, long? approvedPersonIdOne, DateOnly? approvedDateOne, long? approvedPersonIdTwo, DateOnly? approvedDateTwo, long? approvedPersonIdThree, DateOnly? approvedDateThree, DateOnly? joinedDate, bool approvedFlag) : this(reqId, catcherId, catcherEvidence, description, specialNote)
    // {
    // }

    public long ReqId { get; set; } 
    public long ReqCatcher { get; set; }
    // public string CatcherName { get; set; }
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


    public string? UserFirstName { get; set; } = null;
    public string? UserLastName { get; set; } = null;
    public string UserEmail { get; set; } = null!;
    public string Nic { get; set; } = null!;
    public DateOnly Dob { get; set; }  
    public string District { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ContactNo { get; set; } = null!;
    public string WorkingStatus { get; set; } = null!; 
    public bool ExpertPrivilege { get; set; } = false;
    public bool ZoologistPrivilege { get; set; } = false;
    public bool CatcherPrivilege { get; set; } = false;
    public bool CommunityAdminPrivilege { get; set; } = false;
    public string AccountStatus { get; set; } = null!; 
}