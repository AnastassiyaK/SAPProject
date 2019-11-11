namespace SAPTests
{
    using System.Collections;
    using System.Threading;
    using Core.DriverFactory;
    using Core.WebDriver;
    using global::Autofac;
    using NLog;
    using NUnit.Framework;

    public class BaseTest
    {
        protected Browser _browser;

        private readonly ThreadLocal<ILogger> _log = new ThreadLocal<ILogger>();

        private readonly ThreadLocal<WebDriver> _driver = new ThreadLocal<WebDriver>();

        private readonly ThreadLocal<ILifetimeScope> _scope = new ThreadLocal<ILifetimeScope>();

        public BaseTest(Browser browser)
        {
            _browser = browser;
        }

        protected ILogger Logger
        {
            get => _log.Value;
            set => _log.Value = value;
        }

        protected ILifetimeScope Scope
        {
            get => _scope.Value;
            set => _scope.Value = value;
        }

        protected WebDriver BaseDriver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        [SetUp]
        protected virtual void SetUp()
        {
            RegisterTypesForTests();

            InitDriver();
        }

        [TearDown]
        protected virtual void Teardown()
        {
            BaseDriver.Quit();

            Scope.Dispose();
        }

        protected virtual bool MobileSetup()
        {
            IList categories = (IList)TestContext.CurrentContext.Test.Properties["Category"];

            bool useMobileSetup = categories != null && categories.Contains("Mobile");
            return useMobileSetup;
        }

        private void RegisterTypesForTests()
        {
            Logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");

            Scope = SetUpGlobal.Container.BeginLifetimeScope(container =>
            {
                ApplyBrowserType(container);
                container.RegisterInstance(Logger).As<ILogger>().SingleInstance();
            });
        }

        private void ApplyBrowserType(ContainerBuilder container)
        {
            if (_browser == Browser.Chrome)
            {
                container.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
            }

            if (_browser == Browser.ChromeMobile)
            {
                container.RegisterType<ChromeMobileDriverFactory>().As<IDriverFactory>();
            }

            if (_browser == Browser.Firefox)
            {
                container.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
            }

            if (_browser == Browser.IE)
            {
                container.RegisterType<IEDriverFactory>().As<IDriverFactory>();
            }
        }

        private void InitDriver()
        {
            BaseDriver = Scope.Resolve<WebDriver>();

            BaseDriver.InitDriver();
        }
    }
}
