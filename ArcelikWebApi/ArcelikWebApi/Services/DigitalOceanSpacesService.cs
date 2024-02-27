using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace ArcelikWebApi.Services
{
    public class DigitalOceanSpacesService : IDigitalOceanSpacesService
    {
        private readonly string _accessKeyId;
        private readonly string _secretAccessKey;
        private readonly string _bucketName;
        private readonly RegionEndpoint _regionEndpoint;

        public DigitalOceanSpacesService(IConfiguration configuration)
        {
            _accessKeyId = configuration["DigitalOceanSpaces:AccessKeyId"];
            _secretAccessKey = configuration["DigitalOceanSpaces:SecretAccessKey"];
            _bucketName = configuration["DigitalOceanSpaces:BucketName"];
            _regionEndpoint = RegionEndpoint.GetBySystemName(configuration["DigitalOceanSpaces:RegionEndpoint"]);
        }

        public async Task<string> Upload(IFormFile fileUpload, string key)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = "https://arcelikstorage.fra1.digitaloceanspaces.com",
                RegionEndpoint = _regionEndpoint
            };

            using (var client = new AmazonS3Client(_accessKeyId, _secretAccessKey, config))
            using (var fileStream = fileUpload.OpenReadStream())
            {
                var request = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = key,
                    InputStream = fileStream,
                    ContentType = fileUpload.ContentType
                };

                var response = await client.PutObjectAsync(request);

                // Construct and return the object URL
                return $"https://{_bucketName}.fra1.digitaloceanspaces.com/{key}";
            }
        }

        public async Task Delete(string key)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = "https://arcelikstorage.fra1.digitaloceanspaces.com",
                RegionEndpoint = _regionEndpoint
            };

            using (var client = new AmazonS3Client(_accessKeyId, _secretAccessKey, config))
            {
                var request = new DeleteObjectRequest
                {
                    BucketName = _bucketName,
                    Key = key
                };

                await client.DeleteObjectAsync(request);
            }
        }
    }
}