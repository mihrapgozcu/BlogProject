using BlogProject.DAL.Enums;
using BlogProject.DAL.ViewModels.Images;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _whe;
        private readonly string wwwroot;
        private const string imgFolder = "images";                         
        private const string articleImagesFolder = "article-images";
        private const string userImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment whe)
        {
            _whe = whe;
            wwwroot = whe.WebRootPath;
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }


        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
        }


        //name = makalemizin başlığı olacak. resmi o isimle kayıt edilen kısım.
        public async Task<ImageUploadedVM> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            //Image Type'a göre foldername oluştur.
            folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder;

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))     //dosya yoksa path'e göre oluştur
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);  
            string fileExtension = Path.GetExtension(imageFile.FileName);             

            name = ReplaceInvalidChars(name);      
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";   //aynı isimli resimler olmaması için Datetime'ın millisecond'ını kullandık. Dosya uzantısını eklendi.. 

            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024, useAsync:false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            return new ImageUploadedVM() { FullName = $"{folderName}/{newFileName}" };
        }
    }
}
