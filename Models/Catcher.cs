using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{    public class Catcher {

        public required long CatcherId { get; set; }

        public required bool Availability { get; set; } = false;
        public float? ChargingFee { get; set; } = 0;
        
        public required DateTime RequestedDateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null;   
        public required string[] CatcherEvidence { get; set; } = null!;
        public string? Description { get; set; }
        public string? SpecialNote { get; set; }   

        public long? ApprovedPersonIdOne { get; set; }
        public DateOnly? ApprovedDateOne { get; set; }
        public long? ApprovedPersonIdTwo { get; set; }
        public DateOnly? ApprovedDateTwo { get; set; }
        public long? ApprovedPersonIdThree { get; set; }
        public DateOnly? ApprovedDateThree { get; set; }     
        public required DateOnly? JoinedDate { get; set; }
        public bool ApprovedFlag { get; set; } = false;


                // Foreign Key References
                [ForeignKey("CatcherId")] public UserDetail User { get; set; } = null!; 
                public RequestService RequestService { get; set; } = null!; 
        
    }
}
