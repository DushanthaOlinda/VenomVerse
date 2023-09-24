using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace VenomVerseApi.Models
{
        // [PrimaryKey(nameof(QuizAttemptId), nameof(QuestionId), nameof(UserId), nameof(SubmittedTime))]    
        public class QuizUserAnswer{
        [Key]public required long QuizUserAnswerId { get; set; }    
        public required long QuizAttemptId { get; set; }  //*  
        // public required long UserId { get; set; }     //*
        public required long QuestionId { get; set; }    //*
        public required DateTime SubmittedTime { get; set; }    
       
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




        [ForeignKey("QuizAttemptId")] public QuizAttempt QuizAttempt { get; set; } = null!;
        [ForeignKey("QuestionId")] public Question Question { get; set; } = null!;

    }
}
