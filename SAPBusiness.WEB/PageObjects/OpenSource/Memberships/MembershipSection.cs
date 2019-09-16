using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public class MembershipSection : BasePageObject, IMembershipSection
    {
        private readonly IMembershipFactory _membershipFactory;

        private List<IMembership> _memberships;

        public MembershipSection(WebDriver driver, IMembershipFactory membershipFactory) : base(driver)
        {
            _membershipFactory = membershipFactory;
        }

        private List<IMembership> Memberships
        {
            get
            {
                return _memberships ??
                    (_memberships = _driver.FindElements(By.ClassName("membership-container"))
                    .Select(element => _membershipFactory.Create(element))
                    .ToList());
            }
        }

        public string Title
        {
            get
            {
                return _driver.FindElement(By.ClassName("memberships-header-header")).Text;
            }
        }

        public string Description
        {
            get
            {
                return _driver.FindElement(By.ClassName("memberships-header-description")).Text;
            }
        }

        public int GetMembershipsAmount() => Memberships.Count;

        public bool HasMemberships() => Memberships.Count > 0;

        public IMembership GetMembershipContainerByTitle(string title)
        {
            foreach (var membership in Memberships)
            {
                if (membership.Title == title)
                {
                    return membership;

                }
            }
            throw new MembershipNotFoundException(title);      
        }

        public List<IMembership> GetAllMemberships()
        {
            return Memberships;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
