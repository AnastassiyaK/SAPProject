using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.CommonElements;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TileElement : BasePageObject, ITileElement
    {
        private readonly IWebElement _element;

        public TileElement(WebDriver driver, IWebElement element)
            : base(driver)
        {
            _element = element;
        }

        public string Description
        {
            get
            {
                return TileDescription.Text;
            }
        }

        private TitleComponent TitleComponent
        {
            get
            {
                return new TitleComponent(_driver,TileTitle);
            }
        }

        private IWebElement BookMark
        {
            get
            {
                return _element.FindElement(By.ClassName("bookmark-icon__on-tile"));
            }
        }

        private IWebElement TileLevel
        {
            get
            {
                return _element.FindElement(By.ClassName("level-info"));
            }
        }

        private IWebElement TileType
        {
            get
            {
                return _element.FindElement(By.ClassName("tile-type"));
            }
        }

        private IWebElement TileTime
        {
            get
            {
                return _element.FindElement(By.ClassName("time-info"));
            }
        }

        private IWebElement TileTitle
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-tile__body a[class = 'title']"));
            }
        }

        private IWebElement TileNewLabel
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-tile__head div[class='label']"));
            }
        }

        private IWebElement TileDescription
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-tile__body p"));
            }
        }

        private IWebElement TileTag
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tags .wrapper a"));
            }
        }

        private IWebElement TileHeader
        {
            get
            {
                return _element.FindElement(By.CssSelector("[data-info]"));
            }
        }

        public bool BookMarkDisplayed()
        {
            return BookMark.Displayed;
        }

        public string Experience
        {
            get
            {
                return TileLevel.Text;
            }
        }

        public string Title
        {
            get
            {
                return TitleComponent.Text;
            }
        }

        public bool HasLicenseKey()
        {
           return TitleComponent.HasLicenseKey();
        }

        public string TagLink
        {
            get
            {
                string link = TileTag.GetAttribute("href");
                return link.Substring(link.IndexOf("/tutorial"));
            }
        }

        public string PrimaryTag
        {
            get
            {
                return TileTag.Text;
            }
        }
    }
}
