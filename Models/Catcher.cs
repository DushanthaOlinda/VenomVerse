using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{    public class Catcher {

        public required long CatcherId { get; set; } // User --> UserID

        public required bool Availability { get; set; } = false;
        public float? ChargingFee { get; set; } = 0;
        
        public required DateTime RequestedDateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null;   
        public required string[] CatcherEvidence { get; set; } = null!;
        public string? Description { get; set; }
        public string? SpecialNote { get; set; }   

        public long? ApprovedPersonIdOne { get; set; } //catcher -> catcherId
        public DateOnly? ApprovedDateOne { get; set; }
        public long? ApprovedPersonIdTwo { get; set; }//catcher -> catcherId
        public DateOnly? ApprovedDateTwo { get; set; }
        public long? ApprovedPersonIdThree { get; set; }//catcher -> catcherId
        public DateOnly? ApprovedDateThree { get; set; }     
        public required DateOnly? JoinedDate { get; set; }
        public bool ApprovedFlag { get; set; } = false;


                // Foreign Key References
                [ForeignKey("CatcherId")] public UserDetail User { get; set; } = null!;

                [ForeignKey("ApprovedPersonIdOne")]
                public Catcher? ApprovalOne { get; set; }

                [ForeignKey("ApprovedPersonIdTwo")]
                public Catcher? ApprovalTwo { get; set; }

                [ForeignKey("ApprovedPersonIdThree")]
                public Catcher? ApprovalThree { get; set; }
                

                public RequestService RequestService { get; set; } = null!; 
        
    }
}
