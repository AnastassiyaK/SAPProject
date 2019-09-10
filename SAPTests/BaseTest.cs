using Autofac;
using SAPTests.DriverFactory;
using SAPTests.Interfaces.WebDriver;
using SAPTests.WebDriver;
using NUnit.Framework;
using SAPTests.Autofac;
using System.Threading;

namespace SAPTests
{
    public class BaseTest
    {
        protected Browser _browser;

        private ThreadLocal<BaseWebDriver> _driver = new ThreadLocal<BaseWebDriver>();

        private ThreadLocal<ILifetimeScope> _scope = new ThreadLocal<ILifetimeScope>();
        protected ILifetimeScope Scope
        {
            get => _scope.Value;
            set => _scope.Value = value;
        }
        protected IContainer Container
        {
            get; private set;
        }
        public BaseTest(Browser browser)
        {
            _browser = browser;
        }
        protected BaseWebDriver BaseDriver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        [SetUp]
        public void Setup()
        {
            var builder = ContainerConfig.Configure();

            if (_browser == Browser.Chrome)
                builder.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
            if (_browser == Browser.Firefox)
                builder.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
            if (_browser == Browser.IE)
                builder.RegisterType<IEDriverFactory>().As<IDriverFactory>();

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
