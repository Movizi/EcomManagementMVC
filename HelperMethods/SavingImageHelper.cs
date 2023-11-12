using Azure.Core;
using Microsoft.AspNetCore.Hosting;

namespace EcomManagement.HelperMethods
{
    public static class SavingImageHelper
    {
        public static string SaveImageAndGetString<T>(IFormFile image, IWebHostEnvironment webHost)
        {
            string getFolderName = typeof(T).Name;

            string folder = $"Images/{getFolderName}/";

            string fileName = image.FileName;
            string filePath = Path.Combine(webHost.WebRootPath, folder, fileName);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return $"/{folder}{fileName}";
        }

        public static bool DeleteImage<T>(string imageName, IWebHostEnvironment webHost)
        {
            string getFolderName = typeof(T).Name;
            string webRootPath = webHost.WebRootPath;
            string imagePath = Path.Combine(webRootPath, "Images", getFolderName, imageName);

            try
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IFormFile GetFormFileFromPath(string filePath)
        {

            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string physicalPath = Path.Combine(wwwRootPath, filePath.TrimStart('~', '/'));


            // Read the file content into a byte array
            byte[] fileBytes = File.ReadAllBytes(physicalPath);

            // Create a stream from the byte array
            Stream stream = new MemoryStream(fileBytes);

            // Create an IFormFile using the stream
            IFormFile formFile = new FormFile(stream, 0, fileBytes.Length, "name", Path.GetFileName(filePath));

            return formFile;
        }
    }
}
