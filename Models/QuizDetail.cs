using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{
    public class QuizDetail {    

        public required long QuizDetailId { get; set; }   
        public required string QuizTopic { get; set; }
        public required string QuizTopicSinhala { get; set; }
        // public required string PublishedUser { get; set; }  //Zoologist
        // public required bool FinishProcess { get; set; } = false;

        public static QuizDetailDto QuizDetailToQuizDetailDto( QuizDetail quizDetail)
        {
            var quizdet = new QuizDetailDto( 
                quizDetail.QuizDetailId,
                quizDetail.QuizTopic,
                quizDetail.QuizTopicSinhala
            )
            {
                QuizDetailId = quizDetail.QuizDetailId,
                QuizTopic = quizDetail.QuizTopic,
                QuizTopicSinhala = quizDetail.QuizTopicSinhala
            };
            return quizdet;
        }

        public static QuizDetail QuizDetailDtoToQuizDetail (QuizDetailDto quizDetail) =>
        new()
        {
            QuizDetailId = quizDetail.QuizDetailId,
            QuizTopic = quizDetail.QuizTopic,
            QuizTopicSinhala = quizDetail.QuizTopicSinhala
        };

    }
}
