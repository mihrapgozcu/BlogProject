using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Users
{
    public class UserConfirmMailVM
    {
        public string Email { get; set; }
        public int ConfirmCode { get; set; }
    }
}
