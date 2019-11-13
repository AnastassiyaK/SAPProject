namespace SAPBusiness.WEB.PageObjects.LogOn
{
    using Core.WebDriver;
    using NLog;
    using SAPBusiness.UserData;

    public class LogOnPage : BasePageObject, ILogOnStrategy
    {
        private readonly ILogOnSection _logOnSection;

        public LogOnPage(WebDriver driver, ILogger logger, ILogOnSection logOnSection)
            : base(driver, logger)
        {
            _logOnSection = logOnSection;
        }

        public void LogOn(User user)
        {
            _logOnSection.UserNameInput.SendKeys(user.Login);
            _logOnSection.PasswordInput.SendKeys(user.Password);

            _logOnSection.LogOnButton.Click();
        }
    }
}
