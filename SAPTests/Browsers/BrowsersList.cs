namespace SAPTests.Browsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class BrowsersList
    {
        static BrowsersList()
        {
        }

        public static IEnumerable<Browser> DefaultModeBrowsers
        {
            get
            {
                return GetBrowsersModes().DefaultMode
                       .Select(browser => (Browser)Enum.Parse(typeof(Browser), browser));
            }
        }

        public static IEnumerable<Browser> MobileModeBrowsers
        {
            get
            {
                return GetBrowsersModes().MobileVersion
                       .Select(browser => (Browser)Enum.Parse(typeof(Browser), browser));
            }
        }

        private static BrowserMods GetBrowsersModes()
        {
            return JsonConvert.DeserializeObject<BrowserMods>(GetJSONString());
        }

        private static string GetJSONString()
        {
            return File.ReadAllText($@"{Directory.GetCurrentDirectory()}\Configuration\TestExecutionConfiguration.json");
        }
    }
}
