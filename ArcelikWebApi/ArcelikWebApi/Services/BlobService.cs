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

        public async Task<string> Upload(IFormFile fileUpload, string containername) //container name define and update
        {
            var containerName = containername; // Change this to your actual container name for videos
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobName = fileUpload.FileName;
            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(fileUpload.OpenReadStream());

            // Construct and return the Blob URL
            return blobClient.Uri.ToString(); // Properly format the Blob
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
    }
}
