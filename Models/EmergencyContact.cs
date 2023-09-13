namespace VenomVerseApi.Models
{
    public class EmergencyContact {
        public required long EmergencyContactId { get; set; }
        public required string EmergencyContactNumber { get; set; }
        public string? HospitalName { get; set; }
        public string? PersonName { get; set; }
        public string? Profession { get; set; }
        public string? Description { get; set; }
        public string? EmergencySpecialNote { get; set; } 
    }
}