using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizDetailDto
{
    public long QuizDetailId { get; set; }   
    public string QuizTopic { get; set; }
    public string QuizTopicSinhala { get; set; }

    public QuizDetailDto( long quizDetailId, string quizTopic, string quizTopicSinhala){
        QuizDetailId = quizDetailId;
        QuizTopic = quizTopic;
        QuizTopicSinhala = quizTopicSinhala;
    }
}
    