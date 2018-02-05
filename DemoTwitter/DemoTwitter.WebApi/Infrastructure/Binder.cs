using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using DemoTwitter.Repositories;
using DemoTwitter.Repositories.Implementation;
using DemoTwitter.Services;
using DemoTwitter.Services.Implementation;

namespace DemoTwitter.WebApi.Infrastructure
{
    public static class Binder
    {
        public static ContainerBuilder Register()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<Logger>().As<ILog>();
            containerBuilder.RegisterType<ConfigReader>().As<IConfigReader>();
            containerBuilder.RegisterType<ConnectionProvider>().As<IConnectionProvider>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserProvider>().As<IUserProvider>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<Logger>().As<ILog>().InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}