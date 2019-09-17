using Autofac;
using Core.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SAPBusiness.Configuration;
using SAPTests.Autofac;
using System.Threading;

namespace SAPTests
{
    [SetUpFixture]
    public static class SetUpGlobal
    {
        private static readonly ThreadLocal<ILifetimeScope> _scope = new ThreadLocal<ILifetimeScope>();

        public static ILifetimeScope Scope
        {
            get => _scope.Value;
            set => _scope.Value = value;
        }

        public static IContainer Container { get; private set; }

        [OneTimeSetUp]
        public static void GlobalSetup()
        {
            var builder = ContainerConfig.Configure();

            Container = builder.Build();

            Scope = Container.BeginLifetimeScope();

            var configuration = Scope.Resolve<IConfigurationBuilder>()
              .AddJsonFile(@"Configuration\appSettingsWebDriver.json")
              .AddJsonFile(@"Configuration\appSettingsSAPBusiness.json")
              .Build();

            var driverConfiguration = Scope.Resolve<IDriverConfiguration>();

            configuration.GetSection("WebDriver").Bind(driverConfiguration);

            var environmentConfig = Scope.Resolve<IEnvironmentConfig>();

            configuration.GetSection("Links").Bind(environmentConfig);

        }

        [OneTimeTearDown]
        public static void GlobalTeardown()
        {
            Scope.Dispose();
            Container.Dispose();
        }
    }
}
