using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizAttemptDto
{
    public required long QuizAttemptId { get; set; }          //primary           
    public required long UserId { get; set; }          //primary         
    public required DateTime SubmittedTime { get; set; } = DateTime.Now;          //primary  
    // public required string QuizType { get; set; }
    // public float? TotalMarks { get; set; }
    public float? AttemptedMarks { get; set; }
    // public float? PassMark { get; set; }

    public QuizAttemptDto( long quizAttemptID, long userId, DateTime submittedTime, float attemptedMarks)
    {
        QuizAttemptId = quizAttemptID;
        UserId = userId;
        SubmittedTime = submittedTime;
        AttemptedMarks =attemptedMarks;
        // TotalMarks = totalMarks;
        // PassMark = passMark;
    }

}
    