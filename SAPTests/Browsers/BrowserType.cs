using System.Collections.Generic;

namespace SAPTests.Browsers
{
    public class BrowserList
    {
        public static IEnumerable<Browser> Browsers { get; } = new List<Browser> { Browser.Chrome, Browser.Firefox , Browser.IE };
    }
}
