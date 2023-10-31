namespace VenomVerseApi.DTO;

public class UserDto
{
    public long? UserId { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserEmail { get; set; }
    public float? CurrentMarks { get; set; } = 0; // Total marks from all quizzes
    public string? Nic { get; set; }
    public DateOnly? Dob { get; set; } // Required -> validation
    public string? District { get; set; }
    public string? Address { get; set; }

    public string? ContactNo { get; set; }

    //public required string? LiveLocation { get; set; } = null;   
    public string? WorkingStatus { get; set; }
    public string? AccountStatus { get; set; }
    
    public bool ExpertPrivilege { get; set; } = false;
    
    public bool ZoologistPrivilege { get; set; } = false;
    
    public bool CatcherPrivilege { get; set; } = false;
    
    public bool CommunityAdminPrivilege { get; set; } = false;  
    
    public string ProfileImage { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Antu_im-user-online.svg/512px-Antu_im-user-online.svg.png";
}