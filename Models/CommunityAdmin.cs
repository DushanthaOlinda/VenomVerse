namespace VenomVerseApi.Models
{
    public class CommunityAdmin {
        public required long CommunityAdminId { get; set; }
        public required DateOnly? JoinedDate { get; set; }
    }
}
