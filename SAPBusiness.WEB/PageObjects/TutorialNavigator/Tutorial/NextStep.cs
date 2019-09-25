using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.CommonElements;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class NextStep : BasePageObject
    {
        private IWebElement _element;

        public NextStep(WebDriver driver, IWebElement element) : base(driver)
        {
            _element = element;
        }

        public string Description
        {
            get
            {
                return ElementDescription.Text;
            }
        }

        private IWebElement ElementDescription
        {
            get
            {
                return _element.FindElement(By.CssSelector(".description"));
            }
        }

        private IWebElement ElementTitle
        {
            get
            {
                return _element.FindElement(By.CssSelector(".main-tile__content-title"));
            }
        }

        public string Title
        {
            get
            {
                return ElementTitle.Text;
            }
        }

        private TitleComponent TitleComponent
        {
            get
            {
                return new TitleComponent(_driver, ElementTitle);
            }
        }

        public bool HasLicenseKey()
        {
            return TitleComponent.HasLicenseKey();
        }

        public string Link
        {
            get
            {
                return ElementTitle.GetAttribute("href");
            }
        }

        public string PublicUrl
        {
            get
            {
                string link = ElementTitle.GetAttribute("href");
                return link.Substring(link.IndexOf("/tutorial"));
            }
        }
    }
}
