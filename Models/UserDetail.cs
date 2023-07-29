namespace VenomVerseApi.Models;

public class UserDetail{
    public long Id { get; set; }
    public string UserName { get; set; } = null!;
    public string UserEmail { get; set; } = null!;
    public string Password { get; set; } = null!;
}