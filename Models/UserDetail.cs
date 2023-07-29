using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;

namespace VenomVerseApi.Models;

public class UserDetail{
    public long Id { get; set; }
    public string UserName { get; set; } = null!;       // Generate a unique username automatically
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserEmail { get; set; } = null!;
    public string Nic { get; set; } = null!;
    [Required] public DateOnly Dob { get; set; }        // Required -> validation
    public string District { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ContactNo { get; set; } = null!;
    //public string? LiveLocation { get; set; } = null;   
    public string WorkingStatus { get; set; } = null!;

    public long[]? SavedBook { get; set; }
    public long[]? SavedArticle { get; set; }
    public long[]? SavedPost { get; set; }
    public long[]? SavedResearch { get; set; }
    public long[]? PurchasedBook { get; set; }

    public bool ExpertPrevilege { get; set; }
    public bool ZoologistPrevilege { get; set; }
    public bool CatcherPrevilege { get; set; }
    public bool CommunityAdminPrevilege { get; set; }
    public string AccountStatus { get; set; } = null!;  // Active, Inactive, Deleted, Suspended etc...
}