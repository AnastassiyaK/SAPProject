namespace SAPTests.BDD
{
    using global::Autofac;
    using NUnit.Framework;
    using SAPTests.Browsers;
    using SpecFlow.Autofac;
    using TechTalk.SpecFlow;

    [TestFixtureSource(typeof(BrowsersList), nameof(BrowsersList.DefaultModeBrowsers))]

    public class BaseScenarioContext
    {
        public BaseScenarioContext()
        {
        }
    }
}
