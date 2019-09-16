using Autofac;
using NLog;
using NUnit.Framework;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects;
using SAPBusiness.WEB.PageObjects.Footer.Networks;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.LogOn;
using SAPBusiness.WEB.PageObjects.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using SAPTests.Browsers;
using SAPTests.TestData.TutorialNavigator.Modules;
using System;
using System.Threading;

namespace SAPTests.TutorialNavigator
{
    [TestFixtureSource(typeof(BrowserList), "Browsers")]
    [Parallelizable(ParallelScope.All)]
    public class TutorialNavigatorFixture : BaseTest
    {
        private readonly ThreadLocal<Logger> _log = new ThreadLocal<Logger>();

        ILogOnStrategy logonStrategy;

        private Logger Logger
        {
            get => _log.Value;
            set => _log.Value = value;
        }

        public TutorialNavigatorFixture(Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            Logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");

            logonStrategy = Scope.Resolve<LogOnFrame>();

            Scope.Resolve<ITutorialNavigator>().Open();

            try
            {
                PageExtension.WaitForLoading(Scope.Resolve<ICookiesFrame>()).AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Logger.Error($"Cookies were not accepted! {e.Message}");
                //Assert.Warn(e.Message);//implement custom exception
            }
        }

        [Test, TestCaseSource(typeof(FilterData), nameof(FilterData.ExperienceTags))]
        [Order(1)]
        public void CheckExperienceFilterTags(string tag)
        {
            Scope.Resolve<IFacetExperience>().SelectExperience(tag);

            var tutorualNavigator = Scope.Resolve<ITutorialNavigator>();

            var tiles = PageExtension.WaitForLoading(tutorualNavigator).GetAllTiles();

            Logger.Info($"--- { tag.ToUpper()}---");
            foreach (var tile in tiles)
            {
                Logger.Info($"Tile tag was {tile.ExperienceTag}");

                Assert.IsTrue(tile.ExperienceTag == tag);
            }
        }

        [Test(Description = "Check if all Tiles have book marks")]
        [Order(2)]
        public void CheckTileBookmarks()
        {
            var pageHeader = Scope.Resolve<IPageHeader>();
            PageExtension.WaitForLoading(pageHeader).OpenLogonFrame();

            logonStrategy.LogOn(UserPool.GetUser());

            var tutorialNavigator = PageExtension.WaitForLoading(Scope.Resolve<ITutorialNavigator>());

            var tiles = tutorialNavigator.GetAllTiles();

            CollectionAssert.IsNotEmpty(tiles);

            foreach (var tile in tiles)
            {
                Logger.Info($"{tile.Title} {((tile.BookMarkDisplayed()) ? "has" : "does NOT have")} a bookmark");

                Assert.IsTrue(tile.BookMarkDisplayed());
            }
        }

        [Test(Description = "Check tiles by filter #java #tutorial. And check the Tile Legend")]
        [Order(3)]
        public void GetJavaTutorialsOnly()
        {
            var facetTopic = Scope.Resolve<IFacetTopic>();
            PageExtension.WaitForLoading(facetTopic).SelectTopic("Java");

            var facetType = Scope.Resolve<IFacetType>();
            PageExtension.WaitForLoading(facetType).SelectType("Tutorial");

            var tutorialNavigator = PageExtension.WaitForLoading(Scope.Resolve<ITutorialNavigator>());

            var legend = Scope.Resolve<ITileLegend>();

            Assert.AreEqual(legend.Tutorial, tutorialNavigator.GetAllTiles().Count);

            Assert.AreEqual(legend.Group, 0);

            Assert.AreEqual(legend.Mission, 0);
        }

        [Test(Description = "Check if correct tabs in browser are opened with social networks pages")]
        [Order(4)]
        [TestCaseSource("networks")]
        public void CheckSocialNetworkLinks(NetworkType type)
        {
            var networkSection = PageExtension.WaitForLoading(Scope.Resolve<ISocialNetworkSection>());

            var pageLink = networkSection.GetNetworkLink(type);

            networkSection.OpenNetwork(type);

            Logger.Info($"Network link is {pageLink}, current tab has link {BaseDriver.Url}");
            Assert.AreEqual(pageLink, BaseDriver.Url);
        }

        public static NetworkType[] networks =
            new NetworkType[] { NetworkType.Facebook, NetworkType.Twitter, NetworkType.Youtube };
    }
}
