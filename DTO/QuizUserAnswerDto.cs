using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizUserAnswerDto
{
    public required long QuizId { get; set; }    
    public required long UserId { get; set; }     
    public required DateTime SubmittedTime { get; set; }    
    public required long QuestionId { get; set; }    
    
    // Answers
    public required bool Select01 { get; set; } = false;
    public required bool Correctness01 { get; set; }
    public required bool Select02 { get; set; } = false;
    public required bool Correctness02 { get; set; }
    public required bool Select03 { get; set; } = false;
    public required bool Correctness03 { get; set; }
    public required bool Select04 { get; set; } = false;
    public required bool Correctness04 { get; set; }
    public bool? Select05 { get; set; } = false;
    public bool? Correctness05 { get; set; }
}
    