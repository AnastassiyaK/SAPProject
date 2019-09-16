﻿using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
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

        private IWebElement ElementImage
        {
            get
            {
                return _element.FindElement(By.CssSelector("img"));
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
    }
}
