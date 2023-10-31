namespace VenomVerseApi.Models;

public class AuthResponse
{
    public required string Username { get; set; } = null!;
    public required string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}