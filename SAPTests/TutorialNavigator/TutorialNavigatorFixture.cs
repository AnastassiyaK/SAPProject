namespace SAPTests.TutorialNavigator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using FluentAssertions;
    using global::Autofac;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using SAPBusiness.Enums;
    using SAPBusiness.Services.API_Services.TutorialNavigator;
    using SAPBusiness.TilesData;
    using SAPBusiness.UserData;
    using SAPBusiness.WEB.Exceptions;
    using SAPBusiness.WEB.PageObjects;
    using SAPBusiness.WEB.PageObjects.Developers.Footer.Networks;
    using SAPBusiness.WEB.PageObjects.Developers.Frames;
    using SAPBusiness.WEB.PageObjects.Developers.Header;
    using SAPBusiness.WEB.PageObjects.LogOn;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Mission;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Search;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;
    using SAPBusiness.WEB.TutorialNavigator;
    using SAPTests.Browsers;
    using SAPTests.Models;
    using SAPTests.TestData.TutorialNavigator;
    using SAPTests.TestData.TutorialNavigator.Models;
    using SAPTests.TestData.TutorialNavigator.Modules;
    using SAPTests.TestsAttributes;

    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.DefaultModeBrowsers))]
    [Category("TutorialNavigatorFixture")]
    [Parallelizable(ParallelScope.All)]
    public class TutorialNavigatorFixture : BaseTest
    {
        public static NetworkType[] networks =
         new NetworkType[] { NetworkType.Facebook, NetworkType.Twitter, NetworkType.Github };

        public static int[] tiles =
        new int[] { 4, 34, 58, 118, 500 };

        private static TutorialNavigatorConfiguration tutorialNavigatorConfig;

        private ILogOnStrategy logonStrategy;

        public TutorialNavigatorFixture(Browser browser)
            : base(browser)
        {
            var json = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\TutorialNavigatorConfiguration.json");
            tutorialNavigatorConfig = JsonConvert.DeserializeObject<TutorialNavigatorConfiguration>(json);
        }

        public void TestSetUp()
        {
            logonStrategy = Scope.Resolve<LogOnFrame>();

            Scope.Resolve<ITutorialNavigator>().Open();

            try
            {
                Scope.Resolve<ICookiesFrame>().WaitForLoading().AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Logger.Error($"Cookies were not accepted! {e.Message}");
            }
        }

        [Test]
        [TestCaseSource(typeof(FilterData), nameof(FilterData.ExperienceTags))]
        [Priority(2)]
        [Order(1)]
        public void CheckExperienceFilterTags(Experience experience)
        {
            Scope.Resolve<IFacetExperience>().SelectExperience(experience);

            var tutorualNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();

            var tiles = tutorualNavigator.GetAllTilesCache();

            Logger.Info($"--- {experience.ToString()}---");
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

            var tiles = tutorialNavigator.GetAllTilesCache();

            CollectionAssert.IsNotEmpty(tiles);

            foreach (var tile in tiles)
            {
                Logger.Info($"{tile.Title} {(tile.BookMarkDisplayed() ? "has" : "does NOT have")} a bookmark");

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
            facetType.SelectTag("Tutorial");

            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();

            var legend = Scope.Resolve<ITileLegend>();

            Assert.That(legend.Tutorial == tutorialNavigator.GetAllTilesCache().Count);

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

        [Test]
        [TestCaseSource(typeof(TilesQueries), nameof(TilesQueries.Queries))]
        [Description("Check tutorial, group and mission where there is a license tag on tutorial navigator page")]
        [Priority(2)]
        [Order(5)]
        public void CheckLicenseTagInTile(ResultSingleTile query)
        {
            var tiles = Scope.Resolve<ITilesService>().GetTiles(query);

            foreach (var tile in tiles)
            {
                Scope.Resolve<ISearchSection>().WaitForLoading().Search(tile.Title);

                var tutorials = Scope.Resolve<ITutorialNavigator>().WaitForLoading().GetAllTilesCache();

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

        [Test]
        [TestCaseSource(typeof(TilesQueries), nameof(TilesQueries.Queries))]
        [Description("Check tutorial, group and mission if time is correct on tutorial navigator page")]
        [Priority(3)]
        [Order(6)]
        public void CheckTileTime(ResultSingleTile query)
        {
            var timeConverter = Scope.Resolve<ITimeConverter>();
            var tiles = Scope.Resolve<ITilesService>().GetTiles(query);

            foreach (var tile in tiles)
            {
                var tutorials = Scope.Resolve<ITutorialNavigator>().WaitForLoading().GetAllTilesCache();
                var found = tutorials.SingleOrDefault(t => t.Title == tile.Title);

                if (found != null)
                {
                    var tileTime = timeConverter.GetTime(tile.Time);
                    Logger.Info($"Tile with title \"{found.Title}\" has time \"{found.Time}\" on the page, \"{tileTime}\" from API Query");
                    Assert.That(
                        found.Time,
                        Is.EqualTo(tileTime),
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

            int tutorials = Scope.Resolve<ITilesService>().GetAllTutorialTypesAmount(TilesQueries.Query);
            var paginationSection = Scope.Resolve<IPaginationSection>();
            int totalPages = paginationSection.GetTotalNumberOfPages();
            int expectedPages = CalculateAmount(tutorials, tilesAmmount);

            Logger.Info($"Tutorial navigator has {totalPages} pages with tiles. Should have {expectedPages}");

            Assert.That(
                totalPages,
                Is.EqualTo(expectedPages),
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

            int tutorials = Scope.Resolve<ITilesService>().GetAllTutorialTypesAmount(TilesQueries.Query);

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

            Assert.That(
                paginationSection.GetNumberOfPagesInExpandedArea(),
                Is.LessThanOrEqualTo(tutorialNavigatorConfig.PagesInMainPagination),
                "Expanded area has wrong amount of pages");

            int totalPages = paginationSection.GetTotalNumberOfPages();

            OpenRandomPage(1, totalPages, paginationSection);

            int tutorials = Scope.Resolve<ITilesService>().GetAllTutorialTypesAmount(TilesQueries.Query);

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
                Assert.That(paginationSection.CurrentPage.Number, Is.EqualTo(startPage), $"Number of current page should be {startPage}");

                int tutorials = Scope.Resolve<ITilesService>().GetAllTutorialTypesAmount(TilesQueries.Query);

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

            bool isClickable = CheckPageClickable(paginationSection, currentPage);

            Assert.IsFalse(isClickable, "Current page is clickable");
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

            var query = TilesQueries.AddExperienceFilter(filterExperience);

            int tutorials = Scope.Resolve<ITilesService>().GetAllTutorialTypesAmount(query);

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
                Assert.That(
                    string.IsNullOrEmpty(expectedPagePagination), $"The page does not have pagination section. But should have {expectedPagePagination}");
            }
        }

        [Test]
        [Description("All tiles on the page should be sorted by title and in corresponding order: Mission, Group, Tutorial")]
        [Priority(4)]
        [Order(13)]
        public void CheckTilesSort()
        {
            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>();

            var pagination = Scope.Resolve<IPaginationSection>();

            int totalPages = pagination.GetTotalNumberOfPages();

            List<ShortTile> tilesToCompare = new List<ShortTile>();

            for (int i = 1; i <= totalPages; i++)
            {
                pagination.OpenPage(i);
                var tiles = tutorialNavigator.GetAllTiles();
                tilesToCompare.AddRange(tiles.Select(t => new ShortTile(t.Type, t.Title)).ToList());
            }

            var expected = new List<ShortTile>(tilesToCompare);

            TilesTypeComparer comparer = new TilesTypeComparer();

            expected.Sort(comparer);

            tilesToCompare.Should().ContainInOrder(expected);
        }

        [Test]
        [Description("All tiles that was created before the certain date should have NEW label")]
        [Priority(3)]
        [Order(14)]
        public void CheckTilesNewLabel()
        {
            var newTiles = Scope.Resolve<ITilesService>().GetNewTiles(TilesQueries.Query);

            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>().WaitForLoading();
            var searchSection = Scope.Resolve<ISearchSection>();

            // foreach (var tile in newTiles)
            // {
            //    searchSection.Search(tile.Title);

            // var tileOnPage = tutorialNavigator
            //    .GetAllTiles()
            //    .Where(t => t.Id == tile.Id)
            //    .FirstOrDefault();
            //    tileOnPage.HasNewLabel().Should().BeTrue($"Tile with title\"{ tileOnPage.Title}\" should have label NEW");
            // }
            tutorialNavigator.OpenWithTilesOnPage(TilesQueries.Query.EndIndex);
            tutorialNavigator.WaitForLoading();

            var newTilesOnPage = newTiles.Join(
                tutorialNavigator.GetAllTiles(),
                newTile => newTile.Id,
                pageTile => pageTile.Id,
                (newTile, pageTile) => pageTile)
                .ToList();

            foreach (var tile in newTilesOnPage)
            {
                tile.HasNewLabel().Should().BeTrue($"Tile with title\"{tile.Title}\" should have label NEW");
            }
        }

        [Test]
        [Description("Add bookmark on each tile type and check if exists in side menu")]
        [Priority(3)]
        [Order(15)]
        public void CheckBookmarkInEachTileType([Values]TutorialType type)
        {
            var tutorialNavigator = GetFilteredTutorialNavigatorByTileType(type);
            var tile = GetRandomTile(tutorialNavigator.GetAllTiles());
            tile.AddBookmark();

            var tileLink = tile.Link;
            var tileTitle = tile.Title;

            CompareBookmarks(tileLink, tileTitle);
        }

        [Test]
        [Description("")]
        [Priority(3)]
        [Order(16)]
        public void CheckBookmarkOnTutorialPage()
        {
            var tutorialNavigator = GetFilteredTutorialNavigatorByTileType(TutorialType.Tutorial);
            var tile = GetRandomTile(tutorialNavigator.GetAllTiles());

            var tileLink = tile.Link;
            var tileTitle = tile.Title;
            tile.Open();

            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.WaitForLoading();

            tutorial.AddBookmark();

            CompareBookmarks(tileLink, tileTitle);
        }

        [Test]
        [Description("")]
        [Priority(3)]
        [Order(17)]
        public void CheckBookmarkOnMissionPage()
        {
            var tutorialNavigator = GetFilteredTutorialNavigatorByTileType(TutorialType.Mission);
            var tile = GetRandomTile(tutorialNavigator.GetAllTiles());

            var tileLink = tile.Link;
            var tileTitle = MenuLinksProcessor.GetMissionTitle(tile.Title);
            tile.Open();

            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.WaitForLoading();

            tutorial.AddBookmark();

            CompareBookmarks(tileLink, tileTitle);
        }

        [Test]
        [Description("")]
        [Priority(3)]
        [Order(18)]
        public void CheckBookmarkOnGroupPage()
        {
            var tutorialNavigator = GetFilteredTutorialNavigatorByTileType(TutorialType.Group);
            var tile = GetRandomTile(tutorialNavigator.GetAllTiles());

            var tileLink = tile.Link;
            var tileTitle = MenuLinksProcessor.GetGroupTitle(tile.Title);
            tile.Open();

            var mission = Scope.Resolve<IMission>();
            mission.WaitForLoading();

            mission.AddBookmark();

            CompareBookmarks(tileLink, tileTitle);
        }

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            TestSetUp();
        }

        private ITutorialNavigator GetFilteredTutorialNavigatorByTileType(TutorialType type)
        {
            LogIn();
            var facet = Scope.Resolve<FacetType>();
            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>();
            tutorialNavigator.WaitForLoading();
            tutorialNavigator = GetFilteredTutorialNavigator(tutorialNavigator, facet, type.ToString());
            return tutorialNavigator;
        }

        private void CompareBookmarks(string link, string title)
        {
            var sideMenu = Scope.Resolve<ISideBreadCrumbMenu>();
            sideMenu.OpenBookmarkTab();

            var bookmarks = sideMenu.Bookmarks;

            var found = bookmarks.Where(b => b.Title == title).FirstOrDefault();

            if (found != null)
            {
                found.Link.Should().BeEquivalentTo(link);
            }
            else
            {
                Assert.Fail($"Link with title'{title}' does not exist.");
            }
        }

        private void LogIn()
        {
            logonStrategy = Scope.Resolve<LogOnFrame>();

            var user = UserPool.GetUser();
            logonStrategy.LogOn(user);

            Logger.Info($"User {user.Login} is logged in.");
        }

        private ITileElement GetRandomTile(List<TileElement> tiles)
        {
            var random = new Random();
            int index = random.Next(tiles.Count);
            return tiles[index];
        }

        private ITutorialNavigator GetFilteredTutorialNavigator(ITutorialNavigator tutorialNavigator, BaseFacet facet, string tag)
        {
            var filterSection = Scope.Resolve<IFilterSection>();
            filterSection.ClearAll();
            filterSection.WaitForLoad();

            Logger.Info($"Performing search by {tag} tag");
            facet.SelectTag(tag);
            tutorialNavigator.WaitForLoad();
            return tutorialNavigator;
        }

        private bool CheckPageClickable(IPaginationSection paginationSection, PageLink page)
        {
            paginationSection.OpenPage(page.Number);
            try
            {
                var value = page.Number;
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

        private void CheckTutorialNavigatorPagination(int tilesAmmount)
        {
            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>();
            tutorialNavigator.OpenWithTilesOnPage(tilesAmmount);
            tutorialNavigator.WaitForLoading();
            Assert.That(
                tutorialNavigator.HasPagination(),
                Is.True,
                $"There is no pagination on tutorial navigator page with set tile ammount in {tilesAmmount}");
        }

        private int CalculateAmount(int divisible, int devider)
        {
            // var result = (double)divisible / devider;
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
    }
}
