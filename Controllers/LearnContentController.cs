using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnContentController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public LearnContentController(VenomVerseContext context)
        {
            _context = context;
        }


        // view all books>
        [HttpGet("AllBooks")]
        public async Task<ActionResult<List<CommunityBookDto>>> GetAllBooks()
        {
            if (_context.CommunityBook == null)
            {
                return NoContent();
            }

            return await _context.CommunityBook.Select(book => book.ToBookDto()).ToListAsync();
        }


        // view selected books
        [HttpGet("GetBook/{newBookId}")]
        public async Task<ActionResult<CommunityBookDto>> GetBook(long newBookId)
        {
            if (_context.CommunityBook == null)
            {
                return NoContent();
            }

            var book = await _context.CommunityBook.FindAsync(newBookId);

            if (book == null)
            {
                return NotFound();
            }

            return book.ToBookDto();
        }
        
        // add new book
        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(long zoologistId, CommunityBookDto communityBookDto)
        {
            if (_context.CommunityBook == null)
            {
                return NoContent();
            }

            try
            {
                var zoologist = await _context.Zoologist.FindAsync(zoologistId);
                if (zoologist == null)
                {
                    throw new ApplicationException("Could not find zoologist With this Id");
                }
            }
            catch (ApplicationException ex)
            {
                var errorResponse = new CustomError
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, errorResponse);
            }

            var newBook = new CommunityBook
            {
                Author = communityBookDto.Author,
                Availability = false,
                Category = communityBookDto.Category,
                CommunityBookId = new Random(10000).NextInt64(),
                Content = communityBookDto.Content,
                Description = communityBookDto.Description,
                Media = communityBookDto.Media,
                PublishedDate = communityBookDto.PublishedDate,
                UploadedDate = new DateOnly(),
                UploadedUserId = communityBookDto.UploadedUserId,
            };

            _context.CommunityBook.Add(newBook);
                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityBookExists(newBook.CommunityBookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return CreatedAtAction( "GetBook", new { BookId = newBook.CommunityBookId}, communityBookDto);

        }



        // approve new book
        
        // [HttpPost("approveBook/{id}")]
        
        // view all,selected articles

        [HttpGet("getArticle/{id}")]
        public async Task<ActionResult<CommunityArticle>> GetArticle(int id)
        {
            if (_context.CommunityArticle == null)
            {
                return NoContent();
            }

            var book = await _context.CommunityArticle.FindAsync(id);
            if (book == null)
            {
                return NoContent();
            }

            return book;
        }
        
        [HttpGet("getAllArticle")]
        public async Task<ActionResult<List<CommunityArticle>>> GetAllArticles()
        {
            if (_context.CommunityArticle == null)
            {
                return NoContent();
            }

            var books = await _context.CommunityArticle.ToListAsync();
            if (books == null)
            {
                return NoContent();
            }

            return books;
        }
        
        // view all,selected videos
        // TODO: Implement Video Controller

        // [HttpGet("getVideos/{id}")]
        // public async Task<ActionResult<CommunityArticle>> GetVideo(int id)
        // {
        //     if (_context.CommunityArticle == null)
        //     {
        //         return NoContent();
        //     }
        //
        //     var book = await _context..FindAsync(id);
        //     if (book == null)
        //     {
        //         return NoContent();
        //     }
        //
        //     return book;
        // }
        // [HttpGet("getAllArticle")]
        // public async Task<ActionResult<List<CommunityArticle>>> GetAllArticles()
        // {
        //     if (_context.CommunityArticle == null)
        //     {
        //         return NoContent();
        //     }
        //
        //     var books = await _context.CommunityArticle.ToListAsync();
        //     if (books == null)
        //     {
        //         return NoContent();
        //     }
        //
        //     return books;
        // }
        

        //TODO: view all,selected researches

        [HttpGet("getResearch/{id}")]
        public async Task<ActionResult<CommunityResearch>> GetResearch(int id)
        {
            if (_context.CommunityResearch == null)
            {
                return NoContent();
            }
        
            var research = await _context.CommunityResearch.FindAsync(id);
            if (research == null)
            {
                return NoContent();
            }
        
            return research;
        }
        [HttpGet("getAllResearches")]
        public async Task<ActionResult<List<CommunityResearch>>> GetAllResearches()
        {
            if (_context.CommunityResearch == null)
            {
                return NoContent();
            }
        
            var researches = await _context.CommunityResearch.ToListAsync();
            if (researches == null)
            {
                return NoContent();
            }
        
            return researches;
        }

        
        
        
        
        private bool CommunityBookExists(long newBookCommunityBookId)
        {
            return (_context.CommunityBook?.Any(e => e.CommunityBookId == newBookCommunityBookId)).GetValueOrDefault();
        }

        
        
    }
}