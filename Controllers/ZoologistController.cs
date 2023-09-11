using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ZoologistController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public ZoologistController(VenomVerseContext context)
    {
        _context = context;
    }

    
    // view requested articles


    // approve or decline requested articles


    // publish research -> learn content controller


    // HANDLE LEARNING MATERIALS
    

}