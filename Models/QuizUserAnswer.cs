using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
namespace VenomVerseApi.Models
{
        // [PrimaryKey(nameof(QuizAttemptId), nameof(QuestionId), nameof(UserId), nameof(SubmittedTime))]    
        public class QuizUserAnswer{
        [Key]public required long QuizUserAnswerId { get; set; }    
        public required long QuizAttemptId { get; set; }  //*  
        // public required long UserId { get; set; }     //*
        // public required DateTime SubmittedTime { get; set; }    
        public required long QuestionId { get; set; }    //*
       
        // Answers
        public required bool Select01 { get; set; } = false;       // *
        public required bool Correctness01 { get; set; } = false;      
        public required bool Select02 { get; set; } = false;
        public required bool Correctness02 { get; set; } = false;
        public required bool Select03 { get; set; } = false;        // *
        public required bool Correctness03 { get; set; } = false;
        public required bool Select04 { get; set; } = false;
        public required bool Correctness04 { get; set; } = false;
        public required bool Select05 { get; set; } = false;
        public required bool Correctness05 { get; set; } = false;


        public static QuizUserAnswerDto QuizUserAnsToQuizUserAnsDto( QuizUserAnswer quizAnswer)
        {
            var quizAns = new QuizUserAnswerDto( 
                quizAnswer.QuizUserAnswerId,
                quizAnswer.QuizAttemptId,
                // quizAnswer.SubmittedTime,
                quizAnswer.QuestionId,
                quizAnswer.Select01,
                quizAnswer.Correctness01,
                quizAnswer.Select02,
                quizAnswer.Correctness02,
                quizAnswer.Select03,
                quizAnswer.Correctness03,
                quizAnswer.Select04,
                quizAnswer.Correctness04,
                quizAnswer.Select05,
                quizAnswer.Correctness05
            )
            {
                QuizUserAnswerId = quizAnswer.QuizUserAnswerId,
                QuizAttemptId = quizAnswer.QuizAttemptId,
                // SubmittedTime = quizAnswer.SubmittedTime,
                QuestionId = quizAnswer.QuestionId,
                Select01 = quizAnswer.Select01!,
                Correctness01 = quizAnswer.Correctness01,
                Select02 = quizAnswer.Select02,
                Correctness02 = quizAnswer.Correctness02,
                Select03 = quizAnswer.Select03,
                Correctness03 = quizAnswer.Correctness03,
                Select04 = quizAnswer.Select04,
                Correctness04 = quizAnswer.Correctness04,
                Select05 = quizAnswer.Select05,
                Correctness05 = quizAnswer.Correctness05
            };
            return quizAns;
        }

        public static QuizUserAnswer QuizUserAnsDtoToQuizUserAns (QuizUserAnswerDto quizuserAnsDto) =>
        new()
        {
            QuizUserAnswerId = quizuserAnsDto.QuizUserAnswerId,
            QuizAttemptId = quizuserAnsDto.QuizAttemptId,
            // SubmittedTime = quizuserAnsDto.SubmittedTime,
            QuestionId = quizuserAnsDto.QuestionId,
            Select01 = quizuserAnsDto.Select01!,
            Correctness01 = quizuserAnsDto.Correctness01,
            Select02 = quizuserAnsDto.Select02,
            Correctness02 = quizuserAnsDto.Correctness02,
            Select03 = quizuserAnsDto.Select03,
            Correctness03 = quizuserAnsDto.Correctness03,
            Select04 = quizuserAnsDto.Select04,
            Correctness04 = quizuserAnsDto.Correctness04,
            Select05 = quizuserAnsDto.Select05,
            Correctness05 = quizuserAnsDto.Correctness05
        };


        [ForeignKey("QuizAttemptId")] public QuizAttempt QuizAttempt { get; set; } = null!;
        [ForeignKey("QuestionId")] public Question Question { get; set; } = null!;

    }
}
