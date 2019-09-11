using Autofac;
using NUnit.Framework;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.MainPage.Statistics;
using SAPBusiness.WEB.PageObjects.LogOn;
using Core.Configuration;
using SAPTests.Browsers;
using SAPBusiness.Services.Interfaces.API_UserService;
using System;
using NLog;
using System.Threading;

namespace SAPTests.UserServices
{
    [TestFixtureSource(typeof(BrowserList), "Browsers")]
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

            BaseDriver.Navigate(AppConfiguration.AppSetting["Pages:HomePage"]);

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

        [Test(Description = "Compare user progress using user's cookies and progress on the browser page")]
        [Order(1)]
        public void CompareUserProgress()
        {
            Scope.Resolve<IPageHeader>().WaitForPageLoad().OpenLogonFrame();

            logonStrategy.LogOn(new UserPool().GetUser());

            var progress = Scope.Resolve<IUserService>().GetStatistics(BaseDriver.GetBrowserCookies()).UserProgress;

            var statistics = Scope.Resolve<ITutorialSection>().WaitForPageLoad();

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
    }
}
