using Autofac;
using NUnit.Framework;
using SAPTests.Autofac;
using System.Threading;
using Core.WebDriver;
using Core.DriverFactory;

namespace SAPTests
{
    public class BaseTest /*: IDisposable*/
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
        public BaseTest(Browser browser)
        {
            _browser = browser;
        }
        protected BaseWebDriver BaseDriver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        private void RegisterBrowser(ContainerBuilder builder)
        {
            //if (_browser == Browser.Chrome)
            //{
            //    builder.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
            //}                
            //if (_browser == Browser.Firefox)
            //{
            //    builder.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
            //}               
            //if (_browser == Browser.IE)
            //{
            //    builder.RegisterType<IEDriverFactory>().As<IDriverFactory>();
            //} 
            if (_browser == Browser.Chrome)
            {
                builder.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
            }
            if (_browser == Browser.Firefox)
            {
                builder.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
            }
            if (_browser == Browser.IE)
            {
                builder.RegisterType<IEDriverFactory>().As<IDriverFactory>();
            }

        }

        [SetUp]
        public void Setup()
        {
            var builder = ContainerConfig.Configure();

            RegisterBrowser(builder);

            Container = builder.Build();

            Scope = Container.BeginLifetimeScope();            

            BaseDriver = Scope.Resolve<BaseWebDriver>();

            BaseDriver.InitDriver();

        }
        [TearDown]
        public void Teardown()
        {
            BaseDriver.Quit();

            Scope.Dispose();

        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
