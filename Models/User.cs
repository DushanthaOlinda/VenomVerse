namespace VenomVerseApi.Models;

public class User{
    public long Id { get; set; }
    public string? UserName { get; set; }

    public string? UserEmail { get; set; }  

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? Address { get; set; }
}