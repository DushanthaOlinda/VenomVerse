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
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers() {
        if (_context.UserDetail == null) return NotFound(); // If the table named 'UserDetail' does not exist
        // return await _context.UserDetail.ToListAsync();
        return await _context.UserDetail.Select(x => UserToUserDto(x)).ToListAsync();
    }

    // GET: UserDetail/{id}  => Get details of a selected user
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserDetail(long id) {
        if (_context.UserDetail == null) return NotFound();
        var userDetail = await _context.UserDetail.FindAsync(id);
        if (userDetail == null) return NotFound();
        return UserToUserDto(userDetail);
    }

    // PUT: UserDetail/{id}  => Edit selected user details
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> EditUserDetails(long id, UserDto userDto) {
        if (id != userDto.UserId) return BadRequest();
        if (_context.UserDetail == null) return NotFound();
        var userDetail = await _context.UserDetail.FindAsync(id);
        if (userDetail == null) return NotFound();
        userDetail = UserDtoToUserDetail(userDto, userDetail); 
        _context.Entry(userDetail).State = EntityState.Modified;
        try  {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!UserDetailsExists(id))
                return NotFound();
            throw;
        }
        return NoContent();
    }

    // POST: UserDetail  => Add new user details
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserDto>> PostUserDetails(UserDto userDto) {
        if (_context.UserDetail == null) return Problem("Entity set 'VenomVerseContext.UserDetails'  is null.");
        var userDetail = UserDtoToUserDetail(userDto);
        _context.UserDetail.Add(userDetail);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetUserDetail", new { id = userDetail.UserDetailId }, userDetail);
    }

    // DELETE: UserDetail/{id}  => Detele selected user account
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserDetails(long id) {
        if (_context.UserDetail == null) return NotFound();
        var userDetail = await _context.UserDetail.FindAsync(id);
        if (userDetail == null) return NotFound();
        _context.UserDetail.Remove(userDetail);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Check whether the relevant user exists in the database
    private bool UserDetailsExists(long id) {
        return (_context.UserDetail?.Any(e => e.UserDetailId == id)).GetValueOrDefault();
    }
    

    // ============================================================================
    // ============================ DTO CONVERSION ================================
    // ============================================================================

    private static UserDto UserToUserDto(UserDetail user) => new UserDto {
        UserId = user.UserDetailId,
        // UserProfilePicture = user.UserProfilePicture,
        UserName = user.UserName,
        FirstName = user.FirstName,
        LastName = user.LastName,
        UserEmail = user.UserEmail,
        CurrentMarks = user.CurrentMarks,
        Nic = user.Nic,
        Dob = user.Dob,
        District = user.District,
        Address = user.Address,
        ContactNo = user.ContactNo,
        WorkingStatus = user.WorkingStatus,
        AccountStatus = user.AccountStatus
    };

    private static UserDetail UserDtoToUserDetail(UserDto userDto) => new UserDetail {
        UserDetailId = (long)userDto.UserId!,
        // UserProfilePicture = userDto.UserProfilePicture!,
        UserName = userDto.UserName!,
        FirstName = userDto.FirstName!,
        LastName = userDto.LastName!,
        UserEmail = userDto.UserEmail!,
        CurrentMarks = (float)userDto.CurrentMarks!,
        Nic = userDto.Nic!,
        Dob = (DateOnly)userDto.Dob!,
        District = userDto.Dob.ToString()!,
        Address = userDto.Address!,
        ContactNo = userDto.ContactNo!,
        WorkingStatus = userDto.WorkingStatus!,
        AccountStatus = userDto.AccountStatus!,
    };
    
    private static UserDetail UserDtoToUserDetail(UserDto userDto, UserDetail userDetail) {
        if (userDto.UserName != null){
            userDetail.UserName = userDto.UserName!;
        }
        // if (userDto.UserProfilePicture != null){
        //     userDetail.UserProfilePicture = userDto.UserProfilePicture!;
        // }
        if (userDto.FirstName != null){
            userDetail.FirstName = userDto.FirstName!;
        }
        if (userDto.LastName != null){
            userDetail.LastName = userDto.LastName!;
        }
        if (userDto.UserEmail != null){
            userDetail.UserEmail = userDto.UserEmail!;  
        }
        if (userDto.CurrentMarks != null){
            userDetail.CurrentMarks = (float)userDto.CurrentMarks!;
        }
        if (userDto.Nic != null){
            userDetail.Nic = userDto.Nic!;     
        }
        if (userDto.Dob != null){
            userDetail.Dob = (DateOnly)userDto.Dob!;
        }
        if (userDto.District != null){
            userDetail.District = userDto.Dob.ToString()!;
        }
        if (userDto.Address != null){
            userDetail.Address = userDto.Address!;
        }
        if (userDto.ContactNo != null){
            userDetail.ContactNo = userDto.ContactNo!;
        }
        if (userDto.WorkingStatus != null){
            userDetail.WorkingStatus = userDto.WorkingStatus!;
        }
        if (userDto.AccountStatus != null){
            userDetail.AccountStatus = userDto.AccountStatus!; 
        }
        return userDetail;
        // userDetail.UserDetailId = (long)userDto.UserId!;
        // userDetail.UserName = userDto.UserName!;
        // userDetail.FirstName = userDto.FirstName!;
        // userDetail.LastName = userDto.LastName!;
        // userDetail.UserEmail = userDto.UserEmail!;
        // userDetail.CurrentMarks = (float)userDto.CurrentMarks!;
        // userDetail.Nic = userDto.Nic!;
        // userDetail.Dob = (DateOnly)userDto.Dob!;
        // userDetail.District = userDto.Dob.ToString()!;
        // userDetail.Address = userDto.Address!;
        // userDetail.ContactNo = userDto.ContactNo!;
        // userDetail.WorkingStatus = userDto.WorkingStatus!;
        // userDetail.AccountStatus = userDto.AccountStatus!;
        // return userDetail;
    }
}