using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class QuizController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public QuizController(VenomVerseContext context)
    {
        _context = context;
    }

    //Get all quizes for cards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizDetailDto>>> GetAllQuizDetails()
    {
        if ( _context.QuizDetail == null ) return NotFound();
        return await _context.QuizDetail.Select(x=>QuizDetail.QuizDetailtoQuizDetailDto(x)).ToListAsync();
    }

    // if attempted view reviews otherwise get attempted page
    // [HttpGet("{uid/qid}")]
    // public async Task<ActionResult<SerpentDto>> GetQuizQuestions(long uid, long qid)
    // {
    //     if ( _context.QuizUserAnswer == null ) return NotFound();

    //     var quizUserAnswerDetail =  await _context.QuizUserAnswer.FindAsync(id);    //composite key??
    //     // if ( serpentDetail == null ) return NotFound();
    //     // var serpentInstructoins = _context.SerpentInstruction.Where(p=> p.SerpentId == serpentDetail.SerpentId).ToList();
    //     // // return SerpentToSerpentDto(serpentDetail);
    //     // return Serpent.CreateSerpentDto(serpentDetail, serpentInstructoins);
    // }

    //Else get questions for relavant quiz

    //Compare given answers and store



    //====OPT====//

    // add quiz details, edit, delete

    // add questions

    // approve questions

    // delete questions

    // edit questions


}