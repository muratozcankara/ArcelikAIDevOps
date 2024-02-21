using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArcelikWebApi.Models;
using ArcelikWebApi.Services;
using ArcelikWebApi.Data;
using ArcelikWebApi.Models.Admin;

namespace ArcelikWebApi.Controllers
{
    [Route("api/adminvideo")]
    [ApiController]
    public class AdminVideoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBlobService _blobService;

        public AdminVideoController(ApplicationDbContext dbContext, IBlobService blobService)
        {
            _dbContext = dbContext;
            _blobService = blobService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadVideo([FromForm] CreateVideoDTO videoDto)
        {
            if (videoDto.VideoFile == null || videoDto.VideoFile.Length == 0)
            {
                return BadRequest("Video file is missing or empty.");
            }

            // Query the database to find the last VideoId
            int lastVideoId = await _dbContext.Videos.MaxAsync(v => (int?)v.Id) ?? 0;

            // Increment the last VideoId to get the new VideoId
            int newVideoId = lastVideoId + 1;

            // Upload the video file to Azure Blob Storage
            var blobStorageUrl = await _blobService.Upload(videoDto.VideoFile);

            // Save the video metadata to the database
            var newVideo = new Video
            {
                Id = newVideoId,
                Title = videoDto.Title,
                BlobStorageUrl = blobStorageUrl
            };

            _dbContext.Videos.Add(newVideo);
            await _dbContext.SaveChangesAsync();

            return Ok(newVideo); // Return the created video object
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _dbContext.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _dbContext.Videos.Remove(video);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
