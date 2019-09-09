using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ProjectCard
    {
        private IWebElement element;
        public ProjectCard(IWebElement element)
        {
            this.element = element;
        }
        private IWebElement elementTitle
        {
            get
            {
                return element.FindElement(By.ClassName("feature-card-title"));
            }
        }

        private IWebElement _imageElement
        {
            get
            {
                return element.FindElement(By.ClassName("feature-card-image"));

            }
        }
        public string Image
        {
            get
            {
                var src = _imageElement.GetAttribute("src");
                return src.Substring(src.IndexOf("/dam"));
            }
        }
        private IWebElement elementBackgroundImage
        {
            get
            {
                return element.FindElement(By.ClassName("feature-card-transparent-bg"));
            }
        }
        public string BackgroundImage
        {
            get
            {
                var src = elementBackgroundImage.GetAttribute("style");
                int length = src.Length - src.IndexOf("/dam") - 3;
                return src.Substring(src.IndexOf("/dam"), length);
            }
        }
        private IWebElement elementLinkLearnMore
        {
            get
            {
                return element.FindElement(By.CssSelector(".feature-card-description a[href]"));
            }
        }
        private IWebElement elementDescription
        {
            get
            {
                return element.FindElement(By.ClassName("feature-card-description"));
            }
        }
        public string Title
        {
            get
            {
                return elementTitle.Text;
            }
        }

        public string LinkLearnMore
        {
            get
            {
                return elementLinkLearnMore.Text;
            }
        }
        public string Description
        {
            get
            {
                return elementDescription.Text;
            }
        }
    }
}
