using Autofac;
using NLog;
using NUnit.Framework;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData;
using SAPBusiness.UserData.History;
using SAPBusiness.WEB.PageObjects;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.LogOn;
using SAPBusiness.WEB.PageObjects.MainPage;
using SAPBusiness.WEB.PageObjects.MainPage.Statistics;
using SAPTests.Browsers;
using SAPTests.TestData.User.Modules;
using SAPTests.TestsAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SAPTests.UserServices
{
    [TestFixtureSource(typeof(BrowserList), "Browsers")]
    [Category("UserServiceFixture")]
    [Parallelizable(ParallelScope.All)]
    public class UserServiceFixture : BaseTest
    {
        private readonly ThreadLocal<Logger> _log = new ThreadLocal<Logger>();

        ILogOnStrategy logonStrategy;

        private Logger Logger
        {
            get => _log.Value;
            set => _log.Value = value;
        }

        public UserServiceFixture(Browser browser) : base(browser)
        {

        }

        [SetUp]
        public void SetUp()
        {
            Logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");

            logonStrategy = Scope.Resolve<LogOnFrame>();

            var mainPage = Scope.Resolve<IMainPage>();
            mainPage.Open();
            mainPage.WaitForLoading();

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

        [Test(Description = "Compare user progress using user's cookies and progress on the browser page")]
        [Priority(1)]
        [Order(1)]
        public void CompareUserProgress()
        {
            Scope.Resolve<IPageHeader>().WaitForLoading().OpenLogonFrame();

            logonStrategy.LogOn(UserPool.GetUser());

            var progress = Scope.Resolve<IUserService>().GetStatistics(BaseDriver.GetBrowserCookies()).UserProgress;

            var statistics = Scope.Resolve<ITutorialSection>().WaitForLoading();

            var groups = statistics.GetStatsByType(StatisticsType.Groups);
            var tutorials = statistics.GetStatsByType(StatisticsType.Tutorials);
            var missions = statistics.GetStatsByType(StatisticsType.Missions);

            Assert.Multiple(() =>
            {
                Logger.Info($"From User service {progress.GroupsTotal}, from the main page {groups.Total}");
                Assert.That(progress.GroupsTotal.Equals(groups.Total),
                    $"{progress.GroupsTotal} not equals to {groups.Total}");

                Logger.Info($"From User service {progress.GroupsCompleted}, from the main page {groups.Completed}");
                Assert.That(progress.GroupsCompleted.Equals(groups.Completed),
                   $"{progress.GroupsCompleted} not equals to { groups.Completed}");

                Logger.Info($"From User service {progress.MissionsTotal}, from the main page {missions.Total}");
                Assert.That(progress.MissionsTotal.Equals(missions.Total),
                   $"{progress.MissionsTotal} not equals to {missions.Total}");

                Logger.Info($"From User service {progress.MissionsCompleted}, from the main page {missions.Completed}");
                Assert.That(progress.MissionsCompleted.Equals(missions.Completed),
                   $"{progress.MissionsCompleted} not equals to {missions.Completed}");

                Logger.Info($"From User service {progress.TutorialTotal}, from the main page {tutorials.Total}");
                Assert.That(progress.TutorialTotal.Equals(tutorials.Total),
                   $"{progress.TutorialTotal} not equals to {tutorials.Total}");

                Logger.Info($"From User service {progress.TutorialCompleted}, from the main page {tutorials.Completed}");
                Assert.That(progress.TutorialCompleted.Equals(tutorials.Completed),
                   $"{progress.TutorialCompleted} not equals to {tutorials.Completed}");
            });
        }

        //[Test, TestCaseSource(typeof(UserHistoryData), nameof(UserHistoryData.UserHistory))]
        [Test]
        [Priority(0)]
        [Description("Compare user history from file and on the page")]
        [Order(2)]
        public void CompareUserHistory()
        {            
            logonStrategy.LogOn(UserPool.GetUser());

            var cookies = BaseDriver.GetBrowserCookies();

            var userService = Scope.Resolve<IUserService>();

            userService.DownloadHistory(cookies);

            var userFileHistory = UserHistoryData.UserHistory;

            var userHistory =userService.GetUserHistory(cookies);

            CollectionAssert.IsNotEmpty(userHistory);

            CollectionAssert.IsNotEmpty(userFileHistory);

            CompareHistories(userFileHistory, userHistory);
        }

        private void CompareHistories(IList<DeveloperHistory> userFileHistory, IList<DeveloperHistory> userHistory)
        {
            foreach (var row in userHistory)
            {
                var found = userFileHistory.SingleOrDefault(h => h.TaskTitle == row.TaskTitle);
                if (found != null)
                {
                    Logger.Info($"{found.TaskTitle} has type from API \"{row.TaskType}\", in the csv file \"{found.TaskType}\"");
                    Assert.That(row.TaskType, Is.EqualTo(found.TaskType));

                    Logger.Info($"{found.TaskTitle} has url from API \"{row.TaskUrl}\", in the csv file \"{found.TaskUrl}\"");
                    Assert.That(row.TaskUrl, Is.EqualTo(found.TaskUrl));

                    Logger.Info($"{found.TaskTitle} has date from API \"{row.CompletionDate}\", in the csv file \"{found.CompletionDate}\"");
                    Assert.That(row.CompletionDate, Is.EqualTo(found.CompletionDate));

                    Logger.Info($"{found.TaskTitle} has time from API \"{row.CompletionTime}\", in the csv file \"{found.CompletionTime}\"");
                    Assert.That(row.CompletionTime, Is.EqualTo(found.CompletionTime));
                }
                else
                {
                    Assert.Fail($"User does not have history row {row.TaskTitle} on the page");
                }
            }
        }
    }
}
