using Azure.Storage.Blobs;
using MediaToolkit;
using MediaToolkit.Model;
using ArcelikWebApi.Models;
using ArcelikWebApi.Data;

namespace ArcelikWebApi.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly ApplicationDbContext _dbContext;

        public BlobService(BlobServiceClient blobServiceClient, ApplicationDbContext dbContext)
        {
            _blobServiceClient = blobServiceClient;
            _dbContext = dbContext;
        }

        public async Task<string> Upload(IFormFile fileUpload, string containername)
        {
            var containerName = containername; // Change this to your actual container name for videos
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobName = fileUpload.FileName;
            var blobClient = containerClient.GetBlobClient(blobName);

            // Upload the video file to blob storage
            await blobClient.UploadAsync(fileUpload.OpenReadStream());

            // Extract video duration using MediaToolkit
            var videoDuration = await ExtractVideoDuration(blobClient.Uri);

            // Save video duration to the database
            var video = new Video
            {
                DurationInSeconds = (int)videoDuration.TotalSeconds
            };

            _dbContext.Videos.Add(video);
            await _dbContext.SaveChangesAsync();

            // Construct and return the Blob URL along with the duration
            return $"{blobClient.Uri.ToString()}|{videoDuration.TotalSeconds}";
        }

        public async Task Delete(string blobUrl, string containername)
        {
            var containerName = containername;
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            // Parse the blob name from the blob URL
            var blobName = new Uri(blobUrl).Segments.Last();

            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync();
        }

        private async Task<TimeSpan> ExtractVideoDuration(Uri blobUri)
        {
            using (var fileStream = await DownloadBlob(blobUri))
            {
                var inputFile = new MediaFile { Filename = blobUri.LocalPath };
                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                    var duration = inputFile.Metadata.Duration;

                    if (duration != null)
                    {
                        return TimeSpan.FromSeconds(duration.TotalSeconds);
                    }
                    else
                    {
                        return TimeSpan.Zero; // Or any default value you prefer
                    }
                }
            }
        }

        private async Task<Stream> DownloadBlob(Uri blobUri)
        {
            var blobClient = new BlobClient(blobUri);
            var blobDownloadInfo = await blobClient.DownloadAsync();
            return blobDownloadInfo.Value.Content;
        }
    }
}
