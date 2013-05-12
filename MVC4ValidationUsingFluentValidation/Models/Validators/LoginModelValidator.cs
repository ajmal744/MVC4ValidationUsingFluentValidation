using FluentValidation;

namespace MVC4ValidationUsingFluentValidation.Models.Validators
{
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
}