using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace VenomVerseApi.Models
{
        [PrimaryKey(nameof(QuizId), nameof(QuestionId))]    
        public class QuizUserAnswer{
        public required long QuizId { get; set; }
        public required long QuestionId { get; set; }
       
        // Answers
        public required bool Select01 { get; set; } = false;
        public required bool Correctness01 { get; set; }
        public required bool Select02 { get; set; } = false;
        public required bool Correctness02 { get; set; }
        public required bool Select03 { get; set; } = false;
        public required bool Correctness03 { get; set; }
        public required bool Select04 { get; set; } = false;
        public required bool Correctness04 { get; set; }
        public bool? Select05 { get; set; } = false;
        public bool? Correctness05 { get; set; }

        // Foreign Key References
                [ForeignKey("QuizId")] public Quiz Quiz { get; set; } = null!;
                [ForeignKey("QuestionId")] public Question Question { get; set; } = null!;

    }
}
