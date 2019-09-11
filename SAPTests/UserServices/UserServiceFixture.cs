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

            //Scope.Resolve<ICookiesFrame>().WaitForPageLoad().AgreeWithPrivacyPolicy();

            //try
            //{
            //    Scope.Resolve<CookiesFrame>().WaitForPageLoad().AgreeWithPrivacyPolicy();
            //}
            //catch (Exception e)
            //{
            //    Assert.Warn(e.Message);//implement custom exception
            //}
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
                Assert.That(progress.GroupsTotal.Equals(groups.Total),
                    $"{progress.GroupsTotal} not equals to {groups.Total}");

                Assert.That(progress.GroupsCompleted.Equals(groups.Completed),
                   $"{progress.GroupsCompleted} not equals to { groups.Completed}");

                Assert.That(progress.MissionsTotal.Equals(missions.Total),
                   $"{progress.MissionsTotal} not equals to {groups.Total}");

                Assert.That(progress.MissionsCompleted.Equals(missions.Completed),
                   $"{progress.MissionsCompleted} not equals to {groups.Completed}");

                Assert.That(progress.TutorialTotal.Equals(tutorials.Total),
                   $"{progress.TutorialTotal} not equals to {groups.Total}");

                Assert.That(progress.TutorialCompleted.Equals(tutorials.Completed),
                   $"{progress.TutorialCompleted} not equals to {groups.Completed}");
            });
        }
    }
}
