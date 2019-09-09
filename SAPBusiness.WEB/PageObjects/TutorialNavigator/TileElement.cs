using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TileElement
    {
        private IWebElement element;

        public TileElement(IWebElement element)
        {
            this.element = element;
        }

        private IWebElement BookMark
        {
            get { return element.FindElement(By.ClassName("bookmark-icon__on-tile")); }

        }

        private IWebElement TileLevel
        {
            get { return element.FindElement(By.ClassName("level-info")); }

        }

        private IWebElement TileType
        {
            get { return element.FindElement(By.ClassName("tile-type")); }
        }

        private IWebElement TileTime
        {
            get { return element.FindElement(By.ClassName("time-info")); }
        }

        private IWebElement TileTitle
        {
            get { return element.FindElement(By.CssSelector(".tutorial-tile__body a[class = 'title']")); }
        }

        private IWebElement TileNewLabel
        {
            get { return element.FindElement(By.CssSelector(".tutorial-tile__head div[class='label']")); }
        }
        private IWebElement TileDescription
        {
            get { return element.FindElement(By.CssSelector(".tutorial-tile__body p")); }
        }
        private IWebElement TileTag
        {
            get { return element.FindElement(By.ClassName("tags")); }
        }
        private IWebElement TileHeader
        {
            get { return element.FindElement(By.CssSelector("[data-info]")); }
        }
        private IWebElement TileLicenseTag
        {
            get { return element.FindElement(By.ClassName("icon-key")); }
        }

        public bool BookMarkDisplayed()
        {
            return BookMark.Displayed;
        }

        public string ExperienceTag
        {
            get
            {
                return TileLevel.Text;
            }
        }
    }
}
