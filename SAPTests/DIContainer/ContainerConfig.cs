namespace SAPTests.Autofac
{
    using global::Autofac;
    using SpecFlow.Autofac;

    public class ContainerConfig
    {
        [ScenarioDependencies]
        public static ContainerBuilder Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AppModule>();
            return containerBuilder;
        }
    }
}
