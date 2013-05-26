using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using FluentValidation;
using MVC4ValidationUsingFluentValidation.Models;
using MVC4ValidationUsingFluentValidation.Models.Validators;

namespace MVC4ValidationUsingFluentValidation.App_Start.ComponentRegistry
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModelValidator>()
                   .Keyed<IValidator>(typeof(IValidator<RegisterModel>))
                   .As<IValidator>();
            builder.RegisterType<RegisterExternalLoginModelValidator>()
                   .Keyed<IValidator>(typeof(IValidator<RegisterExternalLoginModel>))
                   .As<IValidator>();
            builder.RegisterType<LoginModelValidator>()
                   .Keyed<IValidator>(typeof(IValidator<LoginModel>))
                   .As<IValidator>();
            builder.RegisterType<LocalPasswordModelValidator>()
                   .Keyed<IValidator>(typeof(IValidator<LocalPasswordModel>))
                   .As<IValidator>();
        }
    }
}