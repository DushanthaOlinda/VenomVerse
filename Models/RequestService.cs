using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{    public class RequestService {
        public required long RequestServiceId { get; set; }
        public required long ReqUserId { get; set; }//User->UserId
        public long? CatcherId { get; set; }//Catcher->CatcherId
        public required DateTime DateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null; 

        public long? ScannedImage { get; set; } //ScannedImage->ScannedImageId           
        public long? SelectedSerpent { get; set; }//Serpent->SerpentId

        public bool AcceptFlag { get; set; } = false;
        public bool CompleteFlag { get; set; } = false;
        public bool FakeReqFlag { get; set; } = false;


        public required int Rate { get; set; }  // 1-5
        public string? RatingComment { get; set; }

        public string? ServiceFeedback { get; set; }
        public string[]? ServiceFeedbackMedia { get; set; }

                // Foreign Key References
                [ForeignKey("ReqUserId")] public UserDetail User { get; set; } = null!;
                [ForeignKey("CatcherId")] public Catcher? Catcher { get; set; } = null!;
                [ForeignKey("SelectedSerpent")] public Serpent Serpent { get; set; } = null!;
                [ForeignKey("ScannedImage")] public ScannedImage ScannedImg { get; set; } = null!;
    }
}
