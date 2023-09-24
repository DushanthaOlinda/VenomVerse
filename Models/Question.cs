using System.ComponentModel.DataAnnotations.Schema;
namespace VenomVerseApi.Models
{

    // public struct AnswerStruct {
    //     public string Answer { get; set; }
    //     public bool Correctness { get; set; }
    // }

    public class Question {     // For MCQ type
        public required long QuestionId { get; set; }
        public required long QuizDetailId { get; set; }   // quizdetail -> quizdetailid
        public required string QuestionString { get; set; }
        public required string QuestionStringSinhala { get; set; }
        public string[]? QuestionMedia { get; set; }
        // public required string Difficulty { get; set; }
        public string? Note { get; set; }
        public string? NoteSinhala { get; set; }
        // public required string Type { get; set; }
        public required bool MultipleAnswers { get; set; } = true;
        // public required float Marks { get; set; }
        // public required long WriterId { get; set; }       // Zoologists create questions
        // public long? ApprovedUserId { get; set; }         // Zoologists approve questions
        public required DateTime DateTime { get; set; } = DateTime.Now;
        public bool Published { get; set; } = false;    // option to publish the quiz

        // Answers
        public required string Answer01 { get; set; } 
        public required string Answer01Sinhala { get; set; } 
        public required bool Correctness01 { get; set; } = false;
        public required string Answer02 { get; set; }
        public required string Answer02Sinhala { get; set; }
        public required bool Correctness02 { get; set; } = false;
        public required string Answer03 { get; set; }
        public required string Answer03Sinhala { get; set; }
        public required bool Correctness03 { get; set; } = false;
        public required string Answer04 { get; set; }
        public required string Answer04Sinhala { get; set; }
        public required bool Correctness04 { get; set; } = false;
        public string? Answer05 { get; set; }
        public string? Answer05Sinhala { get; set; }
        public bool? Correctness05 { get; set; } = false;


                // Foreign Key References
                [ForeignKey("QuizDetailId")] public QuizDetail QuizDetail { get; set; } = null!;
                // [ForeignKey("ApprovedUserId")] public Zoologist ZoologistApprove { get; set; } = null!;
                // [ForeignKey("WriterId")] public Zoologist ZoologistWrite { get; set; } = null!;
    }
}