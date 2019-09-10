using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ProjectCard : IProjectCard
    {
        private readonly IWebElement element;

        public ProjectCard(IWebElement element)
        {
            this.element = element;
        }

        private IWebElement ElementTitle
        {
            get
            {
                return element.FindElement(By.ClassName("feature-card-title"));
            }
        }

        private IWebElement ElementImage
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
                var src = ElementImage.GetAttribute("src");
                return src.Substring(src.IndexOf("/dam"));
            }
        }

        private IWebElement ElementBackgroundImage
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
                var src = ElementBackgroundImage.GetAttribute("style");
                int length = src.Length - src.IndexOf("/dam") - 3;
                return src.Substring(src.IndexOf("/dam"), length);
            }
        }

        private IWebElement ElementLinkLearnMore
        {
            get
            {
                return element.FindElement(By.CssSelector(".feature-card-description a[href]"));
            }
        }

        private IWebElement ElementDescription
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
                return ElementTitle.Text;
            }
        }

        public string LinkLearnMore
        {
            get
            {
                return ElementLinkLearnMore.Text;
            }
        }

        public string Description
        {
            get
            {
                return ElementDescription.Text;
            }
        }
    }
}
