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
using SAPBusiness.WEB.PageObjects.Logon;
using Core.Configuration;

namespace SAPTests.TutorialNavigator
{
    [TestFixtureSource(typeof(BrowserList), "browsers")]
    [Parallelizable(ParallelScope.All)]
    public class TutorialNavigatorFixture : BaseTest
    {
        ILogOnStrategy logonStrategy;
        public TutorialNavigatorFixture(Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            logonStrategy = Scope.Resolve<LogonFrame>();

            BaseDriver.Navigate(AppConfiguration.AppSetting["Pages:TutorialNavigator"]);

            try
            {
                Scope.Resolve<CookiesFrame>().WaitForPageLoad().AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Assert.Warn(e.Message);//implement custom exception
            }

        }
        [Test, TestCaseSource(typeof(FilterDataParser), nameof(FilterDataParser.ExperienceTagsData))]
        [Order(1)]
        public void CheckExperienceFilterTags(string tag)
        {
            Scope.Resolve<FilterSection>().SelectTagByTitleImproved(tag);

            var tiles = Scope.Resolve<TNavigator>().WaitForFilterLoad().GetAllTiles();

            foreach (var tile in tiles)
            {
                Assert.IsTrue(tile.ExperienceTag == tag);
            }
        }

        [Test(Description = "Check if all Tiles have book marks")]
        [Order(2)]
        public void CheckTileBookmarks()
        {
            Scope.Resolve<PageHeader>().WaitForPageLoad().OpenLogonFrame();

            logonStrategy.LogOn(Scope.Resolve<UserPool>().GetUser());

            var tiles = Scope.Resolve<TNavigator>().WaitForPageLoad().GetAllTiles();

            CollectionAssert.IsNotEmpty(tiles);

            foreach (var tile in tiles)
            {
                Assert.IsTrue(tile.BookMarkDisplayed());
            }
        }

        [Test(Description = "Check tiles by filter #java #tutorial. And check the Tile Legend")]
        [Order(3)]
        public void GetJavaTutorialsOnly()
        {
            var tutorialNavigator = Scope.Resolve<TNavigator>().WaitForPageLoad()
                .FilterPageByTopic("Java")
                .WaitForFilterLoad()
                .FilterPageByType(TileType.Tutorial)
                .WaitForFilterLoad();

            var legend = Scope.Resolve<TileLegend>();

            Assert.AreEqual(legend.Tutorial, tutorialNavigator.GetAllTiles().Count);

            Assert.AreEqual(legend.Group, 0);

            Assert.AreEqual(legend.Mission, 0);
        }

        [Test(Description = "Check if correct tabs in browser are opened with social networks pages")]
        [Order(4)]
        [TestCaseSource("networks")]
        public void CheckSocialNetworkLinks(NetworkType type)
        {
            var footer = Scope.Resolve<PageFooter>().WaitForPageLoad();

            var pageLink = footer.GetSocialNetwork(type).Link;

            footer.OpenSocialNetWorkPage(type);

            Assert.AreEqual(pageLink, BaseDriver.Url);
        }

        public static NetworkType[] networks =
            new NetworkType[] { NetworkType.Facebook, NetworkType.Twitter, NetworkType.Youtube };
    }
}
