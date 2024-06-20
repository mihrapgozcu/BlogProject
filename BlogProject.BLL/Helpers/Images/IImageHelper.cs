using BlogProject.DAL.Enums;
using BlogProject.DAL.ViewModels.Images;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedVM> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);

        void Delete(string imageName);
    }
}
