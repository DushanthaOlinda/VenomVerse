using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class Notification {
        public required long NotificationId { get; set; }
        public required long UserId { get; set;}//User->UserId
        public required string Type { get; set; } = null!;      
        public required DateTime DateTime { get; set; } = DateTime.Now;


                // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;
        
        //content? -> can have many types, use seperate tables
        
        // Notification types
            //Like to a post - user                         last liked user, count, postid    -> "{last liked user} and {count-1} liked your {post}"
            //Comment to a post - user                      commenteduser, postid             -> "{commenteduser} commented on your post on {postid.topic}"
            //Reported post approvals - user
            //Reported account warning - user
            //service request - catchers
            //service request cancellation - catchers
            //New book publication ?
            //to be catcher approval - catcher
            //to be zoologist - zoologist
    }
}
