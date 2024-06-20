using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.BLL.Services.Concrete
{
    public static class FluentValidationExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState) 
        { 
            foreach (var error in result.Errors) 
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        public static void AddToIdentityModelState(this IdentityResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError("", error.Description);
            }
        }
    }
}
