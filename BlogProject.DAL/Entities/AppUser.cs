using BlogProject.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? About { get; set; }
        public int? ConfirmCode { get; set; }
        public string? Path { get; set; } = "user-images/kullanici.png";

        public virtual ICollection<Article>? Articles { get; set; }

        public AppUser()
        {
            Articles = new HashSet<Article>();
        }
    }
}
