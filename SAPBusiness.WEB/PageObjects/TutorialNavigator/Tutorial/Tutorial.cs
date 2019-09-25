using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class Tutorial : BaseTutorialPage, ITutorial
    {
        private readonly static string tutorialUrl = "/tutorials/";

        private List<TileElement> _tiles;

        private List<Step> _doneSteps;

        private List<Step> _steps;

        public Tutorial(WebDriver driver, IEnvironmentConfig appConfiguration)
            : base(driver, appConfiguration)
        {
        }

        public override void Open(string url)
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl, tutorialUrl, url));
        }

        private List<TileElement> Tiles
        {
            get
            {
                return _tiles ??
                    (_tiles = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new TileElement(_driver, element))
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
                    .Select(element => new Step(_driver, element, new DoneButton(_driver, element)))
                    .ToList());
            }
        }

        private List<Step> Steps
        {
            get
            {
                return _steps ??
                    (_steps = _driver.FindElements(By.CssSelector(".accordion"))
                    .Select(element => new Step(_driver, element, null))
                    .ToList());
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

        public void FinishDoneSteps()
        {
            foreach (var step in DoneSteps)
            {
                step.Finish();
            }
        }       
    }
}
