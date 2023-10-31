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

        public required string Certificate { get; set; }
        public required string DegreeName { get; set; }
        public required string University { get; set; }
        public required string GraduatedYear { get; set; }
        public string? SpecialDetails { get; set; }


        public static ZoologistRequestsDto ToZoologistRequestsDto(Zoologist zoologist, UserDetail user)
        {
                var zoologistReq = new ZoologistRequestsDto(
                
                        zoologist.ZoologistId,
                // FullName = catcherId;
                        zoologist.Description,
                        zoologist.SpecialNote,
                        zoologist.RequestedDateTime,
                        zoologist.Status,
                        zoologist.ApprovedPersonId,
                        zoologist.ApprovedDate,
                        // RequestToBeZoologistEvidenceId = requestToBeZoologistEvidenceId,
                        zoologist.Certificate,
                        zoologist.DegreeName,
                        zoologist.University,
                        zoologist.GraduatedYear,
                        zoologist.SpecialDetails,
                        user
                );
                return zoologistReq;
        }

        public static Zoologist ToZoologist ( ZoologistRequestsDto zoologistDto )
        {
                return new Zoologist
                {
                        ZoologistId = zoologistDto.ZoologistId,
                        Description = zoologistDto.Description,
                        SpecialNote = zoologistDto.SpecialNote,
                        RequestedDateTime = DateTime.Now,
                        Status = zoologistDto.Status,
                        ApprovedPersonId = zoologistDto.ApprovedPersonId,
                        ApprovedDate = zoologistDto.ApprovedDate,
                        Certificate = zoologistDto.Certificate,
                        DegreeName = zoologistDto.DegreeName,
                        University = zoologistDto.University,
                        GraduatedYear = zoologistDto.GraduatedYear,
                        SpecialDetails = zoologistDto.SpecialDetails,
                };
        }

                // Foreign Key References
                [ForeignKey("ZoologistId")] public UserDetail User { get; set; } = null!;
                // [InverseProperty("ZoologistApprove")] public Question QuestionApprove { get; set; } = null!;
                // [InverseProperty("ZoologistWrite")] public Question QuestionWrite { get; set; } = null!;
                [ForeignKey("ApprovedPersonId")]public CommunityAdmin? CommunityAdmin { get; set; } = null;
                public CommunityResearch CommunityResearch { get; set; } = null!;
    }
}
