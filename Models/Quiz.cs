namespace VenomVerseApi.Models
{
    public class Quiz {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string QuizType { get; set; }
        public float? TotalMarks { get; set; }
        public float? AttemptedMarks { get; set; }
        public float? PassMark { get; set; }

        //Answer details - for mcq types
        //Answer details - for structured types ?
    }
}