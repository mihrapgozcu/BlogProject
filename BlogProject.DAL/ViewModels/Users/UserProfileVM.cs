using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Users
{
    public class UserProfileVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string About { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? Path { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
