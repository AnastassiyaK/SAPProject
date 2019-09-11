using Autofac;
using SAPBusiness.WEB.PageObjects;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;
using SAPBusiness.WEB.PageObjects.OpenSource.Memberships;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search;
using TNavigator = SAPBusiness.WEB.PageObjects.TutorialNavigator.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.TutorialNavigator;
using SAPBusiness.UserData;
using SAPBusiness.Services.API_Services.User;
using SAPBusiness.UserData.DeveloperCenter;
using SAPBusiness.WEB.PageObjects.MainPage.Statistics;
using SAPBusiness.WEB.PageObjects.Footer;
using SAPBusiness.WEB.PageObjects.Footer.Networks;
using Core.WebDriver;
using SAPBusiness.Services.Interfaces.API_UserService;
using Core.DriverFactory;
using SAPBusiness.WEB.PageObjects.LogOn;

namespace SAPTests.Autofac
{
    class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseWebDriver>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BasePageObject<>)).AsSelf().InstancePerDependency();

            builder.RegisterType<BaseWebDriverFactory>().AsSelf().InstancePerDependency();

            builder.RegisterType<CookiesFrame>().As<ICookiesFrame>();

            builder.RegisterType<ProjectsSection>().As<IProjectsSection>();

            builder.RegisterType<SearchSection>().As<ISearchSection>();

            builder.RegisterType<FeedSortItem>().As<IFeedSortItem>();

            builder.RegisterType<BlogPostSection>().As<IBlogPostSection>();

            builder.RegisterType<MembershipSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<MembershipSection>().As<IMembershipSection>();

            //builder.RegisterType<MembershipLogger>().AsSelf().InstancePerDependency();

            builder.RegisterType<FilterSection>().As<IFilterSection>();

            builder.RegisterType<TNavigator>().As<ITutorialNavigator>().InstancePerDependency();

            builder.RegisterType<PageHeader>().As<IPageHeader>();

            builder.RegisterType<PageFooter>().As<IPageFooter>();

            builder.RegisterType<TileLegend>().As<ITileLegend>();

            builder.RegisterType<UserPool>().AsSelf().InstancePerDependency();

            builder.RegisterType<LogOnFrame>().AsSelf().InstancePerDependency();

            builder.RegisterType<UserStatistics>().AsSelf().InstancePerDependency();

            builder.RegisterType<TutorialSection>().As<ITutorialSection>();

            builder.RegisterType<SocialNetwork>().As<ISocialNetwork>();

            builder.RegisterType<RestSharpUserService>().As<IUserService>();            
            
            builder.RegisterType<LogOnSection>().As<ILogOnSection>();

            builder.RegisterType<FacetExperience>().As<IFacetExperience>();

            builder.RegisterType<FacetTopic>().As<IFacetTopic>();

            builder.RegisterType<FacetType>().As<IFacetType>(); 
        }
    }
}
