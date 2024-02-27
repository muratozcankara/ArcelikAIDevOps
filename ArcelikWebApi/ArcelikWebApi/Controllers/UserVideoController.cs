using ArcelikWebApi.Data;
using ArcelikWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArcelikWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserVideoController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserVideoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: api/uservideo/status
        [HttpGet("status")]
        public async Task<IActionResult> GetUserVideoStatus()
        {
            var userEmail = HttpContext.Items["UserEmail"] as string;

            var userStatus = await _applicationDbContext.Users
                .Where(user => user.Email == userEmail)
                .Select(user => new
                {
                    user.WatchedVideoId,
                    user.WatchedTimeInSeconds
                })
                .FirstOrDefaultAsync();

            var videoCount = await _applicationDbContext.Videos.CountAsync();
            var lastVideoId = await _applicationDbContext.Videos.MaxAsync(v => (int?)v.Id) ?? 0;
            var lastTimeInSeconds = 16;

            var isWatchedAll = userStatus.WatchedVideoId >= lastVideoId && userStatus.WatchedTimeInSeconds >= lastTimeInSeconds;

            var videoDetails = await _applicationDbContext.Videos
                .Select(video => new { video.Id, video.BlobStorageUrl })
                .ToListAsync();

            var statusList = new
            {
                userStatus.WatchedVideoId,
                userStatus.WatchedTimeInSeconds,
                VideoCount = videoCount,
                VideoDetails = videoDetails,
                IsWatchedAll = isWatchedAll
            };

            return Ok(statusList);
        }


        // POST: api/uservideo/updatewatched
        [HttpPost("updatewatched")]
        public async Task<IActionResult> UpdateWatchedStatus([FromBody] WatchedVideoUpdateRequest request)
        {
            try
            {
                var userEmail = HttpContext.Items["UserEmail"] as string;

                if (userEmail != null)
                {
                    // Find the user by email
                    var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

                    if (user == null)
                    {
                        return NotFound("User not found"); // Customize the response as needed
                    }

                    var video = _applicationDbContext.Videos.Find(request.WatchedVideoId);

                    if (video == null)
                    {
                        return BadRequest("Invalid WatchedVideoId");
                    }

                    // Update the watched video and time
                    user.WatchedVideoId = request.WatchedVideoId;
                    user.WatchedTimeInSeconds = request.WatchedTimeInSeconds;

                    await _applicationDbContext.SaveChangesAsync();

                    return Ok("Watched video updated successfully");
                }
                else
                {
                    return BadRequest("User email not provided in the request"); // Customize the response as needed
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
