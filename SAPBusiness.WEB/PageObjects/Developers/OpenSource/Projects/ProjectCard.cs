namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using OpenQA.Selenium;

    public class ProjectCard : IProjectCard
    {
        private readonly IWebElement _element;

        public ProjectCard(IWebElement element)
        {
            _element = element;
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

        public string Description
        {
            get
            {
                return ElementDescription.Text;
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

        private IWebElement ElementTitle
        {
            get
            {
                return _element.FindElement(By.ClassName("feature-card-title"));
            }
        }

        private IWebElement ElementImage
        {
            get
            {
                return _element.FindElement(By.ClassName("feature-card-image"));
            }
        }

        private IWebElement ElementBackgroundImage
        {
            get
            {
                return _element.FindElement(By.ClassName("feature-card-transparent-bg"));
            }
        }

        private IWebElement ElementLinkLearnMore
        {
            get
            {
                return _element.FindElement(By.CssSelector(".feature-card-description a[href]"));
            }
        }

        private IWebElement ElementDescription
        {
            get
            {
                return _element.FindElement(By.ClassName("feature-card-description"));
            }
        }
    }
}
