using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace VenomVerseApi.Models
{
    // [PrimaryKey(nameof(QuizDetailId), nameof(UserId), nameof(SubmittedTime))] 
    public class QuizAttempt {     // Like QuizAttemp

    // QuizDtail - QuizID, Topic, TopicSinhala
    [Key]public required long QuizAttemptId { get; set; }                    
    public required long QuizDetailId { get; set; }         
    public required long UserId { get; set; }     
    public required DateTime SubmittedTime { get; set; } = DateTime.Now;      
    // public required string QuizType { get; set; }
    public float? TotalMarks { get; set; }
    public float? AttemptedMarks { get; set; }
    public float? PassMark { get; set; }


            // Foreign Key References
            [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;
            [ForeignKey("QuizDetailId")] public QuizDetail QuizDetail { get; set; } = null!;

    //Answer details - for mcq types


    //Answer details - for structured types ?
    }
}

// Marks Criteria
// Easy - 100 => easy(10 marks) *10
// Medium - 150 => Medium(15 marks) *10
// Hard - 200 => Hard(20 marks) *10