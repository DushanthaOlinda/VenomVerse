using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{    public class RequestService {
        public required long RequestServiceId { get; set; }
        public required long ReqUserId { get; set; }//User->UserId
        public long? CatcherId { get; set; }//Catcher->CatcherId
        public DateTime DateTime { get; set; } = DateTime.Now;
        //public string? LiveLocation { get; set; } = null; 

        public long? ScannedImage { get; set; } //ScannedImage->ScannedImageId           
        public long? SelectedSerpent { get; set; }//Serpent->SerpentId

        public bool AcceptFlag { get; set; } = false;
        public bool CompleteFlag { get; set; } = false;
        public bool FakeReqFlag { get; set; } = false;


        public int? Rate { get; set; }  // 1-5
        public string? RatingComment { get; set; }


        public string? ServiceFeedback { get; set; }
        public string[]? ServiceFeedbackMedia { get; set; }
        public string[]? CatcherMedia { get; set; }
        public string? CatcherFeedback { get; set; }


        public static ServiceDto ToServiceDto(RequestService service, ScannedImage? image)
        {
                
                var serviceReq = new ServiceDto(
                service.RequestServiceId, 
                service.ReqUserId,
                image!.ScannedImageMedia,
                service.SelectedSerpent
                );

                return serviceReq;
        }
        
        public static ServiceDto ToServiceDto(RequestService service)
        {
                var serviceReq = new ServiceDto(
                service.RequestServiceId, 
                service.ReqUserId,
                null,
                service.SelectedSerpent
                );

                return serviceReq;    
        }

        public static ServiceDto ToServiceDto(RequestService service, UserDetail user, ScannedImage scanImg, Serpent serpent)
        {
                var serviceReq = new ServiceDto(
                        service.RequestServiceId, 
                        service.ReqUserId,
                        null,
                        service.SelectedSerpent,
                        user,
                        scanImg,
                        serpent
                );

                return serviceReq;    
        }


        private RequestService ( long requestServiceId, long reqUserId, long? scannedImage, long? selectedSerpent, long? catcherId )
        {
                RequestServiceId = requestServiceId;
                ReqUserId = reqUserId;
                ScannedImage = scannedImage;
                SelectedSerpent = selectedSerpent;
                CatcherId = catcherId;
        }

        public static RequestService ToService (ServiceDto serviceDto) =>
        new(
                serviceDto.RequestServiceId,
                serviceDto.ReqUserId,
                serviceDto.ScannedImageId,
                serviceDto.SelectedSerpent,
                serviceDto.CatcherId
        )
        {
                RequestServiceId = serviceDto.RequestServiceId,
                ReqUserId = serviceDto.ReqUserId,
                ScannedImage = serviceDto.ScannedImageId,
                SelectedSerpent = serviceDto.SelectedSerpent,
                CatcherId = serviceDto.CatcherId
        };


    

                // Foreign Key References
                [ForeignKey("ReqUserId")] public UserDetail User { get; set; } = null!;
                [ForeignKey("CatcherId")] public Catcher? Catcher { get; set; } = null!;
                [ForeignKey("SelectedSerpent")] public Serpent Serpent { get; set; } = null!;
                [ForeignKey("ScannedImage")] public ScannedImage ScannedImg { get; set; } = null!;
    }
}
