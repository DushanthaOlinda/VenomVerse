using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{

    public struct AnswerStruct {
        public string Answer { get; set; }
        public bool Correctness { get; set; }
    }

    public class Question {     // For MCQ type
        public required long QuestionId { get; set; }
        public required string QuestionString { get; set; }
        public string[]? QuestionMedia { get; set; }
        public required string Difficulty { get; set; }
        public string? Description { get; set; }
        public required string Type { get; set; }
        public required float Marks { get; set; }
        public required long WriterId { get; set; }       // Zoologists create questions
        [ForeignKey("Zoologist")] public long? ApprovedUserId { get; set; }         // Zoologists approve questions
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public required string[,] AnswerList { get; set; }
        public bool Published { get; set; } = false;

        // Foreign Key References
        public Zoologist Zoologist { get; set; } = null!;
    }
}