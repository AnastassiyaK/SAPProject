namespace Core.REST_API.Cookies
{
    using System.Collections.ObjectModel;
    using System.Net;

    public interface ICookiesConverter
    {
        CookieContainer ExtractCookies(ReadOnlyCollection<OpenQA.Selenium.Cookie> cookies);
    }
}