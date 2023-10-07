using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VenomVerseApi.Models;

public class VenomVerseContext : IdentityUserContext<IdentityUser>
{
    public VenomVerseContext(DbContextOptions<VenomVerseContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseSerialColumns();
    }


    // Define Models to connect with the database 

    public DbSet<Catcher> Catcher { get; set; } = default!;
    public DbSet<CatcherRating> CatcherRating { get; set; } = default!;
    public DbSet<CommunityAdmin> CommunityAdmin { get; set; } = default!;
    public DbSet<CommunityArticle> CommunityArticle { get; set; } = default!;
    public DbSet<CommunityArticleComment> CommunityArticleComment { get; set; } = default!;
    public DbSet<CommunityBook> CommunityBook { get; set; } = default!;
    public DbSet<CommunityPost> CommunityPost { get; set; } = default!;
    public DbSet<CommunityPostComment> CommunityPostComment { get; set; } = default!;
    public DbSet<CommunityPostReport> CommunityPostReport { get; set; } = default!;
    public DbSet<CommunityResearch> CommunityResearch { get; set; } = default!;
    public DbSet<EmergencyContact> EmergencyContact { get; set; } = default!;
    public DbSet<Notification> Notification { get; set; } = default!;
    public DbSet<Question> Question { get; set; } = default!;
    public DbSet<QuizAttempt> QuizAttempt { get; set; } = default!;
    public DbSet<QuizDetail> QuizDetail { get; set; } = default!;
    public DbSet<QuizUserAnswer> QuizUserAnswer { get; set; } = default!;
    public DbSet<RegistrationRequest> RegistrationRequest { get; set; } = default!; //
    public DbSet<RequestService> RequestService { get; set; } = default!;
    public DbSet<ScannedImage> ScannedImage { get; set; } = default!;
    public DbSet<ScannedImageReview> ScannedImageReview { get; set; } = default!;
    public DbSet<Serpent> Serpent { get; set; } = default!;
    public DbSet<SerpentInstruction> SerpentInstruction { get; set; } = default!;
    public DbSet<SerpentMedia> SerpentMedia { get; set; } = default!;
    public DbSet<SystemAdmin> SystemAdmin { get; set; } = default!;
    public DbSet<SystemReport> SystemReport { get; set; } = default!;
    public DbSet<UserDetail> UserDetail { get; set; } = default!;   //
    public DbSet<Zoologist> Zoologist { get; set; } = default!;
    public DbSet<RequestToBeZoologistEvidence> RequestToBeZoologistEvidence { get; set; } = default!;
}