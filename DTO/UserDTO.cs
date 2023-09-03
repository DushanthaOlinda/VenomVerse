namespace VenomVerseApi.DTO;

public class UserDto
{
    public long? UserId { get; set; }
    // public byte[]? UserProfilePicture { get; set; }
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
}