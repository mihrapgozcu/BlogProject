using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Entities;
using BlogProject.DAL.UnitOfWorks;
using BlogProject.DAL.ViewModels.Users;
using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Data;

namespace BlogProject.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidator<AppUser> _validator;
        private readonly AppIdentityContext _appIdentityContext;

        public RegisterController(UserManager<AppUser> userManager, IValidator<AppUser> validator, AppIdentityContext appIdentityContext)
        {
            _userManager = userManager;
            _validator = validator;
            _appIdentityContext = appIdentityContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterVM);
            }

            Random rnd = new Random();      //mail aktivasyonu için kod ürettik.
            int code = rnd.Next(100000, 1000000);

            AppUser user = new AppUser() 
            { 
                FirstName = userRegisterVM.FirstName,
                LastName = userRegisterVM.LastName,
                UserName = userRegisterVM.Email,
                Email = userRegisterVM.Email,
                PhoneNumber = userRegisterVM.PhoneNumber,
                ConfirmCode = code,
                About = userRegisterVM.About
            };

            if (userRegisterVM.ConfirmPassword == null || userRegisterVM.ConfirmPassword != userRegisterVM.Password)
            {
                ModelState.AddModelError("", "Doğrulama şifresini yanlış girdiniz.");
                return View(userRegisterVM);
            }

            if(userRegisterVM.FirstName == null || userRegisterVM.LastName == null || userRegisterVM.PhoneNumber == null ||userRegisterVM.About == null)
            {
                ModelState.AddModelError("", "Eksik bilgi girdiniz");
                return View(userRegisterVM);
            }

            var validation = await _validator.ValidateAsync(user);
            var result = await _userManager.CreateAsync(user, string.IsNullOrEmpty(userRegisterVM.Password) ? "" : userRegisterVM.Password);    
            
            if (!result.Succeeded)
            {
                result.AddToIdentityModelState(this.ModelState);
                validation.AddToModelState(this.ModelState);
                return View(userRegisterVM);
            }

            IdentityUserRole<int> role = new IdentityUserRole<int>()    //Üyeye default Author rolü atamak için.
            {
                UserId =user.Id,
                RoleId = userRegisterVM.RoleId
            };
            _appIdentityContext.UserRoles.Add(role);
            _appIdentityContext.SaveChanges();

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Blog_Project Admin", "mihrapgozcu@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Kayıt işlemini gerçekleştirmek için onay kodunuz: {code}";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Blog_Project Üyelik Onay Kodu";

            SmtpClient smtpClient = new SmtpClient();

            //Gmail Türkiye kodu = 587
            smtpClient.Connect("smtp.gmail.com", 587, false);

            
            smtpClient.Authenticate("mihrapgozcu@gmail.com", "cuhn kxnv gloh yysx");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            TempData["Mail"] = userRegisterVM.Email;

            return RedirectToAction("Index", "ConfirmMail");
        }
    }
}
