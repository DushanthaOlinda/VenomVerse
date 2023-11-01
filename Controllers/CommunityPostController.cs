using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi.DTO;
using VenomVerseApi.Models;

namespace VenomVerseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityPostController : ControllerBase
    {
        private readonly VenomVerseContext _context;

        public CommunityPostController(VenomVerseContext context)
        {
            _context = context;
        }

        // show all posts of a perticular user

        // view all approved community posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPost()
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.PostStatus == (int)PostStatus.Posted).ToList();
        }

        // view all approved community posts of a selected user
        [HttpGet("{uid}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPostSelectedUser(long userId)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.UserId==userId && p.PostStatus == (int)PostStatus.Posted).ToList();
        }

        // view all pending approval posts
        [HttpGet("NotApproved")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPostNotApproved()
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.PostStatus == (int)PostStatus.PendingApproval).ToList();
        }

        // view all pending approval posts of a selected user
        [HttpGet("NotApproved/{uid}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPostNotApproved(long userId)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.UserId==userId && p.PostStatus == (int)PostStatus.PendingApproval).ToList();
        }

        // view all hidden posts of a selected user
        [HttpGet("Hidden/{uid}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPostHidden(long userId)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.UserId==userId && p.PostStatus == (int)PostStatus.Hidden).ToList();
        }

        // view all reported approval posts
        [HttpGet("Reported")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPostReported()
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.PostStatus == (int)PostStatus.Reported).ToList();
        }

        // view all reported approval posts of a selected user
        [HttpGet("Reported/{uid}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetCommunityPostReportedOfSelecteduser( long userId)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var all_posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return all_posts.Where(p => p.UserId==userId && p.PostStatus == (int)PostStatus.Reported).ToList();
        }

        // private async Task<ActionResult> getUserById(long id){
        //     var user =  await _context.UserDetail.FindAsync(id);
        //     return user.UserName;
        // }

        // view selected community posts
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetCommunityPost(long id)
        {
          if (_context.CommunityPost == null)
          {
              return NotFound();
          }
          var communityPost = await _context.CommunityPost.FindAsync(id);

          if (communityPost == null)
          {
              return NotFound();
          }
          
          var comments = _context.CommunityPostComment.Where(p => p.CommunityPostId == communityPost.CommunityPostId).ToList();
          var reports = _context.CommunityPostReport.Where(p => p.CommunityPostId == communityPost.CommunityPostId).ToList();
          var user = _context.UserDetail.Where(u => u.UserDetailId==communityPost.UserId).FirstOrDefault();

          PostDto postDetails = CommunityPost.CreatePostDto(communityPost, comments, reports, user);

          return postDetails;
        }
        
        
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // edit communitypost
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityPost(long id, CommunityPost communityPost)
        {
            if (id != communityPost.CommunityPostId)
            {
                return BadRequest();
            }

            _context.Entry(communityPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // add new community post
        [HttpPost]
        public async Task<ActionResult<CommunityPost>> PostCommunityPost(PostDto communityPost)
        {
          if (_context.CommunityPost == null)
          {
              return Problem("Entity set 'VenomVerseContext.CommunityPost'  is null.");
          }
          
          //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
          _context.CommunityPost.Add(CommunityPost.PostDtoToPost(communityPost));

          await _context.SaveChangesAsync();

          return CreatedAtAction("GetCommunityPost", new { id = communityPost.PostId }, communityPost);
        }

        

        // delete a community post
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityPost(long id)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            var communityPost = await _context.CommunityPost.FindAsync(id);
            if (communityPost == null)
            {
                return NotFound();
            }

            _context.CommunityPost.Remove(communityPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        
        // add a new comment to a community post
        [HttpPost("AddComment/{id}")]
        public async Task<ActionResult<CommunityPost>> PostCommunityPostComment(long id, PostCommentDto commentDto)
        {
            if (_context.CommunityPost == null)
            {
                return Problem("Entity set 'VenomVerseContext.CommunityPost'  is null.");
            }

            if (id != commentDto.PostId)
            {
                return Problem("Id Mismatch");
            }

            var communityPost = await _context.CommunityPost.FindAsync(id);
            if (communityPost == null)
            {
                return NotFound();
            }

            var comment = new CommunityPostComment
            {
                CommunityPostCommentId = commentDto.CommentId,
                CommunityPostId = commentDto.PostId,
                UserId = commentDto.UserId,
                DateTime = commentDto.DateTime,
                Comment = commentDto.Comment
            };

            _context.CommunityPostComment.Add(comment);
          
            //   _context.CommunityPost.Add(PostDtoToPost(communityPost));
            // _context.CommunityPost.Add(CommunityPost.PostDtoToPost(communityPost));

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityPost", new { id = commentDto.PostId }, comment);
        }


        // user individual posts
        [HttpGet("IndividualPost/{uid}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetIndividualCommunityPost(long uid)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            // return await _context.CommunityPost.ToListAsync();
            var posts = await _context.CommunityPost.Select(x => CommunityPost.CreatePostDto(
                x,
                _context.CommunityPostComment.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.CommunityPostReport.Where(p => p.CommunityPostId == x.CommunityPostId).ToList(),
                _context.UserDetail.Where(u => u.UserDetailId==x.UserId).FirstOrDefault()
                )
            ).ToListAsync();

            return posts.Where(p => p.UserId == uid).ToList();
        }


        // approve community post
        [HttpPut("ApproveCommunityPost/{id}")]
        public async Task<IActionResult> ApproveCommunityPost(long id, long comAdminId, bool action)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            
            var post = await _context.CommunityPost.FindAsync(id);
            
            if (post == null)
            {
                return NotFound();
            }

            if ( action==true )
            {
                post.PostStatus = (int)PostStatus.Posted;
            }
            else
            {
                post.PostStatus = (int)PostStatus.Rejected;
            }
            post.ApprovedAdmin = comAdminId;
            
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return Ok("Post Approved");
        }


        // delete a comment from community post


        // report a community post - send a notification


        // view own posts


        // like/unlike a post
        [HttpPut("LikeUnlikePost/{id}")]
        public async Task<IActionResult> LikeUnlikePost(long postId, long userId, bool like_status)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            
            var post = await _context.CommunityPost.FindAsync(postId);
            
            if (post == null)
            {
                return NotFound();
            }

            if ( like_status==true )
            {
                if ( !post.React.ToList().Contains(userId) ){
                    post.React.ToList().Add(userId);
                }
            }
            else
            {
                if ( post.React.ToList().Contains(userId) ){
                    post.React.ToList().Remove(userId);
                }
            }

            _context.Entry(post).State = EntityState.Modified;
            
            return Ok("Post Approved");
        }


        // hide/unhide a post
        [HttpPut("HideUnhidePost/{id}")]
        public async Task<IActionResult> HideUnhidePost(long postId, long userId, bool hideStatus)
        {
            if (_context.CommunityPost == null)
            {
                return NotFound();
            }
            
            var post = await _context.CommunityPost.FindAsync(postId);
            
            if (post == null)
            {
                return NotFound();
            }

            if ( post.UserId == userId )
            {
                if ( hideStatus == true )
                {
                    post.PostStatus = (int)PostStatus.Hidden;
                }
                else
                {
                    post.PostStatus = (int)PostStatus.Posted;
                }

                _context.Entry(post).State = EntityState.Modified;
                return Ok("Post Approved");
            }
            else
            {
                return BadRequest();
            }

        }


        

        private bool CommunityPostExists(long id)
        {
            return (_context.CommunityPost?.Any(e => e.CommunityPostId == id)).GetValueOrDefault();
        }
    }
}

// for like use put method 
// for comment create separate table records for this post id