using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public class MembershipSection : BasePageObject<MembershipSection>, IMembershipSection
    {
        public MembershipSection(BaseWebDriver driver) : base(driver)
        {

        }

        private List<Membership> _memberships;

        private List<Membership> Memberships
        {
            get
            {
                return _memberships ??
                    (_memberships = _driver.FindElements(By.ClassName("membership-container"))
                    .Select(element => new Membership(element))
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

        public Membership GetMembershipContainerByTitle(string title)
        {
            foreach (var membership in Memberships)
            {
                if (membership.Title == title)
                {
                    return membership;

                }
            }
            throw new Exception();//implement some exeption            
        }

        public List<Membership> GetAllMemberships()
        {
            return Memberships;
        }

        protected override MembershipSection WaitForLoad()
        {
            return this;
        }
    }
}
