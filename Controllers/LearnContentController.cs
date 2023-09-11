using Microsoft.AspNetCore.Mvc;
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


        // view all books


        // view selected books


        // add new book


        // approve new book



        // view all,selected articles


        // view all,selected videos


        // view all,selected researches


    }
}