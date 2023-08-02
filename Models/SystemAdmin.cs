namespace VenomVerseApi.Models
{
    public class SystemAdmin {
        public required long SystemAdminId { get; set; }
        public required string UserName { get; set; } = null!;       // Generate a unique username automatically
        public required DateOnly? JoinedDate { get; set; }
        public required string FirstName { get; set; } = null!;
        public required string LastName { get; set; } = null!;
        public required string UserEmail { get; set; } = null!;
        public required string Password { get; set; } = null!;
        public required string Nic { get; set; } = null!;
    }
}
