using System.Collections.ObjectModel;
using System.Net;
using NetCookie = System.Net.Cookie;
using SeleniumCookie = OpenQA.Selenium.Cookie;


namespace Core.REST_API.Cookies
{
    public class CookiesService
    {
        public CookieContainer ExtractCookies(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            CookieContainer container = new System.Net.CookieContainer();

            foreach (var cookie in cookies)
            {

                try
                {
                    NetCookie _cookie = new NetCookie
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
