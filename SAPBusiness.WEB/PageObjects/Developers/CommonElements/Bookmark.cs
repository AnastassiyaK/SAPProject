namespace SAPBusiness.WEB.PageObjects.Developers.CommonElements
{
    using System;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;
    using SAPBusiness.Enums;

    public class Bookmark : BaseDependentOnElementObject, IBookmark
    {
        private readonly EnvironmentConfig _appConfiguration;

        private TutorialType _type;

        public Bookmark(WebDriver driver, IWebElement element, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, element, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public bool IsActive
        {
            get
            {
                return BookmarkElement.GetAttribute("class").Contains("inactive") ? false : true;
            }
        }

        public bool Displayed
        {
            get
            {
                return BookmarkElement.Displayed;
            }
        }

        public string Link
        {
            get
            {
                return string.Concat(_appConfiguration.ProdUrl, BookmarkElement.GetAttribute("data-url"));
            }
        }

        public TutorialType Type
        {
            get
            {
                SetTypeOfBookmark();
                return _type;
            }
        }

        private IWebElement BookmarkElement
        {
            get
            {
                return _element.FindElement(By.CssSelector(".bookmark-icon-selector"));
            }
        }

        public void Click()
        {
            BookmarkElement.Click();
            WaitForBookmark();
        }

        private void SetTypeOfBookmark()
        {
            var tempType = BookmarkElement.GetAttribute("data-type");

            var type = tempType.Substring(tempType.IndexOf("/") + 1);

            var typeToParse = type.First().ToString().ToUpper() + type.Substring(1);

            _type = ParseType(typeToParse);
        }

        private TutorialType ParseType(string type)
        {
            return (TutorialType)Enum.Parse(typeof(TutorialType), type);
        }

        private void WaitForBookmark()
        {
            _driver.WaitForElement(_element, By.CssSelector(".bookmark-icon-selector.bookmarked"));
        }
    }
}
