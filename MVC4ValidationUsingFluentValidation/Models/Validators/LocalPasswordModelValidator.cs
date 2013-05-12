using FluentValidation;

namespace MVC4ValidationUsingFluentValidation.Models.Validators
{
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
}