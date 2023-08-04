using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;

namespace VenomVerseApi.Models;

public class UserDetail{
    public required long UserDetailId { get; set; }
    public required string UserName { get; set; } = null!;       // Generate a unique username automatically
    public required string FirstName { get; set; } = null!;
    public required string LastName { get; set; } = null!;
    public required string UserEmail { get; set; } = null!;

    public required float CurrentMarks { get; set; } = 0;
    public const float ExpertMinMarks = 1000;

    public required string Nic { get; set; } = null!;
    public required DateOnly Dob { get; set; }        // Required -> validation
    public required string District { get; set; } = null!;
    public required string Address { get; set; } = null!;
    public required string ContactNo { get; set; } = null!;
    //public required string? LiveLocation { get; set; } = null;   
    public required string WorkingStatus { get; set; } = null!;

    public long[]? SavedBook { get; set; }
    [ForeignKey("CommunityArticle")] public long[]? SavedArticle { get; set; } 
    [ForeignKey("CommunityPost")] public long[]? SavedPost { get; set; }
    [ForeignKey("CommunityResearch")] public long[]? SavedResearch { get; set; }
    public long[]? PurchasedBook { get; set; }

    public bool ExpertPrevilege { get; set; } = false;
    public bool ZoologistPrevilege { get; set; } = false;
    public bool CatcherPrevilege { get; set; } = false;
    public bool CommunityAdminPrevilege { get; set; } = false;
    public required string AccountStatus { get; set; } = null!;  // Active, Inactive, Deleted, Suspended etc...


    
    // Foreign Key References
    public Catcher Catcher { get; set; } = null!;
    public CommunityAdmin CommunityAdmin { get; set; } = null!;
    public CommunityArticle CommunityArticle { get; set; } = null!;
    [ForeignKey("SavedBook, PurchasedBook")] public CommunityBook CommunityBook { get; set; } = null!;
    public CommunityPost CommunityPost { get; set; } = null!;
    public CommunityResearch CommunityResearch { get; set; } = null!;
    public Notification Notification { get; set; } = null!;
    public Question Question { get; set; } = null!;
    public Quiz Quiz { get; set; } = null!;
    public RequestService RequestService { get; set; } = null!;
    public ScannedImage ScannedImage { get; set; } = null!;
    public Zoologist Zoologist { get; set; } = null!;
}