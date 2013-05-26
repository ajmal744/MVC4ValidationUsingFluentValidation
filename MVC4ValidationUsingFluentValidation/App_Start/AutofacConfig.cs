using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using MVC4ValidationUsingFluentValidation.App_Start.ComponentRegistry;

namespace MVC4ValidationUsingFluentValidation
{
    public class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();

            // Register the modules
            builder.RegisterModule<ValidationModule>();

            // Create the container
            var container = builder.Build();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Set up the FluentValidation provider factory and add it as a Model validator
            var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(new AutofacValidatorFactory(container));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;
            ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
        }
    }
}