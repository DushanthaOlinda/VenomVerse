using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuizUserAnswerDto
{
    public long QuizUserAnswerId { get; set; } 
    public long QuizAttemptId { get; set; }    
    // public DateTime SubmittedTime { get; set; }    
    public long QuestionId { get; set; }    
    public bool Select01 { get; set; } = false;
    public bool Correctness01 { get; set; }
    public bool Select02 { get; set; } = false;
    public bool Correctness02 { get; set; }
    public bool Select03 { get; set; } = false;
    public bool Correctness03 { get; set; }
    public bool Select04 { get; set; } = false;
    public bool Correctness04 { get; set; }
    public bool Select05 { get; set; } = false;
    public bool Correctness05 { get; set; }


    public QuizUserAnswerDto( long quizUserAnswerId, long quizAttemptID, long questionId, bool select01, bool correctness01, bool select02, bool correctness02, bool select03, bool correctness03, bool select04, bool correctness04, bool select05, bool correctness05)
    {
        QuizUserAnswerId = quizUserAnswerId;
        QuizAttemptId = quizAttemptID;
        // SubmittedTime = submittedTime;
        QuestionId = questionId;
        Select01 = select01;
        Correctness01 = correctness01;
        Select02 = select02;
        Correctness02 = correctness02;
        Select03 = select03;
        Correctness03 = correctness03;
        Select04 = select04;
        Correctness04 = correctness04;
        Select05 = select05;
        Correctness05 = correctness05;
    }

}
    