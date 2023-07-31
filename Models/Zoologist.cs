namespace VenomVerseApi.Models
{
    public class Zoologist {
        public long Id { get; set; }
        public DateOnly ApprovedDate { get; set; }
        public long RequestId { get; set; }   
        public string[]? Certification { get; set; }
    }
}
