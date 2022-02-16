using Microsoft.AspNetCore.Http;

namespace DemoApi.FileServices
{
    public interface IFileService
    {
        void UploadFile(IFormFile files, string subDirectory);       
        string SizeConverter(long bytes);
    }
}
