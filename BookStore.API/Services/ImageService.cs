using BookStore.API.Interfaces.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BookStore.API.Services
{
    public class ImageService : IImageService
    {
        private const string uploadDir = "./wwwroot/images";

        public async Task<string> UploadImage(IFormFile imageFile)
        {
            if (!imageFile.ContentType.StartsWith("image/"))
            {
                return "";
            }

            // ContentType = "image/jpeg"
            // Output: "jpeg"
            var fileExtension = imageFile.ContentType.Split('/')[1];
            var fileName = Guid.NewGuid().ToString();
            fileName = $"{fileName}.{fileExtension}";
           await StoreUploadedImage(imageFile, fileName);


            return fileName;

        }

        private  async Task StoreUploadedImage(IFormFile imageFile, string fileName)
        {
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            var filePath = Path.Combine(uploadDir, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
               await imageFile.CopyToAsync(fileStream);
            }

            await ResizeImage(filePath, uploadDir, fileName);


        }

        

        public async Task ResizeImage(string filePath, string uploadedFolder, string fileName)
        {
            var folderMedi = Path.Combine(uploadedFolder, "Thumbs", "Med", fileName);
            var folderSmall = Path.Combine(uploadedFolder, "Thumbs", "Small", fileName);
            var folderBig = Path.Combine(uploadedFolder, "Thumbs", "Big", fileName);

            //application/pdf
            //images/jpg
            using (Image input = Image.Load(filePath))
            {
                input.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Max, Size = new Size(457, 666) }));
                await input.SaveAsync(folderBig);

                input.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Crop, Size = new Size(266,378) }));
                await input.SaveAsync(folderMedi);

                input.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Crop, Size = new Size(199, 131) }));
                await input.SaveAsync(folderSmall); 
                
               

            }
        }


        public string GetUploadedImage(string fileName)
        {
            return Path.Combine(uploadDir, fileName);
        }
    }
}
