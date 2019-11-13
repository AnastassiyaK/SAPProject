namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Attributes
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.Exceptions;

    public class AttributesSection : BasePageObject, IAttributesSection
    {
        private readonly IAttributeFactory _attributeFactory;

        private List<IAttribute> _attributes;

        public AttributesSection(WebDriver driver, ILogger logger, IAttributeFactory attributeFactory)
            : base(driver, logger)
        {
            _attributeFactory = attributeFactory;
        }

        private List<IAttribute> Attributes
        {
            get
            {
                return _attributes ??
                      (_attributes = _driver.FindElements(By.CssSelector(".attribute-container"))
                      .Select(element => _attributeFactory.Create(element))
                      .ToList());
            }
        }

        public int GetAttributesAmount() => Attributes.Count;

        public bool HasAttributes() => Attributes.Count > 0;

        public IAttribute GetAttributeByTitle(string title)
        {
            foreach (var attribute in Attributes)
            {
                if (attribute.Title == title)
                {
                    return attribute;
                }
            }

            throw new AttributeNotFoundException(title);
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
