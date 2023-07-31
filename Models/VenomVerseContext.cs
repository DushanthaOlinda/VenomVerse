using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

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
    public DbSet<CommunityAdmin> CommunityAdmin { get; set; } = default!;
    public DbSet<CommunityArticle> CommunityArticle { get; set; } = default!;
    public DbSet<CommunityBook> CommunityBook { get; set; } = default!;
    public DbSet<CommunityPost> CommunityPost { get; set; } = default!;
    public DbSet<EmergencyContact> EmergencyContact { get; set; } = default!;
    public DbSet<Notification> Notification { get; set; } = default!;
    public DbSet<Question> Question { get; set; } = default!;
    public DbSet<Quiz> Quiz { get; set; } = default!;
    public DbSet<RegistrationRequest> RegistrationRequest { get; set; } = default!; //
    public DbSet<RequestService> RequestService { get; set; } = default!;
    // public DbSet<RequestToBeCatcher> RequestToBeCatcher { get; set; } = default!;
    // public DbSet<RequestToBeZoologist> RequestToBeZoologist { get; set; } = default!;
    public DbSet<ScannedImage> ScannedImage { get; set; } = default!;
    public DbSet<Serpent> Serpent { get; set; } = default!;
    public DbSet<SystemAdmin> SystemAdmin { get; set; } = default!;
    public DbSet<SystemReport> SystemReport { get; set; } = default!;
    public DbSet<UserDetail> UserDetail { get; set; } = default!;   //
    public DbSet<Zoologist> Zoologist { get; set; } = default!;
}