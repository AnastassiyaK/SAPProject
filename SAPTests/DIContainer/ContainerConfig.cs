using Autofac;

namespace SAPTests.Autofac
{
    internal class ContainerConfig
    {
        public static ContainerBuilder Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AppModule>();
            return containerBuilder;
        }
    }
}
