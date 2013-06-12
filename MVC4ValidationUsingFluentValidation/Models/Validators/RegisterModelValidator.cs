using FluentValidation;
using FluentValidation.Results;

namespace MVC4ValidationUsingFluentValidation.Models.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        private readonly IUserProfileRepository userProfileRepository;

        public RegisterModelValidator(IUserProfileRepository userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;

            RuleFor(x => x.UserName)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(6, 100);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);

            Custom(rm =>
                   {
                       UserProfile userProfile = userProfileRepository.GetUserProfileByUserName(rm.UserName);

                       if (userProfile != null)
                           return new ValidationFailure("UserName", "This user name is already registered");

                       return null;
                   });
        }
    }
}