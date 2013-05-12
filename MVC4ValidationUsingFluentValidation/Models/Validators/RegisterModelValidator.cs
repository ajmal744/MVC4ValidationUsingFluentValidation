using FluentValidation;
using FluentValidation.Results;

namespace MVC4ValidationUsingFluentValidation.Models.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(6, 100);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);
        }

    }
}