using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizAttemptDto
{
    public long QuizAttemptId { get; set; }          //primary           
    public long UserId { get; set; }          //primary         
    public long QuizDetailId { get; set; }          //primary         
    public DateTime SubmittedTime { get; set; } = DateTime.Now;          //primary  
    // public required string QuizType { get; set; }
    // public float? TotalMarks { get; set; }
    public float TotalMarks { get; set; } =0;
    // public float? PassMark { get; set; }


    public UserDetail? UserDetails { get; set; } = null;
    public QuizDetail? QuizDetails { get; set; } = null;

    public QuizAttemptDto( long quizAttemptID, long userId, long quizDetailId, DateTime submittedTime, float totalMarks)
    {
        QuizAttemptId = quizAttemptID;
        UserId = userId;
        QuizDetailId = quizDetailId;
        SubmittedTime = submittedTime;
        TotalMarks =totalMarks;
        // TotalMarks = totalMarks;
        // PassMark = passMark;
    }

    public QuizAttemptDto( long quizAttemptID, long userId, long quizDetailId, DateTime submittedTime, float totalMarks, UserDetail? userDetails, QuizDetail? quizDetails)
    {
        QuizAttemptId = quizAttemptID;
        UserId = userId;
        QuizDetailId = quizDetailId;
        SubmittedTime = submittedTime;
        TotalMarks = totalMarks;
        UserDetails = userDetails;
        QuizDetails = quizDetails;
        // TotalMarks = totalMarks;
        // PassMark = passMark;
    }

}
    