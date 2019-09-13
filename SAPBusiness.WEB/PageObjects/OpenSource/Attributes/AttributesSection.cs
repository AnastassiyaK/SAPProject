using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public class AttributesSection : BasePageObject, IAttributesSection
    {
        public AttributesSection(WebDriver driver) : base(driver)
        {

        }

        private List<Attribute> _attributes;

        private List<Attribute> Attributes
        {
            get
            {
                return _attributes ??
                      (_attributes = _driver.FindElements(By.CssSelector(".attribute-container"))
                      .Select(element => new Attribute(element))
                      .ToList()
                      );
            }
        }

        public int GetAttributesAmount() => Attributes.Count;

        public bool HasAttributes() => Attributes.Count > 0;

        public Attribute GetAttributeByTitle(string title)
        {
            foreach (var attribute in Attributes)
            {
                if (attribute.Title == title)
                {
                    return attribute;

                }
            }
            throw new Exception();//implement some exeption 
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
