namespace SAPTests.Tutorial
{
    using System.Linq;
    using System.Threading;
    using global::Autofac;
    using NLog;
    using NUnit.Framework;
    using SAPBusiness.Services.API_Services.Tutorial;
    using SAPBusiness.TutorialData;
    using SAPBusiness.UserData;
    using SAPBusiness.WEB.PageObjects;
    using SAPBusiness.WEB.PageObjects.Developers.Frames;
    using SAPBusiness.WEB.PageObjects.Developers.Header;
    using SAPBusiness.WEB.PageObjects.LogOn;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Mission;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;
    using SAPTests.Browsers;
    using SAPTests.TestData.TutorialNavigator.Modules;
    using SAPTests.TestsAttributes;

    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.DefaultModeBrowsers))]
    [Category("TutorialFixture")]
    [Parallelizable(ParallelScope.All)]
    public class TutorialFixture : BaseTest
    {
        private readonly ThreadLocal<ILogOnStrategy> _logonStrategy = new ThreadLocal<ILogOnStrategy>();

        public TutorialFixture(Browser browser)
            : base(browser)
        {
        }

        private ILogOnStrategy LogonStrategy
        {
            get => _logonStrategy.Value;
            set => _logonStrategy.Value = value;
        }

        [SetUp]
        public void TestSetUp()
        {
            LogonStrategy = Scope.Resolve<LogOnFrame>();
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.TutorialLinks))]
        [Priority(1)]
        [Description("Check tutorial where there is a license tag")]
        [Order(1)]
        public void CheckTutorialLicenseTag(string partialLink)
        {
            Scope.Resolve<ITutorial>().Open(partialLink);
            CheckLicenseTag();
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.MissionLinks))]
        [Description("Check mission where there is a license tag")]
        [Order(2)]
        public void CheckMissionLicenseTag(string partialLink)
        {
            Scope.Resolve<IMission>().Open(partialLink);
            CheckLicenseTag();
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.MissionLinks))]
        [Description("Check if popup has correct text")]
        [Order(3)]
        public void CheckPopUpLicenseTag(string partialLink)
        {
            Scope.Resolve<IMission>().Open(partialLink);
            var summarySection = Scope.Resolve<ISummarySection>().WaitForLoading();

            string licenseKeyText = "Requires Customer/Partner License";
            Assert.That(summarySection.GetLicensePopupText() == licenseKeyText, $"{summarySection.Title} does not have license key");
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.TutorialLinks))]
        [Description("Check if mini navigator has the same link as breadcrumb")]
        [Order(4)]
        public void CheckLinkInMiniNavigator(string partialLink)
        {
            Scope.Resolve<ITutorial>().Open(partialLink);
            var breadCrumbLink = Scope.Resolve<IBreadCrumb>().RootLink;
            var miniNavigatorLinks = Scope.Resolve<IMiniNavigator>().GetLinks();

            var miniNavigatorLink = miniNavigatorLinks.SingleOrDefault(item => item.Value == breadCrumbLink);
            Assert.That(miniNavigatorLink.Value == breadCrumbLink, $"Expected:{breadCrumbLink}, was:{miniNavigatorLink}");
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.TutorialLinks))]
        [Description("Check if mini navigator has the same link as next step")]
        [Order(5)]
        public void CheckLinkInNextStep(string partialLink)
        {
            Scope.Resolve<ITutorial>().Open(partialLink);
            var nextStep = Scope.Resolve<INextStepSection>().GetFirstNextStep().Link;
            var nextStepMiniNavigator = Scope.Resolve<IMiniNavigator>().NextStepLink;

            Assert.That(nextStep == nextStepMiniNavigator, $"Expected:{nextStep}, was:{nextStepMiniNavigator}");
        }

        [Test]
        [TestCaseSource(typeof(TutorialData), nameof(TutorialData.TutorialQueries))]
        [Description("Check if next step displays the same info as from geting service")]
        [Order(6)]
        public void CheckAttributesOfNextStep(TutorialQuery tutorialQuery)
        {
            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.Open(tutorialQuery.Title);

            var nextStep = Scope.Resolve<IContextService>().GetNextStep(tutorialQuery);
            var nextSteps = Scope.Resolve<INextStepSection>().GetNextSteps();

            var foundStep = nextSteps.SingleOrDefault(t => t.Title == nextStep.Title);
            if (foundStep != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(nextStep.Description, Is.EqualTo(foundStep.Description));

                    Assert.That(nextStep.IsRequiredLicense, Is.EqualTo(foundStep.HasLicenseKey()));

                    Assert.That(nextStep.PublicUrl, Is.EqualTo(foundStep.PublicUrl));
                });
            }
            else
            {
                Assert.Fail($"Next step with title {nextStep.Title} was not found on the tutorial page");
            }
        }

        [Test]
        [TestCaseSource(typeof(TutorialData), nameof(TutorialData.TutorialQueries))]
        [Description("Check if next step displays the same info as from geting service")]
        [Order(7)]
        public void CheckAttributesOfMission(TutorialQuery tutorialQuery)
        {
            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.Open(tutorialQuery.Title);

            var mission = Scope.Resolve<IContextService>().GetMission(tutorialQuery);
            var tiles = tutorial.GetAllTiles();

            var foundTile = tiles.SingleOrDefault(t => t.Title == mission.Title);
            if (foundTile != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(mission.Description == foundTile.Description);

                    Assert.That(mission.IsRequiredLicense == foundTile.HasLicenseKey());

                    Assert.That(mission.NavigatorLink == foundTile.TagLink);

                    Assert.That(mission.PrimaryTag == foundTile.PrimaryTag);

                    Assert.That(mission.Experience == foundTile.Experience);
                });
            }
            else
            {
                Assert.Fail($"{mission.Title} was not found on the tutorial page");
            }
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.TutorialLinks))]
        [Description("Check if completed steps are equal in summary and on the tutorial page")]
        [Order(8)]
        public void CheckCompletedSteps(string partialLink)
        {
            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.Open(partialLink);

            var pageHeader = Scope.Resolve<IPageHeader>().WaitForLoading();
            pageHeader.OpenLogonFrame();

            LogonStrategy.LogOn(UserPool.GetUser());

            tutorial.WaitForLoad();
            tutorial.FinishDoneSteps();

            var doneSteps = tutorial.GetDoneSteps();

            var summarySection = Scope.Resolve<ISummarySection>().WaitForLoading();
            var summarySteps = summarySection.GetSteps();

            foreach (var step in doneSteps)
            {
                var foundStep = summarySteps.SingleOrDefault(s => s.Id == step.Id);
                if (foundStep != null)
                {
                    Assert.That(foundStep.Completed(), Is.True);
                }
                else
                {
                    Assert.Fail($"Tutorial step id was: {step.Id}, summary step id was {foundStep.Id}");
                }
            }
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.TutorialLinks))]
        [Description("Check if completed steps show correct percentage")]
        [Order(9)]
        public void CompareProgressInSummary(string partialLink)
        {
            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.Open(partialLink);

            var pageHeader = Scope.Resolve<IPageHeader>().WaitForLoading();
            pageHeader.OpenLogonFrame();

            LogonStrategy.LogOn(UserPool.GetUser());

            tutorial.WaitForLoad();
            tutorial.FinishDoneSteps();

            var progress = tutorial.GetCurrentProgress();

            var summaryProgress = Scope.Resolve<ISummaryProgress>().Value;

            Assert.That(progress, Is.EqualTo(summaryProgress));
        }

        [Test]
        [TestCaseSource(typeof(TutorialsPath), nameof(TutorialsPath.TutorialLinks))]
        [Description("Check if completed steps show correct percentage")]
        [Order(10)]
        public void CheckProgressInCircle(string partialLink)
        {
            var tutorial = Scope.Resolve<ITutorial>();
            tutorial.Open(partialLink);

            var pageHeader = Scope.Resolve<IPageHeader>().WaitForLoading();
            pageHeader.OpenLogonFrame();

            LogonStrategy.LogOn(UserPool.GetUser());

            tutorial.WaitForLoad();
            tutorial.FinishDoneSteps();

            var summaryProgress = Scope.Resolve<ISummaryProgress>();

            double expectedProgress = summaryProgress.GetProgress();
            double barProgress = summaryProgress.GetBarProgress();

            Assert.That(expectedProgress, Is.EqualTo(barProgress));
        }

        public void CheckLicenseTag()
        {
            var summarySection = Scope.Resolve<ISummarySection>().WaitForLoading();

            Assert.That(summarySection.HasLicenseKey(), $"{summarySection.Title} does not have license key");
        }
    }
}
