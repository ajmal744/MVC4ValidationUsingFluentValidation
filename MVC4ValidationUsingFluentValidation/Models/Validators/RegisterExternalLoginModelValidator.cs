using FluentValidation;

namespace MVC4ValidationUsingFluentValidation.Models.Validators
{
    public class RegisterExternalLoginModelValidator : AbstractValidator<RegisterExternalLoginModel>
    {
        public RegisterExternalLoginModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull();
        }    
    }
}