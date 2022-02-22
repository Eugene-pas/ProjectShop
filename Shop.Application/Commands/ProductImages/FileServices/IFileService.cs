using Microsoft.AspNetCore.Http;

namespace Shop.Application.Commands.ProductImages.FileServices
{
    public interface IFileService
    {
        void UploadFile(IFormFile files, string subDirectory);       
        string SizeConverter(long bytes);
    }
}
