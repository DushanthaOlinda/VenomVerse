using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ImagedetectionController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public ImagedetectionController(VenomVerseContext context)
    {
        _context = context;
    }

    // save scanned image, prediction, accuracy


    // view scanned images


    // select the serpent type for scanned image
        // rearrange the user predictions and select the actual prediction


    
    

}