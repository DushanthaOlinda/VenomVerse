namespace VenomVerseApi.Models
{
    public class Quiz {
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required string QuizType { get; set; }
        public float? TotalMarks { get; set; }
        public float? AttemptedMarks { get; set; }
        public float? PassMark { get; set; }

        //Answer details - for mcq types
        //Answer details - for structured types ?
    }
}