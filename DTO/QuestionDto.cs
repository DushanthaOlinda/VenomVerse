using VenomVerseApi.Models;

namespace VenomVerseApi.DTO;

public class QuestionDto
{
    public long QuestionId { get; set; }
    public long QuizDetailId { get; set; }
    public string QuestionString { get; set; }
    public string QuestionStringSinhala { get; set; }
    public string[]? QuestionMedia { get; set; }
    public string? Note { get; set; }
    public string? NoteSinhala { get; set; }
    // public bool MultipleAnswers { get; set; } = true;
    public DateTime DateTime { get; set; } = DateTime.Now;
    // public bool Published { get; set; } = false;    
    public string Answer01 { get; set; } 
    public string Answer01Sinhala { get; set; } 
    public bool Correctness01 { get; set; } = false;
    public string Answer02 { get; set; }
    public string Answer02Sinhala { get; set; }
    public bool Correctness02 { get; set; } = false;
    public string Answer03 { get; set; }
    public string Answer03Sinhala { get; set; }
    public bool Correctness03 { get; set; } = false;
    public string Answer04 { get; set; }
    public string Answer04Sinhala { get; set; }
    public bool Correctness04 { get; set; } = false;
    public string Answer05 { get; set; }
    public string Answer05Sinhala { get; set; }
    public bool Correctness05 { get; set; } = false;


    public QuestionDto( long questionId, long quizDetailId, string questionString, string questionStringSinhala, string[] questionMedia, string? note,string? noteSinhala, DateTime dateTime, string answer01, string answer01Sinhala, bool correctness01, string answer02, string answer02Sinhala, bool correctness02, string answer03, string answer03Sinhala, bool correctness03, string answer04, string answer04Sinhala, bool correctness04, string answer05, string answer05Sinhala, bool correctness05 ){
        QuestionId = questionId;
        QuizDetailId = quizDetailId;
        QuestionString = questionString;
        QuestionStringSinhala = questionStringSinhala;
        QuestionMedia = questionMedia;
        Note = note;
        NoteSinhala = noteSinhala;
        DateTime = dateTime;
        Answer01 = answer01;
        Answer01Sinhala = answer01Sinhala;
        Correctness01 = correctness01;
        Answer02 = answer02;
        Answer02Sinhala = answer02Sinhala;
        Correctness02 = correctness02;
        Answer03 = answer03;
        Answer03Sinhala = answer03Sinhala;
        Correctness03 = correctness03;
        Answer04 = answer04;
        Answer04Sinhala = answer04Sinhala;
        Correctness04 = correctness04;
        Answer05 = answer05;
        Answer05Sinhala = answer05Sinhala;
        Correctness05 = correctness05;
    }

}
    