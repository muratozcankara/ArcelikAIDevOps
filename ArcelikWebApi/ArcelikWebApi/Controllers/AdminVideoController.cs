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

            // Upload the video file to Azure Blob Storage
            var blobStorageUrl = await _blobService.Upload(videoDto.VideoFile);

            // Save the video metadata to the database
            var newVideo = new Video
            {
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideo(int id, [FromForm] UpdateVideoDTO videoDto)
        {
            // Find the video in the database by ID
            var video = await _dbContext.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound(); // Video not found
            }

            // Check if both title and video file are not provided
            if (string.IsNullOrEmpty(videoDto.Title) && (videoDto.VideoFile == null || videoDto.VideoFile.Length == 0))
            {
                return BadRequest("You need to provide either the title or the video file to update.");
            }

            // Update the video file if provided
            if (videoDto.VideoFile != null && videoDto.VideoFile.Length > 0)
            {
                // Upload the new video file to Azure Blob Storage
                var blobStorageUrl = await _blobService.Upload(videoDto.VideoFile);
                video.BlobStorageUrl = blobStorageUrl;
            }

            // Update the video's title if provided
            if (!string.IsNullOrEmpty(videoDto.Title))
            {
                video.Title = videoDto.Title;
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return Ok(video); // Return the updated video object
        }

    }
}
