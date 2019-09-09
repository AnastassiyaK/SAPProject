using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Logon
{
    public class LogonSection : BasePageObject<LogonSection>
    {
        public LogonSection(BaseWebDriver driver) : base(driver)
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

        protected override LogonSection WaitForLoad()
        {
            return this;
        }
    }
}
