namespace VenomVerseApi.Models;

public class RegistrationRequest{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}