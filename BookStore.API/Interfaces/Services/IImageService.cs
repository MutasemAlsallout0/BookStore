namespace BookStore.API.Interfaces.Services
{
    public interface IImageService
    {
         Task<string> UploadImage(IFormFile imageFile);
        string GetUploadedImage(string fileName);

        Task ResizeImage(string filePath, string uploadedFolder, string fileName);
    }
}
