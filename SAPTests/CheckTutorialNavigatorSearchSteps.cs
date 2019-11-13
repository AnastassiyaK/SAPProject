namespace SAPTests
{
    using Core.DriverFactory;
    using Core.WebDriver;
    using global::Autofac;
    using NLog;
    using NUnit.Framework;
    using SAPBusiness.WEB.PageObjects;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Search;
    using TechTalk.SpecFlow;

    [Binding]
    public class CheckTutorialNavigatorSearchSteps
    {
        private static ILogger _logger;

        private static string _searchingWord;

        private ILifetimeScope _scope;

        private WebDriver _driver;

        [BeforeScenario]
        public void SetUp()
        {
            _logger = LogManager.GetLogger($"{TestContext.CurrentContext.Test.Name}");
        }

        [AfterScenario]
        public void AfterTestRun()
        {
            _driver.Quit();
        }

        public void InitBrowser()
        {
            _driver = _scope.Resolve<WebDriver>();

            _driver.InitDriver();
        }

        [Given(@"A browser (.*) is set to launch")]
        public void GivenABrowserIsRegistered(string browser)
        {
            if (browser == Browser.Chrome.ToString())
            {
                _scope = SetUpGlobal.Container.BeginLifetimeScope(container =>
                {
                    container.RegisterType<ChromeDriverFactory>().As<IDriverFactory>();
                    container.RegisterInstance(_logger).As<ILogger>().SingleInstance();
                });
            }

            if (browser == Browser.Firefox.ToString())
            {
                _scope = SetUpGlobal.Container.BeginLifetimeScope(container =>
                {
                    container.RegisterType<FirefoxDriverFactory>().As<IDriverFactory>();
                    container.RegisterInstance(_logger).As<ILogger>().SingleInstance();
                });
            }

            if (browser == Browser.IE.ToString())
            {
                _scope = SetUpGlobal.Container.BeginLifetimeScope(container =>
                {
                    container.RegisterType<IEDriverFactory>().As<IDriverFactory>();
                    container.RegisterInstance(_logger).As<ILogger>().SingleInstance();
                });
            }

            InitBrowser();
        }

        [Given(@"I have opened Tutorial Navigator page")]
        public void GivenIHaveOpenedTutorialNavigatorPage()
        {
            var tutorialNavigator = _scope.Resolve<ITutorialNavigator>();
            tutorialNavigator.Open();
            tutorialNavigator.WaitForLoad();
        }

        [Given(@"I have set searching word (.*)")]
        public void GivenIHaveSetSearchingWords(string search)
        {
            // ScenarioContext.Current[]
            _searchingWord = search;
        }

        [Given(@"I have entered the searching word in the input and press the search button")]
        public void GivenIHaveEnteredSomeTextInSearchInputAndPressTheSearchButton()
        {
            _scope.Resolve<ISearchSection>().WaitForLoading().Search(_searchingWord);
        }

        [Then(@"The tutorial navigator page has tutorials with entered text in it's description or title")]
        public void ThenTheTutorialNavigatorPageHasTilesWithSearhingWord()
        {
            var tiles = _scope.Resolve<ITutorialNavigator>().WaitForLoading().GetAllTiles();
            foreach (var tile in tiles)
            {
                Assert.That(tile.Description.Contains(_searchingWord) || tile.Title.Contains(_searchingWord));
            }
        }
    }
}
