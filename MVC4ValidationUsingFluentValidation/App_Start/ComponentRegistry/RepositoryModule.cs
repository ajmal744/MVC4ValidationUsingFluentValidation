using Autofac;
using MVC4ValidationUsingFluentValidation.Models;

namespace MVC4ValidationUsingFluentValidation.App_Start.ComponentRegistry
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new UserProfileRepository(new UsersContext()))
                   .As<IUserProfileRepository>();
        }
    }
}