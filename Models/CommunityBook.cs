using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityBook{

    public required long CommunityBookId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string Content { get; set; } = null!;
    public required bool Availability { get; set;} = true;      // Paid->false or Free->true
    
    public string[]? Media { get; set;}             // pdf location -> directly load from the app
    public required string Author { get; set;}

    public DateOnly? PublishedDate { get; set;}
    public required DateOnly UploadedDate { get; set;}

    public required long UploadedUserId { get; set;}         // Zoologists upload books
    // [ForeignKey("CommunityAdmin")] public long? ApprovedUserId { get; set;}         // Community admins approves the articles
    public string[]? BookCopyright { get; set; }


            // Foreign Key References
            // public UserDetail User { get; set; } = null!;
            // public CommunityAdmin CommunityAdmin { get; set; } = null!;
            [ForeignKey("UploadedUserId")] public Zoologist Zoologist { get; set; } = null!;
            [InverseProperty("CommunityBookSaved")] public List<UserDetail> ScannedImagePred { get; set; } = null!;
            [InverseProperty("CommunityBookPurchased")] public List<UserDetail> ScannedImageAct { get; set; } = null!;
}