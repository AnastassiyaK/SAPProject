namespace SAPBusiness.WEB.PageObjects.LogOn
{
    using OpenQA.Selenium;

    public interface ILogOnSection
    {
        IWebElement LogOnButton { get; }

        IWebElement PasswordInput { get; }

        IWebElement UserNameInput { get; }
    }
}