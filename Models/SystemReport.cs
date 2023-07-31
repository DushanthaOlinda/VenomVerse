namespace VenomVerseApi.Models
{
    public class SystemReport {
        public required long Id { get; set; }
        public required string type { get; set; } = null!;      
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required long? GeneratedUserId { get; set;}
        
        //content? -> can have many types, use seperate tables
    }
}
