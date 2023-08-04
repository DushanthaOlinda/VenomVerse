using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class Quiz {
        public required long QuizId { get; set; }
        public required long UserId { get; set; }
        public required DateTime SubmittedTime { get; set; } = DateTime.Now;
        public required string QuizType { get; set; }
        public float? TotalMarks { get; set; }
        public float? AttemptedMarks { get; set; }
        public float? PassMark { get; set; }


                // Foreign Key References
                [ForeignKey("UserId")] public UserDetail User { get; set; } = null!;

        //Answer details - for mcq types


        //Answer details - for structured types ?
    }
}

// Marks Criteria
// Easy - 100 => easy(10 marks) *10
// Easy - 150 => easy(15 marks) *10
// Easy - 120 => easy(20 marks) *10