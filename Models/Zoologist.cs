namespace VenomVerseApi.Models
{
    public class Zoologist {
        public required long Id { get; set; }
        public required DateOnly ApprovedDate { get; set; }
        public required long RequestId { get; set; }   
        public string[]? Certification { get; set; }
    }
}
