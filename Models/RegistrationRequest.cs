namespace VenomVerseApi.Models;

public class RegistrationRequest{
    public required long RegistrationRequestId { get; set; }
    public required string Email { get; set; } = null!;
    public required string Username { get; set; } = null!;
    public required string Password { get; set; } = null!;
}