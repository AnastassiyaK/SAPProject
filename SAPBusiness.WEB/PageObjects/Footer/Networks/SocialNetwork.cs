using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
    public class SocialNetwork : ISocialNetwork
    {
        private readonly IWebElement element;

        public SocialNetwork(IWebElement element)
        {
            this.element = element;
        }

        public IWebElement GoToLink
        {
            get
            {
                return element;
            }
        }

        public string Link
        {
            get
            {
                return GoToLink.GetAttribute("href");
            }
        }

        private IWebElement _elementImage
        {
            get
            {
                return element.FindElement(By.CssSelector("img"));
            }
        }

        public string Image
        {
            get
            {
                var src = _elementImage.GetAttribute("src");
                return src.Substring(src.IndexOf("/dam"));
            }
        }
    }
}
