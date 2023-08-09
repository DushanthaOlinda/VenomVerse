using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class Notification {
        public required long NotificationId { get; set; }
        public required long UserId { get; set;}
        public required string Type { get; set; } = null!;      
        public required DateTime DateTime { get; set; } = DateTime.Now;

        // public string? NotificationString { get; set; }

        // Isuru heshan commented on your post on snakes
        // string = {name} commented on your post on { post id/ description }


                // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;
        
        //content? -> can have many types, use seperate tables
        

        // NotificationBroadcast - NotificationBroadcastId, Type, DateTime
            //NotiNewBookPublication - NotificationId, BookId

        // Notification User types
            //NotiLikePost - NotificationId, PostId, LikedUserId,
            //NotiCommentPost - NotificationId, PostId, PostCommentId
            //NotiPostReportApprovals - NotificationId, PostId
            //NotiPostReportWarning - NotificationId, PostId
            //NotiCatcherServiceRequest - NotificationId, ReqServiceId, Status => None, Approved, Declined

            //NotiToBeCatcher - NotificationId, ReqId, Status => None, Approved, Declined
            //NotiToBeZoologist - NotificationId, ReqId, Status => None, Approved, Declined
    }
}
