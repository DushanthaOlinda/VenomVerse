using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CommunityAdminController : ControllerBase
{
    private readonly VenomVerseContext _context;
    public CommunityAdminController(VenomVerseContext context)
    {
        _context = context;
    }

    
    // view zoology requests


    // approve or decline zoology requests


    // view requested post 


    // approve, decline posts


    // view declined posts


    // approve posts again


    // view complaints ( fake request service )


    // actions on complaints - ban accounts


    // activate banned accounts


    // deactivate banned accounts -> send notification


    

}