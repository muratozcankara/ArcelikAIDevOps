using Azure.Storage.Blobs;

namespace ArcelikWebApi.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> Upload(IFormFile fileUpload)
        {
            var containerName = "videos"; // Change this to your actual container name for videos
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobName = fileUpload.FileName;
            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(fileUpload.OpenReadStream());

            // Construct and return the Blob URL
            return blobClient.Uri.ToString(); // Properly format the Blob
        }
    }
}
