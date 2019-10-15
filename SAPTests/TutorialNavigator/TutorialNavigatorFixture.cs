using Autofac;
using Microsoft.Extensions.Configuration;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using SAPBusiness.Services.API_Services.TutorialNavigator;
using SAPBusiness.TilesData;
using SAPBusiness.UserData;
using SAPBusiness.WEB.Exceptions;
using SAPBusiness.WEB.PageObjects;
using SAPBusiness.WEB.PageObjects.Footer.Networks;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.LogOn;
using SAPBusiness.WEB.PageObjects.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.Search;
using SAPTests.Browsers;
using SAPTests.TestData.TutorialNavigator;
using SAPTests.TestData.TutorialNavigator.Models;
using SAPTests.TestData.TutorialNavigator.Modules;
using SAPTests.TestsAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SAPTests.TutorialNavigator
{
    [TestFixtureSource(typeof(BrowserList), "Browsers")]
    [Category("TutorialNavigatorFixture")]
    [Parallelizable(ParallelScope.All)]
    public class TutorialNavigatorFixture : BaseTest
    {
        private TutorialNavigatorConfiguration tutorialNavigatorConfig;

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

        [OneTimeSetUp]
        public void SetUpTutorialNavigatorConfig()
        {
            var configuration = Scope.Resolve<IConfigurationBuilder>()
              .AddJsonFile(@"TestData\TutorialNavigator\TutorialNavigatorConfiguration.json")
              .Build();

            tutorialNavigatorConfig = Scope.Resolve<TutorialNavigatorConfiguration>();

            configuration.GetSection("TutorialNavigator").Bind(tutorialNavigatorConfig);
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
        [Priority(2)]
        [Order(1)]
        public void CheckExperienceFilterTags(Experience experience)
        {
            Scope.Resolve<IFacetExperience>().SelectExperience(experience);

            var tutorualNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();

            var tiles = tutorualNavigator.GetAllTiles();

            Logger.Info($"--- { experience.ToString()}---");
            foreach (var tile in tiles)
            {
                Logger.Info($"Tile tag was {tile.Experience}");

                Assert.That(tile.Experience, Is.EqualTo(experience));
            }
        }

        [Test(Description = "Check if all Tiles have book marks")]
        [Priority(2)]
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

            Assert.That(legend.Tutorial == tutorialNavigator.GetAllTiles().Count);

            Assert.AreEqual(legend.Group, 0);

            Assert.AreEqual(legend.Mission, 0);
        }

        [Test(Description = "Check if correct tabs in browser are opened with social networks pages")]
        [Priority(1)]
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

        [Test, TestCaseSource(typeof(QueryParameters), nameof(QueryParameters.TilesQueries))]
        [Description("Check tutorial, group and mission where there is a license tag on tutorial navigator page")]
        [Priority(2)]
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
                        Assert.That(found.HasLicenseKey(), Is.True, $"{found.Title} does not have license key");
                    }
                }
                else
                {
                    Logger.Info($"{tile.Title} was not found on th tutorial navigator page");
                }
            }
        }

        [Test, TestCaseSource(typeof(QueryParameters), nameof(QueryParameters.TilesQueries))]
        [Description("Check tutorial, group and mission if time is correct on tutorial navigator page")]
        [Priority(3)]
        [Order(6)]
        public void CheckTileTime(TilesQuery query)
        {
            var timeConverter = Scope.Resolve<ITimeConverter>();
            var tiles = Scope.Resolve<ITilesService>().GetTiles(query).Tiles;

            foreach (var tile in tiles)
            {
                var tutorials = Scope.Resolve<ITutorialNavigator>().WaitForLoading().GetAllTiles();
                var found = tutorials.SingleOrDefault(t => t.Title == tile.Title);

                if (found != null)
                {
                    var tileTime = timeConverter.GetTime(tile.Time);
                    Logger.Info($"Tile with title \"{found.Title}\" has time \"{found.Time}\" on the page, \"{tileTime}\" from API Query");
                    Assert.That(found.Time, Is.EqualTo(tileTime),
                        $"{found.Title} has wrong time. Should have {tileTime}");
                }
                else
                {
                    Logger.Info($"{tile.Title} was not found on the tutorial navigator page");
                }
            }

            if (tiles.Count == 0)
            {
                Assert.Fail("There are no tiles on the page");
            }
        }

        [Test]
        [TestCaseSource("tiles")]
        [Description("Check correct pages division in Tutorial Navigator")]
        [Priority(2)]
        [Order(7)]
        public void CheckPagesNumberInPaginationSection(int tilesAmmount)
        {
            CheckTutorialNavigatorPagination(tilesAmmount);

            int tutorials = Scope.Resolve<ITilesService>().GetTutorialsAmount(QueryParameters.TilesQuery);
            var paginationSection = Scope.Resolve<IPaginationSection>();
            int totalPages = paginationSection.GetTotalNumberOfPages();
            int expectedPages = CalculateAmount(tutorials, tilesAmmount);

            Logger.Info($"Tutorial navigator has {totalPages} pages with tiles. Should have {expectedPages}");

            Assert.That(totalPages, Is.EqualTo(expectedPages),
                $"Tutorial navigator has {totalPages} pages with tiles. Should have {expectedPages}");
        }

        [Test]
        [TestCaseSource("tiles")]
        [Description("Click on a link to go to a page in currenly expanded area")]
        [Priority(2)]
        [Order(8)]
        public void ClickOnAnyPageInExpandedRange(int tilesAmmount)
        {
            CheckTutorialNavigatorPagination(tilesAmmount);

            var paginationSection = Scope.Resolve<IPaginationSection>();
            Logger.Info($"{tilesAmmount} tiles on each page");

            OpenRandomPage(1, paginationSection.GetTotalNumberOfPages(), paginationSection);

            var currentPage = paginationSection.CurrentPage.Number;

            int tutorials = Scope.Resolve<ITilesService>().GetTutorialsAmount(QueryParameters.TilesQuery);

            var expectedPagePagination = GetExpectedPagination(tilesAmmount, tutorials, currentPage);

            var currentPagination = paginationSection.GetCurrentPagination();

            Logger.Info($"Checking tutorial with {tilesAmmount} tiles on each page. Current page is {currentPage}");

            CheckPaginationEquality(expectedPagePagination, currentPagination);

        }

        [Test]
        [TestCaseSource("tiles")]
        [Description("Check pagination for user")]
        [Priority(1)]
        [Order(9)]
        public void CheckPaginationSection(int tilesAmmount)
        {
            CheckTutorialNavigatorPagination(tilesAmmount);

            var paginationSection = Scope.Resolve<IPaginationSection>();

            Assert.That(paginationSection.GetNumberOfPagesInExpandedArea(),
                Is.LessThanOrEqualTo(tutorialNavigatorConfig.PagesInMainPagination),
                "Expanded area has wrong amount of pages");

            int totalPages = paginationSection.GetTotalNumberOfPages();

            OpenRandomPage(1, totalPages, paginationSection);

            int tutorials = Scope.Resolve<ITilesService>().GetTutorialsAmount(QueryParameters.TilesQuery);

            var currentPage = paginationSection.CurrentPage.Number;

            var expectedPagePagination = GetExpectedPagination(tilesAmmount, tutorials, currentPage);

            var currentPagination = paginationSection.GetCurrentPagination();

            Logger.Info($"Checking tutorial navigator with {totalPages} pages and {tilesAmmount} tiles on each page");

            CheckPaginationEquality(expectedPagePagination, currentPagination);
        }

        [Test]
        [TestCaseSource("tiles")]
        [Description("Check if collapsed element works well")]
        [Priority(1)]
        [Order(10)]
        public void ClickOnCollapsedRange(int tilesAmmount)
        {
            CheckTutorialNavigatorPagination(tilesAmmount);

            var paginationSection = Scope.Resolve<IPaginationSection>();

            paginationSection.WaitForLoading();

            Logger.Info($"Checking tutorial navigator with {tilesAmmount} tiles on each page");
            try
            {
                var collapsedRange = paginationSection.GetFirstCollapsedRange();
                Logger.Info($"Expanding range '{collapsedRange.Link}'");

                var startPage = collapsedRange.StartValue;
                collapsedRange.Click();

                Logger.Info($"{paginationSection.CurrentPage.Number} is an active page");
                Assert.That(paginationSection.CurrentPage.Number, Is.EqualTo(startPage),
                    $"Number of current page should be {startPage}");

                int tutorials = Scope.Resolve<ITilesService>().GetTutorialsAmount(QueryParameters.TilesQuery);
                
                var currentPage = paginationSection.CurrentPage.Number;

                var expectedPagePagination = GetExpectedPagination(tilesAmmount, tutorials, currentPage);

                var currentPagination = paginationSection.GetCurrentPagination();

                CheckPaginationEquality(expectedPagePagination, currentPagination);
            }
            catch (CollapsedRangeNotFoundException ex)
            {
                Logger.Info($"{ex.Message}");
            }
        }

        [Test]
        [TestCaseSource("tiles")]
        [Description("Click on current page")]
        [Priority(4)]
        [Order(11)]
        public void CheckCurrentPage(int tilesAmmount)
        {
            CheckTutorialNavigatorPagination(tilesAmmount);

            var paginationSection = Scope.Resolve<IPaginationSection>();

            var currentPage = paginationSection.CurrentPage;

            bool IsClickable = CheckPageNotClickable(paginationSection, currentPage);

            Assert.IsFalse(IsClickable, "Current page is clickable");
        }

        [Test]
        [TestCaseSource("tiles")]
        [Description("Perform some filtering and check pagination")]
        [Priority(2)]
        [Order(12)]
        public void CheckPaginationAfterFiltering(int tilesAmmount)
        {
            CheckTutorialNavigatorPagination(tilesAmmount);

            Logger.Info($"Tutorial navigator with {tilesAmmount} tiles on each page");

            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>();

            var filterExperience = FilterQuery.Experience;

            Logger.Info($"Performing experience filter {filterExperience}");

            Scope.Resolve<IFacetExperience>().SelectExperience(filterExperience);

            var paginationSection = Scope.Resolve<IPaginationSection>();

            var query = QueryParameters.AddExperienceFilter(filterExperience);

            int tutorials = Scope.Resolve<ITilesService>().GetTutorialsAmount(query);

            Logger.Info($"Checking tutorial navigator with filter, total amount of tutorials should be {tutorials}");

            var currentPage = paginationSection.CurrentPage.Number;

            var expectedPagePagination = GetExpectedPagination(tilesAmmount, tutorials, currentPage);

            if (tutorialNavigator.HasPagination())
            {
                var currentPagination = paginationSection.GetCurrentPagination();

                CheckPaginationEquality(expectedPagePagination, currentPagination);
            }

            else
            {
                Assert.That(string.IsNullOrEmpty(expectedPagePagination),
                    $"The page does not have pagination section. But should have {expectedPagePagination}");
            }
        }

        private bool CheckPageNotClickable(IPaginationSection paginationSection, PageLink Page)
        {
            paginationSection.OpenPage(Page.Number);
            try
            {
                var value = Page.Number;
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }

        private void CheckPaginationEquality(string expectedPagePagination, string currentPagination)
        {
            Logger.Info($"Cheking page pagination {currentPagination}");
            Assert.That(currentPagination, Is.EqualTo(expectedPagePagination), "Page pagination doesn't coincide");
        }

        private string GetExpectedPagination(int tilesOnPage, int totalTutorials, int currentPage)
        {
            PagePagination pagePagination = new PagePagination();

            int pages = CalculateAmount(totalTutorials, tilesOnPage);
            if (pages > tutorialNavigatorConfig.PagesInMainPagination)
            {
                int paginationSections = CalculateAmount(pages, tutorialNavigatorConfig.PagesInMainPagination);

                int expanded = tutorialNavigatorConfig.ExpandedAreas;

                int collapsed = paginationSections - expanded;

                if (collapsed != 0)
                {
                    int value = tutorialNavigatorConfig.PagesInMainPagination;
                    List<CollapsedPagination> expectedSplits = new List<CollapsedPagination>();

                    for (int page = 1; page <= pages; page += value)
                    {
                        CollapsedPagination collapsedPagination = new CollapsedPagination
                        {
                            Start = page,
                            End = page + value - 1
                        };

                        if (collapsedPagination.End > pages)
                        {
                            collapsedPagination.End = pages;
                        }
                        expectedSplits.Add(collapsedPagination);
                    }

                    if (currentPage <= tutorialNavigatorConfig.PagesInMainPagination)
                    {
                        for (int page = 1; page <= value; page++)
                        {
                            pagePagination.Expanded += $"{page} ";
                        }

                        var found = expectedSplits.Find(c => c.Start == 1);
                        expectedSplits.Remove(found);
                    }

                    else
                    {
                        foreach (var item in expectedSplits)
                        {
                            if (currentPage <= item.End && currentPage >= item.Start)
                            {
                                for (int j = item.Start; j <= item.End; j++)
                                {
                                    pagePagination.Expanded += $"{j} ";
                                }

                                var found = expectedSplits.Find(c => c.Start == item.Start);
                                expectedSplits.Remove(found);
                                break;
                            }
                        }
                    }

                    pagePagination.Collapsed = expectedSplits;

                    return pagePagination.ToString();
                }
            }

            if (pages == 0)
            {
                return "";
            }
            else
            {
                for (int page = 1; page <= pages; page++)
                {
                    pagePagination.Expanded += $"{page} ";
                }
                Logger.Info($"Page doesn't have collapsed elements.");
                return pagePagination.ToString();              
            }
        }

        private void OpenRandomPage(int start, int end, IPaginationSection paginationSection)
        {
            Random randomizer = new Random();
            int number = randomizer.Next(start, end);

            Logger.Info($"Trying to open page with number {number}");

            paginationSection.OpenPage(number);
            paginationSection.WaitForLoading();
        }

        private void DeleteOpenPage(IPaginationSection paginationSection)
        {
            paginationSection.OpenPage(13);
            paginationSection.WaitForLoading();
        }

        private void CheckTutorialNavigatorPagination(int tilesAmmount)
        {
            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>();
            tutorialNavigator.OpenWithTilesOnPage(tilesAmmount);
            tutorialNavigator.WaitForLoading();
            Assert.
                That(tutorialNavigator.HasPagination(),
                Is.True,
                $"There is no pagination on tutorial navigator page with set tile ammount in {tilesAmmount}");
        }

        private int CalculateAmount(int divisible, int devider)
        {
            //var result = (double)divisible / devider;
            if (divisible < devider)
            {
                return 0;
            }
            else
            {
                var count = Math.Ceiling((double)divisible / devider);
                return (int)count;
            }
        }

        public static NetworkType[] networks =
         new NetworkType[] { NetworkType.Facebook, NetworkType.Twitter, NetworkType.Github };

        public static int[] tiles =
        new int[] { 4, 34, 58, 118, 500 };
    }
}
