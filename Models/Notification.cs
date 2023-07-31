namespace VenomVerseApi.Models
{
    public class Notification {
        public required long Id { get; set; }
        public required long UserId { get; set;}
        public required string type { get; set; } = null!;      
        public required DateTime DateTime { get; set; } = DateTime.Now;
        
        //content? -> can have many types, use seperate tables
    }
}
