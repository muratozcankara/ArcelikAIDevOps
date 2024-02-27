using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ArcelikWebApi.Services
{
    public interface IDigitalOceanSpacesService
    {
        Task<string> Upload(IFormFile fileUpload, string key);
        Task Delete(string key);
    }
}
