using Autofac;
using NLog;
using NUnit.Framework;
using SAPBusiness.Services.API_Services.TutorialNavigator;
using SAPBusiness.TilesData;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects;
using SAPBusiness.WEB.PageObjects.Footer.Networks;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.LogOn;
using SAPBusiness.WEB.PageObjects.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.Search;
using SAPTests.Browsers;
using SAPTests.TestData.TutorialNavigator.Modules;
using System;
using System.Linq;
using System.Threading;

namespace SAPTests.TutorialNavigator
{
    [TestFixtureSource(typeof(BrowserList), "Browsers")]
    [Category("TutorialNavigatorFixture")]
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
                Scope.Resolve<ICookiesFrame>().WaitForLoading().AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Logger.Error($"Cookies were not accepted! {e.Message}");
                //Assert.Warn(e.Message);//implement custom exception
            }
        }

        [Test, TestCaseSource(typeof(FilterData), nameof(FilterData.ExperienceTags))]
        [Property("Severity", 2)]
        [Order(1)]
        public void CheckExperienceFilterTags(string tag)
        {
            Scope.Resolve<IFacetExperience>().SelectExperience(tag);

            var tutorualNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();

            var tiles = tutorualNavigator.GetAllTiles();

            Logger.Info($"--- { tag.ToUpper()}---");
            foreach (var tile in tiles)
            {
                Logger.Info($"Tile tag was {tile.Experience}");

                Assert.That(tile.Experience,Is.EqualTo(tag));
            }
        }

        [Test(Description = "Check if all Tiles have book marks")]
        [Property("Severity", 1)]
        [Order(2)]
        public void CheckTileBookmarks()
        {
            var pageHeader = Scope.Resolve<IPageHeader>().WaitForLoading();
            pageHeader.OpenLogonFrame();

            logonStrategy.LogOn(UserPool.GetUser());

            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();

            var tiles = tutorialNavigator.GetAllTiles();

            CollectionAssert.IsNotEmpty(tiles);

            foreach (var tile in tiles)
            {
                Logger.Info($"{tile.Title} {((tile.BookMarkDisplayed()) ? "has" : "does NOT have")} a bookmark");

                Assert.That(tile.BookMarkDisplayed(), Is.True);
            }
        }

        [Test(Description = "Check tiles by filter #java #tutorial. And check the Tile Legend")]
        [Order(3)]
        public void GetJavaTutorialsOnly()
        {
            var facetTopic = Scope.Resolve<IFacetTopic>().WaitForLoading();
            facetTopic.SelectTopic("Java");

            var facetType = Scope.Resolve<IFacetType>().WaitForLoading();
            facetType.SelectType("Tutorial");

            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();

            var legend = Scope.Resolve<ITileLegend>();

            Assert.That(legend.Tutorial==tutorialNavigator.GetAllTiles().Count);

            Assert.AreEqual(legend.Group, 0);

            Assert.AreEqual(legend.Mission, 0);
        }

        [Test(Description = "Check if correct tabs in browser are opened with social networks pages")]
        [Property("Severity",1)]
        [Order(4)]
        [TestCaseSource("networks")]
        public void CheckSocialNetworkLinks(NetworkType type)
        {
            var networkSection = Scope.Resolve<ISocialNetworkSection>().WaitForLoading();

            var pageLink = networkSection.GetNetworkLink(type);

            networkSection.OpenNetwork(type);

            Logger.Info($"Network link is {pageLink}, current tab has link {BaseDriver.Url}");
            Assert.AreEqual(pageLink, BaseDriver.Url);
        }

        [Test, TestCaseSource(typeof(QueryParameters), nameof(QueryParameters.TilesQuery))]
        [Description("Check tutorial, group and mission where there is a license tag on tutorial navigator page")]
        [Property("Severity", 1)]
        [Order(5)]
        public void CheckLicenseTagInTile(TilesQuery query)
        {
            var tiles = Scope.Resolve<ITilesService>().GetTiles(query).Tiles;

            foreach (var tile in tiles)
            {
                Scope.Resolve<ISearchSection>().WaitForLoading().Search(tile.Title);

                var tutorials = Scope.Resolve<ITutorialNavigator>().WaitForLoading().GetAllTiles();

                var found = tutorials.SingleOrDefault(t => t.Title == tile.Title);

                if (found != null)
                {
                    if (tile.HasLicenseTag)
                    {
                        Logger.Info($"{tile.Title} has license key: {found.HasLicenseKey()}");
                        Assert.That(found.HasLicenseKey(),Is.True, $"{found.Title} does not have license key");
                    }
                }
                else
                {
                    Logger.Info($"{tile.Title} was not found on th tutorial navigator page");
                }
            }
        }
        public static NetworkType[] networks =
         new NetworkType[] { NetworkType.Facebook, NetworkType.Twitter, NetworkType.Github };
    }
}
