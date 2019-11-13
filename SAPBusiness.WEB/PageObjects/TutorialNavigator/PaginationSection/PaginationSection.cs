namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.Exceptions;

    public class PaginationSection : BasePageObject, IPaginationSection
    {
        public PaginationSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public List<CollapsedRange> CollapsedRanges
        {
            get
            {
                var allCollapsed = new List<CollapsedRange>(CollapsedStartElements);

                // allCollapsed.AddRange(CollapsedStartElements);
                allCollapsed.AddRange(CollapsedEndElements);
                return allCollapsed;
            }
        }

        public PageLink CurrentPage
        {
            get
            {
                return new PageLink(_driver, Pagination.FindElement(By.ClassName("active")), _logger);
            }
        }

        public List<BasePageLink> PageLinks
        {
            get
            {
                return CollectPageLinks();
            }
        }

        private IWebElement Pagination
        {
            get
            {
                return _driver.FindElement(By.ClassName("search-results__pagination"));
            }
        }

        private string ActivePage
        {
            get
            {
                return Pagination.FindElement(By.ClassName("active")).Text;
            }
        }

        private List<PageLink> ExpandedRange
        {
            get
            {
                return Pagination.FindElements(By.ClassName("main-part"))
                    .Select(element => new PageLink(_driver, element, _logger))
                    .ToList();
            }
        }

        private List<StartCollapsedRange> CollapsedStartElements
        {
            get
            {
                return Pagination.FindElements(By.ClassName("start-part"))
                    .Select(element => new StartCollapsedRange(_driver, element, _logger))
                    .ToList();
            }
        }

        private List<EndCollapsedRange> CollapsedEndElements
        {
            get
            {
                return Pagination.FindElements(By.ClassName("end-part"))
                    .Select(element => new EndCollapsedRange(_driver, element, _logger))
                    .ToList();
            }
        }

        public string GetCurrentPagination()
        {
            string pagination = "";

            foreach (var item in CollapsedStartElements)
            {
                pagination += item.ToString();
            }

            foreach (var item in ExpandedRange)
            {
                pagination += $"{item.ToString()} ";
            }

            foreach (var item in CollapsedEndElements)
            {
                pagination += item.ToString();
            }

            return pagination;
        }

        public int GetNumberOfPagesInExpandedArea()
        {
            return ExpandedRange.Count;
        }

        public bool IsVisible()
        {
            var pagination = GetCurrentPagination();

            if (string.IsNullOrWhiteSpace(pagination))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetTotalNumberOfPages()
        {
            var pagination = CollectPageLinks();
            var numbers = pagination.Select(p => int.Parse(p.Link)).ToList();
            return numbers.Max();
        }

        public int GetNumberOfActivePage()
        {
            return int.Parse(ActivePage);
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }

        public List<PageLink> GetExpandedRange()
        {
            return ExpandedRange;
        }

        public List<StartCollapsedRange> GetStartCollapsedElements()
        {
            return CollapsedStartElements;
        }

        public List<EndCollapsedRange> GetEndCollapsedElements()
        {
            return CollapsedEndElements;
        }

        public EndCollapsedRange GetFirstCollapsedRange()
        {
            if (CollapsedEndElements.Count > 0)
            {
                return CollapsedEndElements.FirstOrDefault();
            }

            throw new CollapsedRangeNotFoundException();
        }

        public void OpenPage(int pageNumber)
        {
            var link = GetPageLinkForNumber(pageNumber);

            if (link is CollapsedRange collapsedRange)
            {
                collapsedRange.Click();
                link = GetPageLinkForNumber(pageNumber);
            }

            link.Click();
        }

        private List<BasePageLink> CollectPageLinks()
        {
            var links = new List<BasePageLink>();
            links.AddRange(ExpandedRange);
            links.AddRange(CollapsedStartElements);
            links.AddRange(CollapsedEndElements);
            return links;
        }

        private BasePageLink GetPageLinkForNumber(int pageNumber)
        {
            foreach (var link in PageLinks)
            {
                if (link.ContainsPage(pageNumber))
                {
                    return link;
                }
            }

            throw new PageIsNotAccessibleException(pageNumber.ToString());
        }
    }
}
