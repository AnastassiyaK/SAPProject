using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
    public interface ISocialNetwork
    {
        IWebElement GoToLink { get; }
        string Image { get; }
        string Link { get; }
    }
}