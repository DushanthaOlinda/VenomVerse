namespace VenomVerseApi.Models
{
    public class Notification {
        public long Id { get; set; }
        public string type { get; set; } = null!;      
        public DateTime DateTime { get; set; } = DateTime.Now;
        public long UserId { get; set;}
        
        //content? -> can have many types, use seperate tables
    }
}
