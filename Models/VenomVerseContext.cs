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

    public DbSet<UserDetail> UserDetail { get; set; } = default!;
    public DbSet<RegistrationRequest> RegistrationRequest { get; set; } = default!;

    public DbSet<VenomVerseApi.Models.CommunityPost> CommunityPost { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.Zoologist> Zoologist { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.Catcher> Catcher { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.CommunityAdmin> CommunityAdmin { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.CommunityArticle> CommunityArticle { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.CommunityBook> CommunityBook { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.RequestService> RequestService { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.RequestToBeCatcher> RequestToBeCatcher { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.RequestToBeZoologist> RequestToBeZoologist { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.SystemAdmin> SystemAdmin { get; set; } = default!;
    public DbSet<VenomVerseApi.Models.SystemReport> SystemReport { get; set; } = default!;
}