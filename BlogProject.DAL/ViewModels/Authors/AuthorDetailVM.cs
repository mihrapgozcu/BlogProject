using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Articles;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Authors
{
    public class AuthorDetailVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string? Path { get; set; }
        public List<Article> Articles { get; set; }
        public AuthorDetailVM()
        {
            Articles = new List<Article>();
        }
    }
}
