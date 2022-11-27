using Autofac;
using Autofac.Extensions.DependencyInjection;
using ToyRobot.Application.Services;

namespace ToyRobot.Console.DependencyInjection
{
    public static class AutofacModule
    {
        /// <summary>
        /// Initiates dependency injection and registers services
        /// </summary>
        /// <returns>Service Provider for access to registered services</returns>
        public static AutofacServiceProvider InitiateDependencyInjection()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyTypes(typeof(ICommandService).Assembly).AsImplementedInterfaces();

            var container = containerBuilder.Build();

            var serviceProvider = new AutofacServiceProvider(container);
            return serviceProvider;
        }
    }
}
