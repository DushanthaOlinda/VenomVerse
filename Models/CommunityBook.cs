using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models;

public class CommunityBook{

    public required long CommunityBookId { get; set; }
    public required string Category { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string Content { get; set; } = null!;
    public required bool Availability { get; set;}      // Paid or Free
    
    public string[]? Media { get; set;}             // pdf location -> directly load from the app
    public required string Author { get; set;}

    public DateOnly? PublishedDate { get; set;}
    public required DateOnly UploadedDate { get; set;}

    [ForeignKey("Zoologist")] public required long UploadedUserId { get; set;}         // Zoologists upload books
    // [ForeignKey("CommunityAdmin")] public long? ApprovedUserId { get; set;}         // Community admins approves the articles
    public string[]? BookCopyright { get; set; }


            // Foreign Key References
            // public UserDetail User { get; set; } = null!;
            // public CommunityAdmin CommunityAdmin { get; set; } = null!;
            public Zoologist Zoologist { get; set; } = null!;
            public UserDetail User { get; set; } = null!;

}