using Autofac;
using NUnit.Framework;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.MainPage.Statistics;
using System;
using SAPBusiness.WEB.PageObjects.LogOn;
using Core.Configuration;
using SAPTests.Browsers;
using SAPBusiness.Services.Interfaces.API_UserService;

namespace SAPTests.UserServices
{
    [TestFixtureSource(typeof(BrowserList), "Browsers")]
    public class UserServiceFixture : BaseTest
    {
        ILogOnStrategy logonStrategy;
        public UserServiceFixture(Browser browser) : base(browser)
        {

        }

        [SetUp]
        public void SetUp()
        {
            logonStrategy = Scope.Resolve<LogOnFrame>();

            BaseDriver.Navigate(AppConfiguration.AppSetting["Pages:HomePage"]);

            try
            {
                Scope.Resolve<CookiesFrame>().WaitForPageLoad().AgreeWithPrivacyPolicy();
            }
            catch (Exception e)
            {
                Assert.Warn(e.Message);//implement custom exception
            }

        }

        [Test(Description = "Compare user progress using user's cookies and progress on the browser page")]
        [Order(1)]
        public void CompareUserProgress()
        {
            Scope.Resolve<PageHeader>().WaitForPageLoad().OpenLogonFrame();

            logonStrategy.LogOn(Scope.Resolve<UserPool>().GetUser());

            var progress = Scope.Resolve<IUserService>().GetStatistics(BaseDriver.GetBrowserCookies()).UserProgress;

            var statistics = Scope.Resolve<TutorialSection>().WaitForPageLoad();

            var groups = statistics.GetStatsByType(StatisticsType.Groups);
            var tutorials = statistics.GetStatsByType(StatisticsType.Tutorials);
            var missions = statistics.GetStatsByType(StatisticsType.Missions);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(progress.GroupsTotal == groups.Total);
                Assert.IsTrue(progress.GroupsCompleted == groups.Completed);
                Assert.IsTrue(progress.MissionsTotal == missions.Total);
                Assert.IsTrue(progress.MissionsCompleted == missions.Completed);
                Assert.IsTrue(progress.TutorialTotal == tutorials.Total);
                Assert.IsTrue(progress.TutorialCompleted == tutorials.Completed);

            });

        }
    }
}
