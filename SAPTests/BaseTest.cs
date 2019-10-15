using Autofac;
using Core.DriverFactory;
using Core.WebDriver;
using NUnit.Framework;
using System.Threading;

namespace SAPTests
{
    public class BaseTest /*: IDisposable*/
    {
        protected Browser _browser;

        private readonly ThreadLocal<WebDriver> _driver = new ThreadLocal<WebDriver>();

        private readonly ThreadLocal<ILifetimeScope> _scope = new ThreadLocal<ILifetimeScope>();

        protected ILifetimeScope Scope
        {
            get => _scope.Value;
            set => _scope.Value = value;
        }

        public BaseTest(Browser browser)
        {
            _browser = browser;
        }

        protected WebDriver BaseDriver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        private void RegisterBrowser()
        {
            Scope = SetUpGlobal.Container.BeginLifetimeScope(container =>
            {
                if (_browser == Browser.Chrome)
                {
                    container.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
                }
                if (_browser == Browser.Firefox)
                {
                    container.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
                }
                if (_browser == Browser.IE)
                {
                    container.RegisterType<IEDriverFactory>().As<IDriverFactory>();
                }
            });
        }

        [OneTimeSetUp]
        public void SetUpScope()
        {
            Scope = SetUpGlobal.Container.BeginLifetimeScope();
        }

        [SetUp]
        public void Setup()
        {
            RegisterBrowser();

            BaseDriver = Scope.Resolve<WebDriver>();

            BaseDriver.InitDriver();
        }

        [TearDown]
        public void Teardown()
        {
            BaseDriver.Quit();

            Scope.Dispose();
        }
    }
}
