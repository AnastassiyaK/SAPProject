using System.Collections.ObjectModel;
using System.Net;
using DefaultCookie = System.Net.Cookie;
using SeleniumCookie = OpenQA.Selenium.Cookie;


namespace Core.REST_API.Cookies
{
    public class CookiesConverter
    {
        public CookieContainer ExtractCookies(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            CookieContainer container = new CookieContainer();

            foreach (var cookie in cookies)
            {
                try
                {
                    DefaultCookie _cookie = new DefaultCookie
                    {
                        Name = cookie.Name,
                        Value = cookie.Value,
                        Domain = cookie.Domain
                    };

                    container.Add(_cookie);
                }
                catch (CookieException)
                {
                    continue;
                }
            }

            return container;
        }
    }
}
