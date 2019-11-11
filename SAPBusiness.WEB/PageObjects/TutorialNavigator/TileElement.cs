namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using System;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;
    using SAPBusiness.Enums;
    using SAPBusiness.WEB.Exceptions;
    using SAPBusiness.WEB.PageObjects.Developers.CommonElements;

    public class TileElement : BaseDependentOnElementObject, ITileElement
    {
        private readonly EnvironmentConfig _appConfiguration;

        private IWebElement _newLabel;

        public TileElement(WebDriver driver, IWebElement element, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, element, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public string Description
        {
            get
            {
                return TileDescriptionElement.Text;
            }
        }

        public Experience Experience
        {
            get
            {
                return (Experience)Enum.Parse(typeof(Experience), TileLevelElement.Text);
            }
        }

        public int Id
        {
            get
            {
                return int.Parse(TileHeaderElement.GetAttribute("data-imsid"));
            }
        }

        public string TagLink
        {
            get
            {
                string link = TileTagElement.GetAttribute("href");
                return link.Substring(link.IndexOf("/tutorial"));
            }
        }

        public string Time
        {
            get
            {
                return TileTimeElement.Text;
            }
        }

        public string Title
        {
            get
            {
                return TitleComponent.Text;
            }
        }

        public TutorialType Type
        {
            get
            {
                return (TutorialType)Enum.Parse(typeof(TutorialType), TileTypeElement.Text);
            }
        }

        public string PrimaryTag
        {
            get
            {
                return TileTagElement.Text;
            }
        }

        public string Link
        {
            get
            {
                return string.Concat(_appConfiguration.ProdUrl, ClickableArea.GetAttribute("data-clickable-url"));
            }
        }

        private IWebElement ClickableArea
        {
            get
            {
                return _element.FindElement(By.ClassName("clickable-area"));
            }
        }

        private IBookmark Bookmark
        {
            get
            {
                return new Bookmark(_driver, _element, _logger, _appConfiguration);
            }
        }

        private TitleComponent TitleComponent
        {
            get
            {
                return new TitleComponent(_driver, TileTitleElement, _logger);
            }
        }

        private IWebElement TileLevelElement
        {
            get
            {
                return _element.FindElement(By.ClassName("level-info"));
            }
        }

        private IWebElement TileTypeElement
        {
            get
            {
                return _element.FindElement(By.ClassName("tile-type"));
            }
        }

        private IWebElement TileTimeElement
        {
            get
            {
                return _element.FindElement(By.ClassName("time-info"));
            }
        }

        private IWebElement TileTitleElement
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-tile__body a[class = 'title']"));
            }
        }

        private IWebElement TileNewLabelElement
        {
            get
            {
                return _newLabel;
            }
        }

        private IWebElement TileDescriptionElement
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-tile__body p"));
            }
        }

        private IWebElement TileTagElement
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tags .wrapper a"));
            }
        }

        private IWebElement TileHeaderElement
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-tile__head"));
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

        public bool HasNewLabel()
        {
            try
            {
                _newLabel = _element.FindElement(By.CssSelector(".label"));
                return _newLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Open()
        {
            ClickableArea.Click();
        }
    }
}
