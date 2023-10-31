using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class ZoologistRequestsDto
{
    public long ZoologistId { get; set; }//User->UserId
    // public string? FullName { get; set; }
    public string? Description { get; set; }
    public string? SpecialNote { get; set; }   
    public DateTime? RequestedDateTime { get; set; } = DateTime.Now;
    public long Status { get; set; } = 1;
    public long? ApprovedPersonId { get; set; } = null;
    public DateOnly? ApprovedDate { get; set; }  

    // public long? RequestToBeZoologistEvidenceId { get; set; }
    public string Certificate { get; set; }
    public string DegreeName { get; set; }
    public string University { get; set; }
    public string GraduatedYear { get; set; }
    public string? SpecialDetails { get; set; }


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


    // dto constructor for retrieve
    public ZoologistRequestsDto(long zoologistId, string? description, string? specialNote, DateTime? requestedDateTime, long status, long? approvedPersonId, DateOnly? approvedDate, string certificate, string degreeName, string university, string graduatedYear, string? specialDetails, UserDetail? user)
    {
        ZoologistId = zoologistId;
        // FullName = catcherId;
        Description = description;
        SpecialNote = specialNote;
        RequestedDateTime = requestedDateTime;
        Status = status;
        ApprovedPersonId = approvedPersonId;
        ApprovedDate = approvedDate;
        // RequestToBeZoologistEvidenceId = requestToBeZoologistEvidenceId;
        Certificate = certificate;
        DegreeName = degreeName;
        University = university;
        GraduatedYear = graduatedYear;
        SpecialDetails = specialDetails;

        UserFirstName = user.FirstName;
        UserLastName = user.LastName;
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
    public ZoologistRequestsDto(long zoologistId, string? description, string? specialNote, DateTime? requestedDateTime, long status, long? approvedPersonId, DateOnly? approvedDate, string certificate, string degreeName, string university, string graduatedYear, string specialDetails, string firstName)
    {
        ZoologistId = zoologistId;
        // FullName = catcherId;
        Description = description;
        SpecialNote = specialNote;
        RequestedDateTime = requestedDateTime;
        Status = status;
        ApprovedPersonId = approvedPersonId;
        ApprovedDate = approvedDate;
        // RequestToBeZoologistEvidenceId = requestToBeZoologistEvidenceId;
        Certificate = certificate;
        DegreeName = degreeName;
        University = university;
        GraduatedYear = graduatedYear;
        SpecialDetails = specialDetails;
    }

    
}