namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.PageObjects.Developers.CommonElements;

    public class NextStep : BaseDependentOnElementObject
    {
        public NextStep(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Description
        {
            get
            {
                return ElementDescription.Text;
            }
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

        public string Title
        {
            get
            {
                return ElementTitle.Text;
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

        private TitleComponent TitleComponent
        {
            get
            {
                return new TitleComponent(_driver, ElementTitle, _logger);
            }
        }

        public bool HasLicenseKey()
        {
            return TitleComponent.HasLicenseKey();
        }
    }
}
