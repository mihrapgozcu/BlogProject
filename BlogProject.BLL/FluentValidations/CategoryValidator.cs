using BlogProject.DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Kategori Adı");
        }
    }
}
