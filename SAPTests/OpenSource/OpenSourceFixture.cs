namespace SAPTests.OpenSource
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using global::Autofac;
    using NUnit.Framework;
    using SAPBusiness.Enums;
    using SAPBusiness.WEB.PageObjects;
    using SAPBusiness.WEB.PageObjects.Developers.Frames;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Memberships;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects.Search;
    using SAPTests.Browsers;
    using SAPTests.TestsAttributes;

    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.DefaultModeBrowsers))]
    [Category("OpenSourceFixture")]
    [Parallelizable(ParallelScope.All)]
    public class OpenSourceFixture : BaseTest
    {
        public OpenSourceFixture(Browser browser)
            : base(browser)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
            Scope.Resolve<IOpenSource>().Open();

            try
            {
                PageExtension.WaitForLoading(Scope.Resolve<ICookiesFrame>()).AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Logger.Error($"Cookies were not accepted! {e.Message}");
            }
        }

        [Test(Description = "Pull a random word from projects and put into search. Check search works")]
        [Priority(6)]
        [Order(1)]
        public void CheckProjectSearchByRandomString()
        {
            var projectSection = Scope.Resolve<IProjectsSection>();

            var projects = PageExtension.WaitForLoading(projectSection).GetAllProjects();

            var descriptions = projects.Select(project => (project.Description + " " + project.Title + " ")).ToList();

            Logger.Info("Projects were recieved successfully");

            Random randomizer = new Random();

            string description = string.Join("", descriptions);
            var words = description.Split(' ');
            int index = randomizer.Next(words.Length);

            string randomWord = words[index];

            Logger.Info($"A word to search : --- {randomWord} ---");

            Scope.Resolve<ISearchSection>().SearchResultsByString(randomWord);

            projectSection = Scope.Resolve<IProjectsSection>();

            projects = PageExtension.WaitForLoading(projectSection).GetAllProjects();

            foreach (var project in projects)
            {
                Logger.Info($"Project --- {project.Title} --- on the page with description: --- {project.Description} ---");
                Assert.That(project.Description.Contains(randomWord) || project.Title.Contains(randomWord));
            }
        }

        [Test(Description = "Check all projects have the same background images as main images")]
        [Priority(6)]
        [Order(2)]
        public void CheckProjectBackgroundImage()
        {
            var projectSection = Scope.Resolve<IProjectsSection>();

            var projects = PageExtension.WaitForLoading(projectSection).GetAllProjects();

            Logger.Info("Projects were recieved successfully");

            foreach (var project in projects)
            {
                Logger.Info($"Project image was {project.Image}," + "\n" + $"Project background image was {project.BackgroundImage}");
                Assert.That(project.Image, Is.EqualTo(project.BackgroundImage));
            }
        }

        [Test(Description = "Check blog post are sorted by date (Desc)")]
        [Priority(5)]
        [Order(3)]
        public void CheckBlogPostSortByDate()
        {
            var feedSortItem = Scope.Resolve<IFeedSortItem>();

            feedSortItem.WaitForLoading().SelectFeedType(FeedType.Latest);

            var feeds = Scope.Resolve<IBlogPostSection>().GetAllFeeds();

            List<DateTime> dateBlog = feeds.Select(feed => DateTime.Parse(feed.Date)).ToList();

            var orderedList = dateBlog.OrderByDescending(date => date).ToList();

            Logger.Info("Ordered items in test");

            LogListofItems(orderedList);

            Logger.Info("Items on the page");
            LogListofItems(dateBlog);

            dateBlog.Should().ContainInOrder(orderedList);

            Logger.Info("Items were sorted correctly");
        }

        [Test(Description = "Check all memberships have title and description")]
        [Priority(6)]
        [Order(4)]
        public void CheckMembershipsTitleDescription()
        {
            var membershipSection = Scope.Resolve<IMembershipSection>();

            Assert.IsTrue(PageExtension.WaitForLoading(membershipSection).HasMemberships());

            var memberships = membershipSection.GetAllMemberships();
            foreach (var membership in memberships)
            {
                Logger.Info($"Membership title ---{membership.Title}---");

                Assert.That(membership.Title, !Is.EqualTo(""));

                Logger.Info($"Membership description ---{membership.Description}---");

                Assert.IsTrue(membership.Description != "");
            }
        }

        [Test(Description = "Check all memberships have title and description using page object logging")]
        [Order(5)]
        public void CheckMembershipsTitleDescriptionWithLogger()
        {
            // Assert.IsTrue(Scope.Resolve<MembershipLogger>().HasMemberships());
            // var memberships = Scope.Resolve<MembershipLogger>().GetAllMemberships();

            // foreach (var membership in memberships)
            // {
            //    Logger.Info($"Membership title ---{membership.Title}---");

            // Assert.IsTrue(membership.Title != "");

            // Logger.Info($"Membership description ---{membership.Description}---");

            // Assert.IsTrue(membership.Description != "");
            // }
        }

        private void LogListofItems<T>(List<T> list)
        {
            var resulString = "";
            foreach (var item in list)
            {
                resulString += $"{item} |";
            }

            Logger.Info(resulString);
        }
    }
}
