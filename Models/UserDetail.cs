namespace VenomVerseApi.Models;

public class UserDetail{
    public long Id { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public required string Password { get; set; }
}