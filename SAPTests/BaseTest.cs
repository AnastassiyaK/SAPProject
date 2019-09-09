using Autofac;
using Core.DriverFactory;
using Core.Interfaces.WebDriver;
using Core.WebDriver;
using NUnit.Framework;
using SAPTests.Autofac;
using System.Threading;

namespace SAPTests
{
    public class BaseWebTest
    {
        protected Browser _browser;

        private readonly ThreadLocal<BaseWebDriver> _driver = new ThreadLocal<BaseWebDriver>();

        private readonly ThreadLocal<ILifetimeScope> _scope = new ThreadLocal<ILifetimeScope>();

        protected ILifetimeScope Scope
        {
            get => _scope.Value;
            set => _scope.Value = value;
        }
        protected IContainer Container
        {
            get; private set;
        }
        public BaseWebTest(Browser browser)
        {
            _browser = browser;
        }
        protected BaseWebDriver BaseDriver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        private void ResolveBrowser(ContainerBuilder builed)
        {
            if (_browser == Browser.Chrome)
            {
                builed.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
            }
            if (_browser == Browser.Firefox)
            {
                builed.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
            }
            if (_browser == Browser.IE)
            {
                builed.RegisterType<IEDriverFactory>().As<IDriverFactory>();
            }
        }

        [SetUp]
        public void Setup()
        {
            var builder = ContainerConfig.Configure();
            ResolveBrowser(builder);

            Container = builder.Build();

            Scope = Container.BeginLifetimeScope();

            BaseDriver = Scope.Resolve<BaseWebDriver>();

            BaseDriver.InitRemoteDriver();
        }

        [TearDown]
        public void Teardown()
        {
            BaseDriver.Quit();

            Scope.Dispose();

        }
    }
}
