namespace SAPBusiness.WEB.PageObjects.Developers.Footer.Networks
{
    using OpenQA.Selenium;

    public class SocialNetwork : ISocialNetwork
    {
        private readonly IWebElement _element;

        public SocialNetwork(IWebElement element)
        {
            _element = element;
        }

        public string Link
        {
            get
            {
                return _element.GetAttribute("href");
            }
        }

        public string Image
        {
            get
            {
                var src = ElementImage.GetAttribute("src");
                return src.Substring(src.IndexOf("/dam"));
            }
        }

        private IWebElement ElementImage
        {
            get
            {
                return _element.FindElement(By.CssSelector("img"));
            }
        }
    }
}
