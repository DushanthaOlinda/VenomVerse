using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{
    public class QuizDetail {     // Like QuizAttemp

        // QuizDtail - QuizID, Topic, TopicSinhala

        public required long QuizDetailId { get; set; }   
        public required string QuizTopic { get; set; }
        public required string QuizTopicSinhala { get; set; }

        public static QuizDetailDto QuizDetailtoQuizDetailDto( QuizDetail quizDetail) => new QuizDetailDto{
            QuizDetailId = quizDetail.QuizDetailId,
            QuizTopic = quizDetail.QuizTopic,
            QuizTopicSinhala = quizDetail.QuizTopicSinhala
        };

    }
}
