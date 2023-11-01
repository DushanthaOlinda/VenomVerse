using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class NotificationController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public NotificationController(VenomVerseContext context)
    {
        _context = context;
    }



    

    

}