using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CatcherController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public CatcherController(VenomVerseContext context)
    {
        _context = context;
    }

    // change availability 


    // view catcher requests


    // approve or decline catcher requests


    // view service notifications


    // approve or decline service 


    // complete service

    

    

}