using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{
    // public struct ZoologistCertificationStruct {        //Try to way to map
    //     public long CertificateId { get; set; }
    //     public string DegreeName { get; set; }
    //     public string University { get; set; }
    //     public int GraduatedYear { get; set; }
    //     public string? CertificateSpecialNote { get; set; }
    // }

    public class Zoologist {

        public required long ZoologistId { get; set; }//User->UserId
        
        public string? Description { get; set; }
        public string? SpecialNote { get; set; }   
        // public required string[,] Certification { get; set; }

        public required DateTime RequestedDateTime { get; set; } = DateTime.Now;
        public long Status { get; set; } = 1; // rejected = 0, pending = 1, accepted = 2
        public long? ApprovedPersonId { get; set; }//ComAdmin->ComAdminId
        public DateOnly? ApprovedDate { get; set; }  


        public static ZoologistRequestsDto ToZoologistRequestsDto(Zoologist zoologist, UserDetail userDetail,
        RequestToBeZoologistEvidence evidence)
    {
        var zoologistReq = new ZoologistRequestsDto()
        {
            FullName = userDetail.FirstName + " " + userDetail.LastName,
            ZoologistId = zoologist.ZoologistId,
            Description = zoologist.Description,
            SpecialNote = zoologist.SpecialNote,
            RequestedDateTime = zoologist.RequestedDateTime,
            RequestToBeZoologistEvidenceId = evidence.RequestToBeZoologistEvidenceId,
            DegreeName = evidence.DegreeName,
            University = evidence.University,
            GraduatedYear = evidence.GraduatedYear,
            SpecialDetails = evidence.SpecialDetails
        };

        return zoologistReq;
    }

                // Foreign Key References
                [ForeignKey("ZoologistId")] public UserDetail User { get; set; } = null!;
                [InverseProperty("ZoologistApprove")] public Question QuestionApprove { get; set; } = null!;
                [InverseProperty("ZoologistWrite")] public Question QuestionWrite { get; set; } = null!;
                [ForeignKey("ApprovedPersonId")]public CommunityAdmin? CommunityAdmin { get; set; } = null;
                public CommunityResearch CommunityResearch { get; set; } = null!;
    }
}
