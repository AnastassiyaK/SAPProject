using NUnit.Framework;
using SAPBusiness.DataParsers.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using System;
using Autofac;
using TNavigator = SAPBusiness.WEB.PageObjects.TutorialNavigator.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.Footer;
using SAPBusiness.UserData;
using SAPTests.Browsers;
using SAPBusiness.WEB.PageObjects.LogOn;
using Core.Configuration;
using System.Threading;
using NLog;

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

            BaseDriver.Navigate(AppConfiguration.AppSetting["Pages:TutorialNavigator"]);

            try
            {
                Scope.Resolve<ICookiesFrame>().WaitForPageLoad().AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Logger.Error($"Cookies were not accepted! {e.Message}");
                //Assert.Warn(e.Message);//implement custom exception
            }

        }

        [Test, TestCaseSource(typeof(FilterDataParser), nameof(FilterDataParser.ExperienceTagsData))]
        [Order(1)]
        public void CheckExperienceFilterTags(string tag)
        {
            Scope.Resolve<IFilterSection>().SelectTagByTitle(tag);

            var tiles = Scope.Resolve<ITutorialNavigator>().WaitForFilterLoad().GetAllTiles();

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
            Scope.Resolve<IPageHeader>().WaitForPageLoad().OpenLogonFrame();

            logonStrategy.LogOn(new UserPool().GetUser());

            var tiles = Scope.Resolve<ITutorialNavigator>().WaitForPageLoad().GetAllTiles();

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
            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>().WaitForPageLoad()
                .FilterPageByTopic("Java")
                .WaitForFilterLoad();
                //.FilterPageByType(TileType.Tutorial)
                //.WaitForFilterLoad();

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
            var footer = Scope.Resolve<IPageFooter>().WaitForPageLoad();

            var pageLink = footer.GetSocialNetwork(type).Link;

            footer.OpenSocialNetWorkPage(type);

            Logger.Info($"Network link is {pageLink}, current tab has link {BaseDriver.Url}");
            Assert.AreEqual(pageLink, BaseDriver.Url);
        }

        public static NetworkType[] networks =
            new NetworkType[] { NetworkType.Facebook, NetworkType.Twitter, NetworkType.Youtube };
    }
}
