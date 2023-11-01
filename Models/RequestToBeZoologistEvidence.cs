using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{    public class RequestToBeZoologistEvidence {
        public required long RequestToBeZoologistEvidenceId { get; set; }
        public required long ZoologistId { get; set; }//Zoologist->ZoologistId

        public required string DegreeName { get; set; }
        public required string University { get; set; }
        public required string GraduatedYear { get; set; }
        public string? SpecialDetails { get; set; }
        
        // Foreign Key References
        [ForeignKey("ZoologistId")] public Zoologist Zoologist { get; set; } = null!;

    }
}
