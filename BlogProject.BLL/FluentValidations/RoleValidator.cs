using BlogProject.DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.FluentValidations
{
    public class RoleValidator : AbstractValidator<AppRole>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(40)
            .WithName("Rol");
        }
    }
}
