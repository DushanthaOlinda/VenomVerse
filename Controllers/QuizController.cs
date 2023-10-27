using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;
using QuizAttempt = VenomVerseApi.Models.QuizAttempt;

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
        return await _context.QuizDetail.Select(x=>QuizDetail.QuizDetailToQuizDetailDto(x)).ToListAsync();
        // add marks if attempted
    }

    // get all attempts for admin panel or community admins
    [HttpGet("AllAttempts")]
    public async Task<ActionResult<IEnumerable<QuizAttemptDto>>> GetAllAttempts()
    {
        if ( _context.QuizAttempt == null ) return NotFound();

        return await _context.QuizAttempt.Select(qa => QuizAttempt.QuizAttemptToQuizAttemptDto(
            qa,
            _context.UserDetail.FirstOrDefault(user => user.UserDetailId==qa.UserId)!,
            _context.QuizDetail.FirstOrDefault(quizDetail => quizDetail.QuizDetailId==qa.QuizDetailId)!
        )).ToListAsync();
    }

    // Attempt to a quiz
    [HttpPost("AttemptQuiz/{aid}/{uid}/{qzid}")]    // check whether priviously done or not
    // public async Task<ActionResult> AttemptQuiz(long aid, long uid, long qzid)
    public async Task<ActionResult> AttemptQuiz(QuizAttemptDto quizAttemptDto)
    {
        if ( _context.QuizAttempt == null ) return NotFound();

        // var quizAttemptDto = new QuizAttemptDto(aid, uid, qzid, 0);
        _context.QuizAttempt.Add(QuizAttempt.QuizAttemptDtoToQuizAttempt(quizAttemptDto));

        await _context.SaveChangesAsync();
        return Ok("User Attempt started");
    }

    // if attempted view reviews otherwise get attempted page
    [HttpGet("GetQuestions/{uid}/{qzid}")]
    public async Task<ActionResult> GetQuizQuestions(long uid, long qzid)
    {
        if ( _context.Question == null ) return NotFound();

        var questionDetails = await _context.Question.Where(questionDetail => questionDetail.QuizDetailId == qzid ).Select(q => Question.QuestionToQuestionDto(q)).ToListAsync();
    
        var quizAttempt = await _context.QuizAttempt.Where(attempt => attempt.QuizDetailId == qzid && attempt.UserId == uid).FirstOrDefaultAsync();

        if (quizAttempt == null)
            return Ok(new
            {
                question_details = questionDetails
            });
        var quizAnswers = await _context.QuizUserAnswer.Where(quizAnswer => quizAnswer.QuizAttemptId == quizAttempt.QuizAttemptId).Select(quizAnswer => QuizUserAnswer.QuizUserAnsToQuizUserAnsDto(quizAnswer)).ToListAsync();

        return Ok( new{
            quiz_answers = quizAnswers,
            question_details = questionDetails
        });

        // var quizAttemptDto = new QuizAttemptDto(aid, uid, qzid, DateTime.Now, 0 );
        // _context.QuizAttempt.Add(QuizAttempt.QuizAttemptDtoToQuizAttempt(quizAttemptDto));
        // await _context.SaveChangesAsync();
    }

    //Compare given answers and store - for 1 question


    [HttpPost("submitQuiz")]
    public async Task<ActionResult> SubmitQuiz(long uid, long attemptId, QuizUserAnswerDto[] answers)
    {
        // TODO: Do something to handle this
        return Ok();
    }
    
    [HttpPut("SubmitAnswer/{uid}/{attempid}/{qstnid}")]
    public async Task<ActionResult> SubmitQuizAnswer(long uid, long attempid, long qstnid, QuizUserAnswerDto user_ans)
    {
        if ( _context.QuizUserAnswer == null ) return NotFound();

        var quiz_attempt = await _context.QuizAttempt.FindAsync(attempid);
        var db_question = await _context.Question.FindAsync(qstnid);
        var ans_question = QuizUserAnswer.QuizUserAnsDtoToQuizUserAns(user_ans);

        if ( quiz_attempt == null ) return NotFound();
        if ( db_question == null ) return NotFound();

        float total_marks = 0;

        if ( ans_question.Select01 == db_question.Correctness01 ){
            ans_question.Correctness01 = true;
            total_marks += 2;
        } else {
            ans_question.Correctness01 = false;
            total_marks -= 2;
        }

        if ( ans_question.Select02 == db_question.Correctness02 ){
            ans_question.Correctness02 = true;
            total_marks += 2;
        } else {
            ans_question.Correctness02 = false;
            total_marks -= 2;
        }

        if ( ans_question.Select03 == db_question.Correctness03 ){
            ans_question.Correctness03 = true;
            total_marks += 2;
        } else {
            ans_question.Correctness03 = false;
            total_marks -= 2;
        }

        if ( ans_question.Select04 == db_question.Correctness04 ){
            ans_question.Correctness04 = true;
            total_marks += 2;
        } else {
            ans_question.Correctness04 = false;
            total_marks -= 2;
        }

        if ( ans_question.Select05 == db_question.Correctness05 ){
            ans_question.Correctness05 = true;
            total_marks += 2;
        } else {
            ans_question.Correctness05 = false;
            total_marks -= 2;
        }

        if ( total_marks < 0 ){
            total_marks = 0;
        }

        quiz_attempt.TotalMarks += total_marks;

        // Add question answer record
        _context.QuizUserAnswer.Add(ans_question);
        // Update total marks of the attempt
        _context.Entry(ans_question).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Ok();    // load next question

    }

    // add quiz details
    [HttpPost("AddNewQuiz")]
    public async Task<IActionResult> AddNewQuizDetail(QuizDetailDto quizDetailDto)
    {
        if ( _context.QuizDetail == null ) return NotFound();
        var quizDetail = QuizDetail.QuizDetailDtoToQuizDetail(quizDetailDto);
        _context.QuizDetail.Add(quizDetail);
        await _context.SaveChangesAsync();

        return Ok();
        // return CreatedAtAction("QuizDetails", new { id = quizDetail.QuizDetailId }, quizDetail);
    }

    // edit quiz details
    [HttpPut("EditQuiz/{editquizdetail}")]
    public async Task<IActionResult> EditQuizDetail(long id, QuizDetailDto quizDetailDto)
    {
        if (id != quizDetailDto.QuizDetailId)
        {
            return BadRequest();
        }
        if ( _context.QuizDetail == null ) return NotFound();
        var quizDetail = await _context.QuizDetail.FindAsync(id);
        if (quizDetail==null) 
        {
            return NotFound();
        } 
        else 
        {
            quizDetail = QuizDetail.QuizDetailDtoToQuizDetail(quizDetailDto);
        }
        _context.Entry(quizDetail).State = EntityState.Modified;
        try 
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuizDetailsExists(id))
            {
                return NotFound();
            }

            throw;
        }
        return NoContent();
    }

    // delete a quiz including whole questions inside it
    [HttpDelete("DeleteQuiz/{id}")]
    public async Task<IActionResult> DeleteQuizDetails(long id)
    {
        if (_context.QuizDetail == null) return NotFound();
        var quizDetail = await _context.QuizDetail.FindAsync(id);
        if (quizDetail == null) return NotFound();

        var questions = await _context.Question.Where(questionDetail => questionDetail.QuizDetailId == id ).ToListAsync();
        foreach ( var question in questions) {
            _context.Question.Remove(question);
        }
        _context.QuizDetail.Remove(quizDetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }



    // add questions
    [HttpPost("AddNewQuestion/{newquestion}")]
    public async Task<IActionResult> AddNewQuestion(QuestionDto questionDto)
    {
        if ( _context.Question == null ) return NotFound();
        var question = Question.QuestionDtoToQuestion(questionDto);
        _context.Question.Add(question);
        await _context.SaveChangesAsync();
        return Ok();
        // return CreatedAtAction("QuestionDetails", new { id = question.QuestionId }, question);
    }

    // delete a question
    [HttpDelete("DeleteQuestion/{id}")]
    public async Task<IActionResult> DeleteQuestion(long id)
    {
        if (_context.Question == null) return NotFound();
        var question = await _context.Question.FindAsync(id);
        if (question == null) return NotFound();

        _context.Question.Remove(question);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    //edit a question
    [HttpPut("EditQuestion/{editquizdetail}")]
    public async Task<IActionResult> EditQuestionDetail(long id, QuestionDto questionDto)
    {
        if (id != questionDto.QuestionId)
        {
            return BadRequest();
        }
        if ( _context.Question == null ) return NotFound();
        var question = await _context.Question.FindAsync(id);
        if (question==null) 
        {
            return NotFound();
        } 
        else 
        {
            question = Question.QuestionDtoToQuestion(questionDto);
        }_context.Entry(question).State = EntityState.Modified;
        try 
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }

            throw;
        }
        return NoContent();
    }


    // approve questions


    private bool QuizDetailsExists(long id)     
    {
        return (_context.QuizDetail?.Any(e => e.QuizDetailId == id)).GetValueOrDefault();
    }

    private bool QuestionExists(long id)     
    {
        return (_context.Question?.Any(e => e.QuestionId == id)).GetValueOrDefault();
    }


}