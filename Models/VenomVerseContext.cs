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
    public DbSet<VenomVerseItem> VenomVerseItems { get; set; } = null!;
    public DbSet<TaskItem> TaskItem { get; set; } = default!;
    public DbSet<UserDetail> UserDetail { get; set; } = default!;

    public DbSet<RegistrationRequest> RegistrationRequest { get; set; } = default!;
}