using System.ComponentModel.DataAnnotations.Schema;
using VenomVerseApi.DTO;
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
        public string? Note { get; set; }
        public string? NoteSinhala { get; set; }
        public required DateTime DateTime { get; set; } = DateTime.Now;

        // position from 1-10 - easy to handle

        // public required string Difficulty { get; set; }
        // public required string Type { get; set; }
        // public required bool MultipleAnswers { get; set; } = true;
        // public required float Marks { get; set; }
        // public required long WriterId { get; set; }       // Zoologists create questions
        // public long? ApprovedUserId { get; set; }         // Zoologists approve questions
        // public bool Published { get; set; } = false;    // option to publish the quiz

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
        public required string Answer05 { get; set; }
        public required string Answer05Sinhala { get; set; }
        public required bool Correctness05 { get; set; } = false;


        public static QuestionDto QuestionToQuestionDto( Question question)
        {
                var questiondet = new QuestionDto( 
                question.QuestionId,
                question.QuizDetailId,
                question.QuestionString,
                question.QuestionStringSinhala,
                question.QuestionMedia!,
                question.Note,
                question.NoteSinhala,
                question.DateTime,
                question.Answer01,
                question.Answer01Sinhala,
                question.Correctness01,
                question.Answer02,
                question.Answer02Sinhala,
                question.Correctness02,
                question.Answer03,
                question.Answer03Sinhala,
                question.Correctness03,
                question.Answer04,
                question.Answer04Sinhala,
                question.Correctness04,
                question.Answer05,
                question.Answer05Sinhala,
                question.Correctness05
            )
            {
                QuestionId = question.QuestionId,
                QuizDetailId = question.QuizDetailId,
                QuestionString = question.QuestionString,
                QuestionStringSinhala = question.QuestionStringSinhala,
                QuestionMedia = question.QuestionMedia,
                Note = question.Note,
                NoteSinhala = question.NoteSinhala,
                DateTime = question.DateTime,
                Answer01 = question.Answer01,
                Answer01Sinhala = question.Answer01Sinhala,
                Correctness01 = question.Correctness01,
                Answer02 = question.Answer02,
                Answer02Sinhala = question.Answer02Sinhala,
                Correctness02 = question.Correctness02,
                Answer03 = question.Answer03,
                Answer03Sinhala = question.Answer03Sinhala,
                Correctness03 = question.Correctness03,
                Answer04 = question.Answer04,
                Answer04Sinhala = question.Answer04Sinhala,
                Correctness04 = question.Correctness04,
                Answer05 = question.Answer05,
                Answer05Sinhala = question.Answer05Sinhala,
                Correctness05 = question.Correctness05
            };
            return questiondet;
        }

        public static Question QuestionDtoToQuestion (QuestionDto questionDto) =>
        new()
        {
            QuestionId = questionDto.QuestionId,
            QuizDetailId = questionDto.QuizDetailId,
            QuestionString = questionDto.QuestionString,
            QuestionStringSinhala = questionDto.QuestionStringSinhala,
            QuestionMedia = questionDto.QuestionMedia,
            Note = questionDto.Note,
            NoteSinhala = questionDto.NoteSinhala,
            DateTime = questionDto.DateTime,
            Answer01 = questionDto.Answer01,
            Answer01Sinhala = questionDto.Answer01Sinhala,
            Correctness01 = questionDto.Correctness01,
            Answer02 = questionDto.Answer02,
            Answer02Sinhala = questionDto.Answer02Sinhala,
            Correctness02 = questionDto.Correctness02,
            Answer03 = questionDto.Answer03,
            Answer03Sinhala = questionDto.Answer03Sinhala,
            Correctness03 = questionDto.Correctness03,
            Answer04 = questionDto.Answer04,
            Answer04Sinhala = questionDto.Answer04Sinhala,
            Correctness04 = questionDto.Correctness04,
            Answer05 = questionDto.Answer05,
            Answer05Sinhala = questionDto.Answer05Sinhala,
            Correctness05 = questionDto.Correctness05
        };


                // Foreign Key References
                [ForeignKey("QuizDetailId")] public QuizDetail QuizDetail { get; set; } = null!;
                // [ForeignKey("ApprovedUserId")] public Zoologist ZoologistApprove { get; set; } = null!;
                // [ForeignKey("WriterId")] public Zoologist ZoologistWrite { get; set; } = null!;
    }
}