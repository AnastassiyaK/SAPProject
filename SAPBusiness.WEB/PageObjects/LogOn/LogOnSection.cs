namespace SAPBusiness.WEB.PageObjects.LogOn
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class LogOnSection : BasePageObject, ILogOnSection
    {
        public LogOnSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
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
