using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class SystemReport {
        [ForeignKey("SystemAdmin")] public required long SystemReportId { get; set; }
        public required string Type { get; set; } = null!;      
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required long? GeneratedUserId { get; set;}


                // Foreign Key References
                public SystemAdmin SystemAdmin { get; set; } = null!;
        
        //content? -> can have many types, use seperate tables

        //report types
            //monthly - newly registered users
            //newly appointed catchers - requests vs approvals
            //newly appointed zoologists - requests vs approvals
            //newly appointed com admins
            //service requests, completed services, feedbacks, ratings - detailed service list
            //book article post research publication - detailed report
    }
}
