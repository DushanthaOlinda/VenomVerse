using Microsoft.EntityFrameworkCore;
using VenomVerseApi.Models;

namespace VenomVerseApi.Models;

public class VenomVerseContext : DbContext
{
    public VenomVerseContext(DbContextOptions<VenomVerseContext> options)
        : base(options)
    {
    }
protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.UseSerialColumns();
    }
    public DbSet<VenomVerseItem> VenomVerseItems { get; set; } = null!;
    public DbSet<TaskItem> TaskItem { get; set; } = default!;
}
