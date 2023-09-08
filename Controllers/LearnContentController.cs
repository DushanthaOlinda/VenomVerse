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

    }
}