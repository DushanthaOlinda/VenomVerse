using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;

namespace VenomVerseApi.Models;

public class UserDetail{
    public required long UserDetailId { get; set; }
    public required string UserName { get; set; } = null!;       // Generate a unique username automatically
    public required string FirstName { get; set; } = null!;
    public required string LastName { get; set; } = null!;
    public required string UserEmail { get; set; } = null!;
    public required string Nic { get; set; } = null!;
    public required DateOnly Dob { get; set; }        // Required -> validation
    public required string District { get; set; } = null!;
    public required string Address { get; set; } = null!;
    public required string ContactNo { get; set; } = null!;
    //public required string? LiveLocation { get; set; } = null;   
    public required string WorkingStatus { get; set; } = null!;

    public long[]? SavedBook { get; set; }
    public long[]? SavedArticle { get; set; }
    public long[]? SavedPost { get; set; }
    public long[]? SavedResearch { get; set; }
    public long[]? PurchasedBook { get; set; }

    public bool ExpertPrevilege { get; set; } = false;
    public bool ZoologistPrevilege { get; set; } = false;
    public bool CatcherPrevilege { get; set; } = false;
    public bool CommunityAdminPrevilege { get; set; } = false;
    public required string AccountStatus { get; set; } = null!;  // Active, Inactive, Deleted, Suspended etc...


    
    // Foreign Key References
    public Catcher Catcher { get; set; } = null!;
}