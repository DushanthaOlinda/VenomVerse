using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDetailController : ControllerBase
{
    private readonly VenomVerseContext _context;        // behaves like the variable for the database

    public UserDetailController(VenomVerseContext context)
    {
        _context = context;
    }

    // GET: UserDetail  => Get details of all users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()    
    {
        if (_context.UserDetail == null) return NotFound(); // If the table named 'UserDetail' does not exist
        // return await _context.UserDetail.ToListAsync();
        return await _context.UserDetail.Select(x => UserDetail.UserToUserDto(x)).ToListAsync();
    }

    // GET: UserDetail/{id}  => Get details of a selected user
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserDetail(long id)         
    {
        Console.Out.WriteLine(id);
        if (_context.UserDetail == null) return NotFound();
        var userDetail = await _context.UserDetail.FindAsync(id);
        if (userDetail == null) return NotFound();
        return UserDetail.UserToUserDto(userDetail);
    }

    // PUT: UserDetail/{id}  => Edit selected user details
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> EditUserDetails(long id, UserDto userDto)
    {
        if (id != userDto.UserId)
        {
            return BadRequest();
        }

        var userDetail = await _context.UserDetail.FindAsync(id);

        
        if (userDetail == null)
        {
            return NotFound();
        }
        else
        {
            userDetail = UserDtoToUserDetail(userDto, userDetail);
        }
        
        _context.Entry(userDetail).State = EntityState.Modified;
        try 
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserDetailsExists(id))
            {
                return NotFound();
            }

            throw;
        }
        return NoContent();
    }

    // POST: UserDetail  => Add new user details
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserDto>> PostCommunityPost(UserDto userDto)
    {
        if (_context.UserDetail == null) return Problem("Entity set 'VenomVerseContext.UserDetails'  is null.");
        var userDetail = UserDetail.UserDtoToUserDetail(userDto);
        _context.UserDetail.Add(userDetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUserDetail", new { id = userDetail.UserDetailId }, userDetail);
    }

    // DELETE: UserDetail/{id}  => Delete selected user account
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserDetails(long id)
    {
        if (_context.UserDetail == null) return NotFound();
        var userDetail = await _context.UserDetail.FindAsync(id);
        if (userDetail == null) return NotFound();

        _context.UserDetail.Remove(userDetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Check whether the relevant user exists in the database
    private bool UserDetailsExists(long id)     
    {
        return (_context.UserDetail?.Any(e => e.UserDetailId == id)).GetValueOrDefault();
    }
    

    // view user profiles - including posts, feedbacks, ratings


    // give feedbacks


    // give ratings


    // request catcher service


    // request to become catcher


    // request to become zoologist


    // publish articles - check whether zoology privillege or expert privillage
    

    // ============================================================================
    // ============================ DTO CONVERSION ================================
    // ============================================================================

    
    private static UserDetail UserDtoToUserDetail(UserDto userDto, UserDetail userDetail)
    {
        userDetail.UserDetailId = (long)userDto.UserId!;  
        // userDetail.FirstName = userDto.FirstName
        return userDetail;
    }

}