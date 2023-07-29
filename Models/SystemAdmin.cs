namespace VenomVerseApi.Models
{
    public class SystemAdmin {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;       // Generate a unique username automatically
        public DateOnly? JoinedDate { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nic { get; set; } = null!;
    }
}
