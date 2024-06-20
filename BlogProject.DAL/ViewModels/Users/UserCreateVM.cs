using BlogProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Users
{
    public class UserCreateVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}
