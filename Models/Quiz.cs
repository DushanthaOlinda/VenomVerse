using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{
    public class Quiz {
        public required long QuizId { get; set; }
        [ForeignKey("User")] public required long UserId { get; set; }
        public required string QuizType { get; set; }
        public float? TotalMarks { get; set; }
        public float? AttemptedMarks { get; set; }
        public float? PassMark { get; set; }


                // Foreign Key References
                public UserDetail User { get; set; } = null!;

        //Answer details - for mcq types
        //Answer details - for structured types ?
    }
}