namespace Garage_HomeWork_16.Helpers
{
    public interface IFileService
    {
        public Task<string> UploadAsync(IFormFile file);
        public bool IsImage(IFormFile file);
        public bool CheckSize(IFormFile file, int maxsize);
        public void DeleteFile(string path);

    }
}
