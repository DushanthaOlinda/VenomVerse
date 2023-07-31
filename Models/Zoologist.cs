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
        public required long Id { get; set; }
        public string? Description { get; set; }
        public string? SpecialNote { get; set; }   
        public required string[,] Certification { get; set; }

        public required DateTime RequestedDateTime { get; set; } = DateTime.Now;
        public long? ApprovedPersonId { get; set; }
        public DateOnly? ApprovedDate { get; set; }  
    }
}
