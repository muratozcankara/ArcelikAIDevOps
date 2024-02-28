using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using MediaToolkit;
using MediaToolkit.Model;
using ArcelikWebApi.Models;
using Microsoft.AspNetCore.Http;

namespace ArcelikWebApi.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> Upload(IFormFile fileUpload, string containername)
        {
            var containerName = containername; // Change this to your actual container name for videos
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobName = fileUpload.FileName;
            var blobClient = containerClient.GetBlobClient(blobName);

            // Upload the video file to blob storage
            await blobClient.UploadAsync(fileUpload.OpenReadStream());

            // Construct and return the Blob URL along with the duration
            return $"{blobClient.Uri.ToString()}";
        }

        public async Task Delete(string blobUrl, string containername)
        {
            var containerName = containername;
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            // Parse the blob name from the blob URL
            var blobName = new Uri(blobUrl).Segments[^1]; // Using index to get the last segment

            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync();
        }

        public TimeSpan GetVideoDurationFromUrl(string videoUrl)
        {
            var tempFilePath = DownloadVideoFromUrl(videoUrl);
            var duration = GetVideoDuration(tempFilePath);
            // Delete the temporary downloaded file
            File.Delete(tempFilePath);
            return duration;
        }

        private string DownloadVideoFromUrl(string videoUrl)
        {
            var tempFilePath = Path.GetTempFileName();
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(videoUrl, tempFilePath);
            }
            return tempFilePath;
        }

        private TimeSpan GetVideoDuration(string filePath)
        {
            var inputFile = new MediaFile { Filename = filePath };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }
            return inputFile.Metadata.Duration;
        }
    }
}