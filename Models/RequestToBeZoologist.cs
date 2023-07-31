namespace VenomVerseApi.Models;

public class RequestToBeZoologist{

    public struct ZoologistCertificationStruct {        //Try to way to map
        public long CertificateId { get; set; }
        public string DegreeName { get; set; }
        public string University { get; set; }
        public int GraduatedYear { get; set; }
        public string? CertificateSpecialNote { get; set; }
    }

    public struct ArticleReportStruct {        //Try to way to map with catcherRating
        public long ArticleReportId { get; set; }
        public long UserId { get; set; }
        public string ArticleReportContent { get; set; }
    }

    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public string SpecialNote { get; set; }   

    public string[,] ZoologistCertification { get; set; } = null!;

    public long? ApprovedPersonId { get; set; }
    public DateOnly? ApprovedDate { get; set; }  
    
}