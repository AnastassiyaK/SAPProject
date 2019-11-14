namespace SAPTests.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Autofac;
    using NUnit.Framework;
    using SAPBusiness.Enums;
    using SAPBusiness.UserData;
    using SAPBusiness.WEB.Exceptions;
    using SAPBusiness.WEB.PageObjects.Developers.Frames;
    using SAPBusiness.WEB.PageObjects.Developers.MainPage;
    using SAPBusiness.WEB.PageObjects.LogOn;
    using SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
    using SAPTests.Browsers;
    using SAPTests.TestsAttributes;

    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.DefaultModeBrowsers))]
    [Category("BookmarksFixture")]
    [Parallelizable(ParallelScope.All)]
    public class BookmarksFixture : BaseTest
    {
        private ILogOnStrategy logonStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookmarksFixture"/> class.
        /// </summary>
        /// <param name="browser">The parameter is used for passing browser's name.</param>
        public BookmarksFixture(Browser browser)
            : base(browser)
        {
        }

        /// <summary>
        /// Sets context for aech test in BookmarksFixture.
        /// </summary>
        [SetUp]
        public void TestSetUp()
        {
            var mainPage = Scope.Resolve<IMainPage>();
            mainPage.Open();
            mainPage.WaitForLoad();

            logonStrategy = Scope.Resolve<LogOnFrame>();

            var user = UserPool.GetUser();
            logonStrategy.LogOn(user);

            Logger.Info($"User {user.Login} is logged in.");

            var bookmarksPage = Scope.Resolve<IBookmarkPage>();
            bookmarksPage.Open();
            bookmarksPage.WaitForLoad();
        }

        /// <summary>
        /// Checks if added bookmarks on Tutorial Navigator page appear on http:\\people.sap.com.
        /// </summary>
        [Test]
        [Priority(6)]
        public void CheckBookmarks()
        {
            var bookmarksPage = Scope.Resolve<IBookmarkPage>();

            Logger.Info("Deleting all user's bookmarks");
            bookmarksPage.DeleteBookmarks();

            var titles = GetTitlesOfTilesWithBookmarks();

            bookmarksPage.Open();
            bookmarksPage.WaitForLoad();

            var searchSection = Scope.Resolve<ISearchSection>();

            foreach (var title in titles)
            {
                Logger.Info($"Searching for bookmark with title {title}");
                searchSection.Search(title);
                try
                {
                    var bookmark = bookmarksPage.GetBookmark(title);
                    Logger.Info($"Book mark with title ' {bookmark.Title} ' exists.");
                }
                catch (BookmarkNotFoundException e)
                {
                    Logger.Info(e.Message);

                    Assert.Fail(e.Message);
                }
            }
        }

        /// <summary>
        /// Adds certain amount of bookmarks to the tiles on Tutorial Navigator page.
        /// </summary>
        /// <param name="bookmarks">The parameter defines how many bookmarks to add.</param>
        /// <returns>Returns list of each type of tiles that was bookmarked.</returns>
        private List<string> GetTitlesOfTilesWithBookmarks()
        {
            var facet = Scope.Resolve<FacetType>();

            var tutorialNavigator = Scope.Resolve<ITutorialNavigator>();
            tutorialNavigator.Open();
            tutorialNavigator.WaitForLoad();

            var tileTypes = Enum.GetNames(typeof(TutorialType));

            var resultTiles = new List<string>();

            foreach (var type in tileTypes)
            {
                Logger.Info($"Searching for any tile with {type} type");
                tutorialNavigator = GetFilteredTutorialNavigator(tutorialNavigator, facet, type);

                var tile = GetBookmarkedTile(tutorialNavigator);
                resultTiles.Add(tile.Title);
            }

            return resultTiles;
        }

        private ITileElement GetBookmarkedTile(ITutorialNavigator tutorialNavigator)
        {
            tutorialNavigator.WaitForLoad();
            var tiles = tutorialNavigator.GetAllTiles();

            var tile = tiles.FirstOrDefault();
            Logger.Info($"Making a bookmark on tile with name {tile.Title}");
            tile.AddBookmark();
            return tile;
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
    }
}
