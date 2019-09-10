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

namespace SAPTests.Autofac
{
    class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseWebDriver>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BasePageObject<>)).AsSelf().InstancePerDependency();

            builder.RegisterType<BaseWebDriverFactory>();            

            builder.RegisterType<CookiesFrame>().AsSelf().InstancePerDependency();

            builder.RegisterType<ProjectsSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<SearchSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<FeedSortItem>().AsSelf().InstancePerDependency();

            builder.RegisterType<BlogPostSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<MembershipSection>().AsSelf().InstancePerDependency();

            //builder.RegisterType<MembershipSection>().As<IMembershipSection>();

            //builder.RegisterType<MembershipLogger>().AsSelf().InstancePerDependency();

            builder.RegisterType<FilterSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<TNavigator>().AsSelf().InstancePerDependency();

            builder.RegisterType<PageHeader>().AsSelf().InstancePerDependency();

            builder.RegisterType<TileLegend>().AsSelf().InstancePerDependency();

            builder.RegisterType<UserPool>().AsSelf().InstancePerDependency();

            builder.RegisterType<LogOnFrame>().AsSelf().InstancePerDependency();

            builder.RegisterType<UserStatistics>().AsSelf().InstancePerDependency();

            builder.RegisterType<TutorialSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<PageFooter>().AsSelf().InstancePerDependency();

            builder.RegisterType<SocialNetwork>().AsSelf().InstancePerDependency();

            builder.RegisterType<RestSharpUserService>().As<IUserService>();            
            
            //builder.RegisterType<FrameLogOn>().AsSelf();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(SAPBusiness)))
            //    .Where(t => t.Namespace.Contains("PageObjects"));
            //var repositoryAssemblies = Assembly.Load(nameof(SAPBusiness));
            //etc
            //  .GetExportedTypes()
        }
    }
}
