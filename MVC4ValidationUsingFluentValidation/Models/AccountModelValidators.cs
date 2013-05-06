using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace MVC4ValidationUsingFluentValidation.Models
{
    public class RegisterExternalLoginModelValidator : AbstractValidator<RegisterExternalLoginModel>
    {
        public RegisterExternalLoginModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull();
        }    
    }

    public class LocalPasswordModelValidator : AbstractValidator<LocalPasswordModel>
    {
        public LocalPasswordModelValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotNull();
            RuleFor(x => x.NewPassword)
                .NotNull()
                .Length(6, 100);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword);
        }
    }

    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull();
            RuleFor(x => x.Password)
                .NotNull();
        }    
    }

    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull();
            RuleFor(x => x.Password)
                .NotNull()
                .Length(6, 100);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);
        }
    }
}