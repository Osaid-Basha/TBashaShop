using Microsoft.AspNetCore.Routing.Constraints;
using TBashaShop.Models;

namespace TBashaShop.Services
{
    public class ImageServices
    {
        private string _imageFolderPath;
        public ImageServices() {

            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        }
        public string UploadImage(IFormFile Image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            var filePath = Path.Combine(_imageFolderPath, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                Image.CopyTo(stream);
            }
            return fileName;
        }
        public bool DeleteImage(string fileName) {
            var filePath = Path.Combine(_imageFolderPath, fileName);
            if (File.Exists(filePath))
            {
                
                System.IO.File.Delete(filePath);
                return true;
            }
            return false;
            
        }

    }
}
