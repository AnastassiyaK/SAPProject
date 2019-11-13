namespace Core.REST_API.Cookies
{
    using System.Collections.ObjectModel;
    using System.Net;
    using DefaultCookie = System.Net.Cookie;
    using SeleniumCookie = OpenQA.Selenium.Cookie;

    public class CookiesConverter : ICookiesConverter
    {
        public CookieContainer ExtractCookies(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            CookieContainer container = new CookieContainer();

            foreach (var cookie in cookies)
            {
                try
                {
                    DefaultCookie defaultCookie = new DefaultCookie
                    {
                        Name = cookie.Name,
                        Value = cookie.Value,
                        Domain = cookie.Domain,
                    };

                    container.Add(defaultCookie);
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
