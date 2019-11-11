namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;

    public class Tutorial : BaseTutorialPage, ITutorial
    {
        private static readonly string _tutorialUrl = "/tutorials/";

        private List<TileElement> _tiles;

        private List<Step> _doneSteps;

        private List<Step> _steps;

        public Tutorial(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger, appConfiguration)
        {
        }

        public string Title
        {
            get
            {
                return SummarySection.Title;
            }
        }

        private TutorialSummary SummarySection
        {
            get
            {
                return new TutorialSummary(_driver, _logger, _appConfiguration);
            }
        }

        private List<TileElement> Tiles
        {
            get
            {
                return _tiles ??
                    (_tiles = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new TileElement(_driver, element, _logger, _appConfiguration))
                    .ToList());
            }
        }

        private List<Step> DoneSteps
        {
            get
            {
                return _doneSteps ??
                    (_doneSteps = _driver.FindElements(By.CssSelector(".accordion"))
                    .Where(element =>
                    {
                        try
                        {
                            return element.FindElement(By.ClassName("done-button")).Displayed;
                        }
                        catch (NoSuchElementException)
                        {
                            return false;
                        }
                    })
                    .Select(element => new Step(_driver, element, _logger, new DoneButton(_driver, element, _logger)))
                    .ToList());
            }
        }

        private List<Step> Steps
        {
            get
            {
                return _steps ??
                    (_steps = _driver.FindElements(By.CssSelector(".accordion"))
                    .Select(element => new Step(_driver, element, _logger, null))
                    .ToList());
            }
        }

        public void AddBookmark()
        {
            SummarySection.AddBookmark();
        }

        public void FinishDoneSteps()
        {
            foreach (var step in DoneSteps)
            {
                step.Finish();
            }
        }

        public List<TileElement> GetAllTiles()
        {
            return Tiles;
        }

        public List<Step> GetDoneSteps()
        {
            return DoneSteps;
        }

        public int GetCurrentProgress()
        {
            double value = (double)DoneSteps.Count * 100 / Steps.Count;
            return (int)Math.Round(value);
        }

        public override void Open(string url)
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl, _tutorialUrl, url));
        }
    }
}
