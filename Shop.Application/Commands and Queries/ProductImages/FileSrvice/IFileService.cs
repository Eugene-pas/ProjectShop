using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DemoApi.FileSrvice
{
    public interface IFileService
    {
        void UploadFile(IFormFile files, string subDirectory);       
        string SizeConverter(long bytes);
    }
}
