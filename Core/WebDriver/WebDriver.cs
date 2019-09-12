using Core.Configuration;
using Core.DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Core.WebDriver
{
    public class WebDriver
    {
        private IWebDriver _driver;

        private IDriverFactory _factory;

        IDriverConfiguration _configuration;

        public WebDriver(IDriverFactory factory, IDriverConfiguration configuration)
        {
            _factory = factory;
            _configuration = configuration;
        }

        public string Url => _driver.Url;

        public void InitDriver()
        {
            _driver = _factory.CreateWebDriver();
            _driver.Manage().Window.Maximize();
        }

        public ReadOnlyCollection<Cookie> GetBrowserCookies()
        {
            return _driver.Manage().Cookies.AllCookies;
        }

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return _driver.FindElements(locator);
        }

        public bool HasElement(By locator)
        {
            try
            {
                _driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void WaitForElementDissapear(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver =>
            {
                try
                {
                    return !_driver.FindElement(locator).Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        public void WaitForElementDissapear(IWebElement element, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        public void WaitForElement(By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    return _driver.FindElement(locator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElements(ReadOnlyCollection<IWebElement> elements, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    return elements.Count > 1;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ExecuteScriptOnElement(string script, IWebElement element)
        {
            script = script ?? throw new ArgumentNullException(nameof(script));

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            js.ExecuteScript(script, element);
        }

        public void ExecuteScript(string script)
        {
            script = script ?? throw new ArgumentNullException(nameof(script));

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            js.ExecuteScript(script);
        }

        public void WaitReadyState()
        {
            var waitDOM = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            waitDOM.Until(driver => (bool)js.ExecuteScript("return document.readyState == 'complete'"));
        }

        public void SwitchToFrame(IWebElement iFrame)
        {
            _driver.SwitchTo().Frame(iFrame);
        }

        public void SwitchToDefaultContent()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public void SwitchToLastTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public void SwitchToFirstTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        public void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public void Close()
        {
            _driver.Close();
        }

        public void Quit()
        {
            if (_driver == null) return;
            _driver.Quit();
        }
    }
}
