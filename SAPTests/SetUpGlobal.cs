namespace SAPTests
{
    using Core.Configuration;
    using global::Autofac;
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;
    using SAPBusiness.Configuration;
    using SAPTests.Autofac;

    [SetUpFixture]
    public static class SetUpGlobal
    {
        private static ILifetimeScope scope;

        public static IContainer Container { get; private set; }

        [OneTimeSetUp]
        public static void GlobalSetup()
        {
            var builder = ContainerConfig.Configure();

            Container = builder.Build();

            scope = Container.BeginLifetimeScope();

            var configuration = scope.Resolve<IConfigurationBuilder>()
              .AddJsonFile(@"Configuration\appSettingsWebDriver.json")
              .AddJsonFile(@"Configuration\appSettingsSAPBusiness.json")
              .AddJsonFile(@"Configuration\ChromeConfiguration.json")
              .Build();

            var driverConfiguration = scope.Resolve<DriverConfiguration>();

            configuration.GetSection("WebDriver").Bind(driverConfiguration);

            var environmentConfig = scope.Resolve<EnvironmentConfig>();

            configuration.GetSection("Links").Bind(environmentConfig);
        }

        [OneTimeTearDown]
        public static void GlobalTeardown()
        {
            scope.Dispose();
            Container.Dispose();
        }
    }
}
