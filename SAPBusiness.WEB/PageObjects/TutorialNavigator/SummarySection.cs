namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;
    using SAPBusiness.WEB.Exceptions;
    using SAPBusiness.WEB.PageObjects.Developers.CommonElements;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;

    public class SummarySection : BasePageObject, ISummarySection
    {
        private readonly EnvironmentConfig _appConfiguration;

        private List<SummaryStep> _summarySteps;

        public SummarySection(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public string Title
        {
            get
            {
                return ElementTitle.Text;
            }
        }

        private IWebElement BookmarkElement
        {
            get
            {
                return _driver.FindElement(By.Id("bookmark-summary"));
            }
        }

        private IBookmark Bookmark
        {
            get
            {
                return new Bookmark(_driver, BookmarkElement, _logger, _appConfiguration);
            }
        }

        private TitleComponent TitleComponent
        {
            get
            {
                return new TitleComponent(_driver, ElementTitle, _logger);
            }
        }

        private IWebElement ElementTitle
        {
            get
            {
                return _driver.FindElement(By.CssSelector("div[class='right body'] div[class='title']"));
            }
        }

        private List<SummaryStep> SummarySteps
        {
            get
            {
                return _summarySteps ??
                    (_summarySteps = _driver.FindElements(By.CssSelector("div[id*='summary_step']"))
                    .Select(element => new SummaryStep(_driver, element, _logger))
                    .ToList());
            }
        }

        public void AddBookmark()
        {
            if (!Bookmark.IsActive)
            {
                Bookmark.Click();
            }
            else
            {
                throw new TutorialBookmarkedException(Title);
            }
        }

        public bool BookMarkDisplayed()
        {
            return Bookmark.Displayed;
        }

        public bool HasLicenseKey()
        {
            return TitleComponent.HasLicenseKey();
        }

        public List<SummaryStep> GetSteps()
        {
            return SummarySteps;
        }

        public string GetLicensePopupText()
        {
            return TitleComponent.GetLicenseKeyPopupText();
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }
    }
}
