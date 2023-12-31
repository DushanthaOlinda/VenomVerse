using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Models;

public class UserDetail{
    public required long UserDetailId { get; set; }
    public required string UserName { get; set; } = null!;       // Generate a unique username automatically
    public required string FirstName { get; set; } = null!;
    public required string LastName { get; set; } = null!;
    public required string UserEmail { get; set; } = null!;

    public required float CurrentMarks { get; set; } = 0;          // Total marks from all quizzes
    public const float ExpertMinMarks = 1000;                       // Min marks to achieve expert privileges

    public required string Nic { get; set; } = null!;
    public required DateOnly Dob { get; set; }        // Required -> validation
    public required string District { get; set; } = null!;
    public required string Address { get; set; } = null!;
    public required string ContactNo { get; set; } = null!;
    //public required string? LiveLocation { get; set; } = null;   
    public required string WorkingStatus { get; set; } = null!;         // student, officer

    public required string ProfileImage { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Antu_im-user-online.svg/512px-Antu_im-user-online.svg.png"; 
    
    public long[]? SavedBook { get; set; }
    public long[]? SavedArticle { get; set; } 
    public long[]? SavedPost { get; set; }
    public long[]? SavedResearch { get; set; }
    public long[]? PurchasedBook { get; set; }          //  [ user, book, price, date time, paymentid -> payment ]

    public bool ExpertPrivilege { get; set; } = false;
    public bool ZoologistPrivilege { get; set; } = false;
    public bool CatcherPrivilege { get; set; } = false;
    public bool CommunityAdminPrivilege { get; set; } = false;
    public required string AccountStatus { get; set; } = null!;  // Active, Inactive, Deleted, Suspended etc...


    public static UserDto UserToUserDto(UserDetail user) =>
        new UserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            UserId = user.UserDetailId,
            UserEmail = user.UserEmail,
            CurrentMarks = user.CurrentMarks,
            Nic = user.Nic,
            Dob = user.Dob,
            District = user.District,
            Address = user.Address,
            ContactNo = user.ContactNo,
            WorkingStatus = user.WorkingStatus,
            ExpertPrivilege = user.ExpertPrivilege,
            ZoologistPrivilege = user.ZoologistPrivilege,
            CatcherPrivilege = user.CatcherPrivilege,
            CommunityAdminPrivilege = user.CommunityAdminPrivilege,
            ProfileImage = user.ProfileImage
        };

    public static UserDetail UserDtoToUserDetail(UserDto userDto) =>
        new UserDetail
        {
            UserDetailId = (long)userDto.UserId!,
            FirstName = userDto.FirstName!,
            LastName = userDto.LastName!,
            UserEmail = userDto.UserEmail!,
            CurrentMarks = (float)userDto.CurrentMarks!,
            UserName = userDto.UserName!,
            Nic = userDto.Nic!,
            Dob = (DateOnly)userDto.Dob!,
            District = userDto.Dob.ToString()!,
            Address = userDto.Address!,
            ContactNo = userDto.ContactNo!,
            WorkingStatus = userDto.WorkingStatus!,
            AccountStatus = userDto.AccountStatus!,
            ProfileImage = userDto.ProfileImage,
        };


    
    // Foreign Key References
    public Catcher? Catcher { get; set; } = null;
    public CommunityAdmin CommunityAdmin { get; set; } = null!;
    [ForeignKey("SavedArticle")] public List<CommunityArticle> UserSavedArticle { get; set; } = null!;
    [InverseProperty("UserReact")] public List<CommunityArticle> UserReactArticle { get; set; } = null!;
    [InverseProperty("User")] public CommunityArticle UserArticle { get; set; } = null!;
    [ForeignKey("SavedPost")] public List<CommunityPost> UserSavedPost { get; set; } = null!;
    [InverseProperty("UserPostReact")] public List<CommunityPost> UserReactPost { get; set; } = null!;
    [InverseProperty("PostUser")] public CommunityPost UserPost { get; set; } = null!;
    [ForeignKey("SavedBook")] public List<CommunityBook> CommunityBookSaved { get; set; } = null!;
    [ForeignKey("PurchasedBook")] public List<CommunityBook> CommunityBookPurchased { get; set; } = null!;
    [ForeignKey("SavedResearch")] public List<CommunityResearch> CommunityResearch { get; set; } = null!;
    public Notification? Notification { get; set; } = null;
    public Question? Question { get; set; } = null;
    public QuizAttempt? QuizAttempt { get; set; } = null;
    public RequestService? RequestService { get; set; } = null;
    public ScannedImage? ScannedImage { get; set; } = null;
    public Zoologist? Zoologist { get; set; } = null;
    // [InverseProperty("UserPos")] public SerpentInstruction? SerpentInstructionPos { get; set; } = null!;
    // [InverseProperty("UserNeg")] public SerpentInstruction? SerpentInstructionNeg { get; set; } = null!;
}