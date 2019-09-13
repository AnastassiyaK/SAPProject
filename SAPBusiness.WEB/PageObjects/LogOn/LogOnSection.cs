using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.LogOn
{
    public class LogOnSection : BasePageObject, ILogOnSection
    {
        public LogOnSection(WebDriver driver) : base(driver)
        {

        }

        public IWebElement UserNameInput
        {
            get
            {
                return _driver.FindElement(By.Id("j_username"));
            }
        }

        public IWebElement PasswordInput
        {
            get
            {
                return _driver.FindElement(By.Id("j_password"));
            }
        }

        public IWebElement LogOnButton
        {
            get
            {
                return _driver.FindElement(By.Id("logOnFormSubmit"));
            }
        }
    }
}
