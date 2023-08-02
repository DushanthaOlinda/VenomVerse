using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class CommunityAdmin {

        [ForeignKey("User")] public required long CommunityAdminId { get; set; }
        
        public required DateOnly? JoinedDate { get; set; }

                // Foreign Key References
                public UserDetail User { get; set; } = null!;
                public CommunityArticle CommunityArticle { get; set; } = null!;
                public CommunityBook CommunityBook { get; set; } = null!;
    }
}
