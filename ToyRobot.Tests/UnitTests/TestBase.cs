using Autofac.Extensions.DependencyInjection;
using ToyRobot.Console.DependencyInjection;

namespace ToyRobot.Tests.UnitTests
{
    public abstract class TestBase
    {
        protected AutofacServiceProvider Provider;

        [SetUp]
        public void Setup()
        {
            Provider = AutofacModule.InitiateDependencyInjection();
            ChildSetup();
        }
        protected abstract void ChildSetup();

        protected T Get<T>()
        {
            return (T) Provider.GetRequiredService(typeof(T));
        }
    }
}
