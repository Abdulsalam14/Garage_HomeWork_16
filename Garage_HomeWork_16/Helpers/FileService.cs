using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace Garage_HomeWork_16.Helpers
{
    public class FileService:IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(_hostEnvironment.WebRootPath, "assets/img", fileName);
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }
        public bool IsImage(IFormFile file) => file.ContentType.Contains("image/");

        public bool CheckSize(IFormFile file,int maxsize)=>(file.Length/1024) <= maxsize;

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
