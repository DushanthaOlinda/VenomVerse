using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizDto
{
    public required long QuizId { get; set; }          //primary           
    public required long UserId { get; set; }          //primary         
    public required DateTime SubmittedTime { get; set; } = DateTime.Now;          //primary  
    // public required string QuizType { get; set; }
    public float? TotalMarks { get; set; }
    public float? AttemptedMarks { get; set; }
    public float? PassMark { get; set; }

}
    