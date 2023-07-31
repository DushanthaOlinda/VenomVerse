namespace VenomVerseApi.Models
{
    public class SystemReport {
        public long Id { get; set; }
        public string type { get; set; } = null!;      
        public DateTime DateTime { get; set; } = DateTime.Now;
        public long? GeneratedUserId { get; set;}
        
        //content? -> can have many types, use seperate tables
    }
}
