namespace SAPBusiness.WEB.PageObjects.Developers.CommonElements
{
    using System.Text.RegularExpressions;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.PageObjects.Developers.LicenseKey;

    public class TitleComponent : BaseDependentOnElementObject
    {
        private readonly char expectedLicenseTag = '\uE20E';

        public TitleComponent(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Text
        {
            get
            {
                return _element.Text;
            }
        }

        private IWebElement LicenseKey
        {
            get
            {
                return _element.FindElement(By.CssSelector(".icon-key"));
            }
        }

        private LicenseKeyPopup LicenseKeyPopup
        {
            get
            {
                return new LicenseKeyPopup(_driver, _logger).WaitForPresent();
            }
        }

        public bool HasLicenseKey()
        {
            try
            {
                var content = _driver.GetPropertyFromPseudoElement("before", "content", LicenseKey);
                Regex regex = new Regex(@"[^\\\""\w]");
                Match match = regex.Match(content);

                var expectedTag = char.ToString(expectedLicenseTag);

                if (expectedTag == match.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetLicenseKeyPopupText()
        {
            _driver.MoveToElement(LicenseKey);
            return LicenseKeyPopup.Title;
        }
    }
}
