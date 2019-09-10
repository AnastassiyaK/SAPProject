using Autofac;
using SAPTests.Configuration;
using NLog;
using NUnit.Framework;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;
using SAPBusiness.WEB.PageObjects.OpenSource.Memberships;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search;
using SAPTests.Browsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SAPTests.OpenSource
{
    [TestFixtureSource(typeof(BrowserType), "browsers")]
    [Parallelizable(ParallelScope.All)]
    public class OpenSourceFixture : BaseTest
    {
        private readonly ThreadLocal<Logger> _log = new ThreadLocal<Logger>();
        private Logger Logger
        {
            get => _log.Value;
            set => _log.Value = value;
        }
        public OpenSourceFixture(Browser browser) : base(browser)
        {

        }

        [SetUp]
        public void SetUp()
        {

            Logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.MethodName}");

            BaseDriver.Navigate(AppConfiguration.AppSetting["Pages:OpenSource"]);

            try
            {
                Scope.Resolve<CookiesFrame>().WaitForPageLoad().AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Logger.Error($"Cookies were not accepted! {e.Message}");
                Assert.Warn(e.Message);//implement custom exception
            }

        }
        [TearDown]
        public void Teardown1()
        {

        }

        [Test(Description = "Pull a random word from projects and put into search. Check search works")]
        [Order(1)]
        public void CheckProjectSearchByRandomString()
        {
            var projects = Scope.Resolve<ProjectsSection>().WaitForPageLoad().GetAllProjects();

            var descriptions = projects.Select(project => (project.Description + " " + project.Title + " ")).ToList();

            Logger.Info("Projects were recieved successfully");

            Random randomizer = new Random();

            string description = String.Join("", descriptions);
            var words = description.Split(' ');
            int index = randomizer.Next(words.Length);

            string randomWord = words[index];

            Logger.Info($"A word to search : --- {randomWord} ---");

            Scope.Resolve<SearchSection>().SearchResultsByString(randomWord);

            projects = Scope.Resolve<ProjectsSection>().WaitForPageLoad().GetAllProjects();

            foreach (var project in projects)
            {
                Logger.Info($"Project --- {project.Title} --- on the page with description: --- {project.Description} ---");
                Assert.IsTrue(project.Description.Contains(randomWord) || project.Title.Contains(randomWord));
            }

        }


        [Test(Description = "Check all projects have the same background images as main images")]
        [Order(2)]
        public void CheckProjectBackgroundImage()
        {
            var projects = Scope.Resolve<ProjectsSection>().WaitForPageLoad().GetAllProjects();

            Logger.Debug("Projects were recieved successfully");

            foreach (var project in projects)
            {
                Logger.Debug($"Project image was {project.Image}," + "\n" + $"Project background image was {project.BackgroundImage}");
                Assert.IsTrue(project.Image == project.BackgroundImage);
            }
        }

        [Test(Description = "Check blog post are sorted by date (Desc)")]
        [Order(3)]
        public void CheckBlogPostSortByDate()
        {
            Scope.Resolve<FeedSortItem>().WaitForPageLoad().SelectFeedType(FeedType.Latest);

            var feeds = Scope.Resolve<BlogPostSection>().GetAllFeeds();

            List<DateTime> dateBlog = feeds.Select(feed => DateTime.Parse(feed.Date)).ToList();

            var orderedList = dateBlog.OrderByDescending(date => date).ToList();

            Logger.Debug("Ordered items in test");
            orderedList.ForEach(item => Logger.Info($"---{item}---"));

            Logger.Debug("Items on the page");
            dateBlog.ForEach(item => Logger.Info($"---{item}---"));

            CollectionAssert.AreEqual(dateBlog, orderedList);

            Logger.Debug("Items were sorted correctly");
        }

        [Test(Description = "Check all memberships have title and description")]
        [Order(4)]
        public void CheckMembershipsTitleDescription()
        {
            var membershipSection = Scope.Resolve<MembershipSection>().WaitForPageLoad();

            Assert.IsTrue(membershipSection.HasMemberships());

            var memberships = membershipSection.GetAllMemberships();
            foreach (var membership in memberships)
            {
                Logger.Info($"Membership title ---{membership.Title}---");

                Assert.IsTrue(membership.Title != "");

                Logger.Info($"Membership description ---{membership.Description}---");

                Assert.IsTrue(membership.Description != "");
            }

        }

        [Test(Description = "Check all memberships have title and description using page object logging")]
        [Order(5)]
        public void CheckMembershipsTitleDescriptionWithLogger()
        {
            //Assert.IsTrue(Scope.Resolve<MembershipLogger>().HasMemberships());
            //var memberships = Scope.Resolve<MembershipLogger>().GetAllMemberships();

            //foreach (var membership in memberships)
            //{
            //    Logger.Info($"Membership title ---{membership.Title}---");

            //    Assert.IsTrue(membership.Title != "");

            //    Logger.Info($"Membership description ---{membership.Description}---");

            //    Assert.IsTrue(membership.Description != "");
            //}

        }
    }
}
