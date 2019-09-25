using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.LicenseKey;
using System.Text.RegularExpressions;

namespace SAPBusiness.WEB.PageObjects.CommonElements
{
    public class TitleComponent : BasePageObject
    {
        private readonly char expectedLicenseTag = '\uE20E';

        private readonly IWebElement _element;

        private LicenseKeyPopup LicenseKeyPopup
        {
            get
            {
                return new LicenseKeyPopup(_driver).WaitForPresent();
            }
        }

        public TitleComponent(WebDriver driver, IWebElement element)
            : base(driver)
        {
            _element = element;
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
