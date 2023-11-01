using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class CommunityAdmin {

        public required long CommunityAdminId { get; set; }// user-> userId
        
        public required DateOnly? JoinedDate { get; set; }

                // Foreign Key References
                [ForeignKey("CommunityAdminId")] public UserDetail User { get; set; } = null!;  
                public CommunityArticle CommunityArticle { get; set; } = null!;  
                // public CommunityBook CommunityBook { get; set; } = null!;  
    }
}
