namespace SAPTests.MainPage
{
    using System.Collections.Generic;
    using global::Autofac;
    using NUnit.Framework;
    using SAPBusiness.WEB.PageObjects.Developers.Header;
    using SAPBusiness.WEB.PageObjects.Developers.MainPage;
    using SAPTests.Browsers;

    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.MobileModeBrowsers))]
    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.DefaultModeBrowsers))]
    [Category("TutorialNavigatorFixture")]
    [Parallelizable(ParallelScope.All)]
    public class MainPageFixture : BaseTest
    {
        private static readonly List<string> _expectedHeaderLinks = new List<string>
        {
                "Products",
                "Get Started Tutorials",
                "Resources",
                "Trials and Downloads",
                "App Space"
        };

        public MainPageFixture(Browser browser)
            : base(browser)
        {
        }

        [Test]
        public void CheckHeaderLinks()
        {
            OpenMainPage();

            var headerLinks = Scope.Resolve<IPageHeader>().GetMenuLinks();

            CollectionAssert.AreEquivalent(headerLinks, _expectedHeaderLinks);
        }

        [SetUp]
        protected void TestSetUp()
        {
            if (_browser == Browser.ChromeMobile)
            {
                Scope = SetUpGlobal.Container.BeginLifetimeScope(container =>
                {
                    container.RegisterType<MobilePageHeader>().As<IPageHeader>();
                });
            }

            // base.SetUp();
        }

        private void OpenMainPage()
        {
            var mainPage = Scope.Resolve<IMainPage>();
            mainPage.Open();
            mainPage.WaitForLoad();
        }
    }
}
