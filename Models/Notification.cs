namespace VenomVerseApi.Models
{
    public class Notification {
        public required long NotificationId { get; set; }
        public required long UserId { get; set;}
        public required string Type { get; set; } = null!;      
        public required DateTime DateTime { get; set; } = DateTime.Now;
        
        //content? -> can have many types, use seperate tables
        
        // Notification types
            //Like to a post - user
            //Comment to a post - user
            //Reported post approvals - user
            //Reported account warning - user
            //service request - catchers
            //service request cancellation - catchers
            //New book publication ?
            //to be catcher approval - catcher
            //to be zoologist - zoologist
    }
}
