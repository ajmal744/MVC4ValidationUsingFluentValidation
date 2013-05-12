using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using MVC4ValidationUsingFluentValidation.Models;
using MVC4ValidationUsingFluentValidation.Models.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace MVC4ValidationUsingFluentValidation.Tests.Models.Validators
{
    [TestClass]
    public class RegisterModelValidatorTests
    {
        private RegisterModelValidator validator;

        [TestInitialize]
        public void SetUp()
        {
            validator = new RegisterModelValidator();
        }

        [TestMethod]
        public void ShouldNotHaveValidationErrorsWhenValidModelIsSupplied()
        {
            ValidationResult validationResult = validator.Validate(new RegisterModel
                                                                   {
                                                                       UserName = "username",
                                                                       Password = "password",
                                                                       ConfirmPassword = "password"
                                                                   });
            validationResult.IsValid.Should()
                            .BeTrue();
        }

        [TestMethod]
        public void ShouldNotHaveValidationErrorWhenUsernameIsSupplied()
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.UserName, "username");
        }

        [TestMethod]
        public void ShouldHaveValidationErrorWhenNoUsernameIsSupplied()
        {
            validator.ShouldHaveValidationErrorFor(x => x.UserName, (string)null);
        }

        [TestMethod]
        public void ShouldNotHaveValidationErrorWhenValidPasswordIsSupplied()
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.Password, "password");
        }

        [TestMethod]
        public void ShouldHaveValidationErrorWhenNoPasswordIsSupplied()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Password, (string)null);
        }

        [TestMethod]
        public void ShouldHaveValidationErrorWhenTooShortPasswordIsSupplied()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Password, "short");
        }

        [TestMethod]
        public void ShouldHaveValidationErrorWhenTooLongPasswordIsSupplied()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Password, new string('x', 101));
        }

        [TestMethod]
        public void ShouldNotHaveValidationErrorWhenPasswordAndConfirmPasswordMatches()
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword,
                new RegisterModel
                {
                    Password = "password",
                    ConfirmPassword = "password"
                });
        }

        [TestMethod]
        public void ShouldHaveValidationErrorWhenPasswordAndConfirmPasswordDoesNotMatch()
        {
            validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword,
                new RegisterModel
                {
                    Password = "password1",
                    ConfirmPassword = "password2"
                });
        }
    }
}
