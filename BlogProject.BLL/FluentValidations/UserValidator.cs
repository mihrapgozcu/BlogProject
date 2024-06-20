using BlogProject.DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(60)
                .WithName("İsim");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(60)
                .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(11)
                .WithName("Telefon Numarası");
        }
    }
}
