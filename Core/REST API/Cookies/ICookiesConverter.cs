using System.Collections.ObjectModel;
using System.Net;

namespace Core.REST_API.Cookies
{
    public interface ICookiesConverter
    {
        CookieContainer ExtractCookies(ReadOnlyCollection<OpenQA.Selenium.Cookie> cookies);
    }
}