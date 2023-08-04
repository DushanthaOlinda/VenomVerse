using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public struct ZoologistCertificationStruct {        //Try to way to map
        public long CertificateId { get; set; }
        public string DegreeName { get; set; }
        public string University { get; set; }
        public int GraduatedYear { get; set; }
        public string? CertificateSpecialNote { get; set; }
    }

    public class Zoologist {

        public required long ZoologistId { get; set; }
        
        public string? Description { get; set; }
        public string? SpecialNote { get; set; }   
        public required string[,] Certification { get; set; }

        public required DateTime RequestedDateTime { get; set; } = DateTime.Now;
        public long? ApprovedPersonId { get; set; }
        public DateOnly? ApprovedDate { get; set; }  

                // Foreign Key References
                [ForeignKey("ZoologistId")] public UserDetail User { get; set; } = null!;
                public Question Question { get; set; } = null!;
                public CommunityResearch CommunityResearch { get; set; } = null!;
                public CommunityBook? CommunityBook { get; set; } = null!;

    }
}
