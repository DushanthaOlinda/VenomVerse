namespace VenomVerseApi.Models
{
    public class EmergencyContact {
        public long Id { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string? HospitalName { get; set; }
        public string? PerssonName { get; set; }
        public string? Profession { get; set; }
        public string? Description { get; set; }
        public string? EmergencySpecialNote { get; set; } 
    }
}