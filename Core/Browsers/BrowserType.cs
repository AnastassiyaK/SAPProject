using System.Collections.Generic;

namespace Core.Browsers
{
    public class BrowserType
    {
        public static IEnumerable<Browser> browsers = new List<Browser>
        { Browser.Chrome,Browser.Firefox};
            //,Browser.IE
     
    }
}
