using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{    public class Catcher {

        public long ReqId { get; set; } 
        [Key]
        public required long ReqCatcher { get; set; }   //76576567567
        
        // public required long CatcherId { get; set; }



        public required bool Availability { get; set; } = false;
        public float? ChargingFee { get; set; } = 0;
        
        public required DateTime RequestedDateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null;   
        public required string[] CatcherEvidence { get; set; } = null!;
        public string? Description { get; set; }
        public string? SpecialNote { get; set; }   

        public long? ApprovedPersonIdOne { get; set; } //catcher -> catcherId
        public DateOnly? ApprovedDateOne { get; set; }
        public bool ApprovedStatusOne { get; set; } = false;

        public long? ApprovedPersonIdTwo { get; set; }//catcher -> catcherId
        public DateOnly? ApprovedDateTwo { get; set; }
        public bool ApprovedStatusTwo { get; set; } = false;

        public long? ApprovedPersonIdThree { get; set; }//catcher -> catcherId
        public DateOnly? ApprovedDateThree { get; set; }     
        public bool ApprovedStatusThree { get; set; } = false;

        public required DateOnly? JoinedDate { get; set; }
        public bool ApprovedFlag { get; set; } = false;


        public static CatcherReqDto ToCatcherReqDto(Catcher catcher, UserDetail? userDetail)
        {
                // var userDetails = await _context.UserDetail.FindAsync(catcher.CatcherId);
                // var fullName = userDetail!.FirstName + ' ' + userDetail.LastName;
                var newReq = new CatcherReqDto(
                        catcher.ReqId,
                        catcher.ReqCatcher,
                        catcher.CatcherEvidence, 
                        catcher.Description, 
                        catcher.SpecialNote, 
                        catcher.ApprovedPersonIdOne, 
                        catcher.ApprovedDateOne, 
                        catcher.ApprovedPersonIdTwo, 
                        catcher.ApprovedDateTwo, 
                        catcher.ApprovedPersonIdThree, 
                        catcher.ApprovedDateThree, 
                        catcher.JoinedDate,
                        catcher.ApprovedFlag,
                        userDetail
                );
                return newReq;
        }


                // Foreign Key References
                [ForeignKey("ReqCatcher")] public UserDetail User { get; set; } = null!;

                [ForeignKey("ApprovedPersonIdOne")]
                public Catcher? ApprovalOne { get; set; }

                [ForeignKey("ApprovedPersonIdTwo")]
                public Catcher? ApprovalTwo { get; set; }

                [ForeignKey("ApprovedPersonIdThree")]
                public Catcher? ApprovalThree { get; set; }
        
                public RequestService RequestService { get; set; } = null!;
                
            }
}
