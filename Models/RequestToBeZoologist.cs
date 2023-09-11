using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{    public class RequestToBeZoologist {
        public required long RequestToBeZoologistId { get; set; }
        public required long ReqUserId { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public string? Description { get; set; }

        
    }
}
