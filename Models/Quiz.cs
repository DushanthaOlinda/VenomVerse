using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace VenomVerseApi.Models
{
    [PrimaryKey(nameof(QuizId), nameof(UserId), nameof(SubmittedTime))] 
    public class Quiz {     // Like QuizAttemp

    // QuizDtail - QuizID, Topic, TopicSinhala
    public required long QuizId { get; set; }          //primary           
    public required long UserId { get; set; }          //primary         
    public required DateTime SubmittedTime { get; set; } = DateTime.Now;          //primary  
    // public required string QuizType { get; set; }
    public float? TotalMarks { get; set; }
    public float? AttemptedMarks { get; set; }
    public float? PassMark { get; set; }


            // Foreign Key References
            [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;
            [ForeignKey("QuizId")] public QuizDetail QuizDetail { get; set; } = null!;

    //Answer details - for mcq types


    //Answer details - for structured types ?
    }
}

// Marks Criteria
// Easy - 100 => easy(10 marks) *10
// Medium - 150 => Medium(15 marks) *10
// Hard - 200 => Hard(20 marks) *10