using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizDetailDto
{
    public required long QuizDetailId { get; set; }   
    public required string QuizTopic { get; set; }
    public required string QuizTopicSinhala { get; set; }
}
    