namespace VenomVerseApi.Models
{

    public struct AnswerStruct {
        public string Answer { get; set; }
        public bool Correctness { get; set; }
    }

    public class Question {     // For MCQ type
        public long Id { get; set; }
        public string QuestionString { get; set; }
        public string[]? QuestionMedia { get; set; }
        public string Difficulty { get; set; }
        public string? Description { get; set; }
        public string Type { get; set; }
        public float Marks { get; set; }
        public long WriterId { get; set; }
        public long? ApprovedUserId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string[,] AnswerList { get; set; }
        public bool Published { get; set; } = false;
    }
}