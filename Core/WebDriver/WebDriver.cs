namespace Core.WebDriver
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Core.Configuration;
    using Core.DriverFactory;
    using NLog;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class WebDriver
    {
        public readonly DriverConfiguration _configuration;

        public readonly IDriverFactory _factory;

        public readonly ILogger _logger;

        public IWebDriver _driver;

        public WebDriver(IDriverFactory factory, DriverConfiguration configuration, ILogger logger)
        {
            _factory = factory;
            _configuration = configuration;
            _logger = logger;
        }

        public string Url => _driver.Url;

        public void Close()
        {
            _driver.Close();
            _logger.Debug($"Current tab was closed with url {Url}");
        }

        public void DismissAlert()
        {
            var alert = _driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public void ScrollToTheTop()
        {
            var script = "window.scrollBy(0,-document.body.scrollHeight);";
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            _logger.Trace($"Executing script {script} on element");
            js.ExecuteScript(script);
        }

        public void ExecuteScriptOnElement(string script, IWebElement element)
        {
            script = script ?? throw new ArgumentNullException(nameof(script));

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            _logger.Trace($"Executing script {script} on element");
            js.ExecuteScript(script, element);
        }

        public void ExecuteScript(string script)
        {
            script = script ?? throw new ArgumentNullException(nameof(script));

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            _logger.Trace($"Executing script {script}");
            js.ExecuteScript(script);
        }

        public string ExecuteScriptOnElementWithResult(string script, IWebElement element)
        {
            _logger.Trace($"Trying to get execute script on IWebElement");
            script = script ?? throw new ArgumentNullException(nameof(script));

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            _logger.Trace($"Executing script {script}");
            return js.ExecuteScript(script, element) as string;
        }

        public string GetPropertyFromPseudoElement(string pseudoElement, string property, IWebElement element)
        {
            _logger.Trace($"Trying to get property {property} from pseudo element");
            var script = $"return window.getComputedStyle(arguments[0], ':{pseudoElement}').getPropertyValue('{property}')";

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            _logger.Trace($"Executing script {script}");
            return js.ExecuteScript(script, element) as string;
        }

        public string ExecuteScriptWithResult(string script)
        {
            script = script ?? throw new ArgumentNullException(nameof(script));

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            return js.ExecuteScript(script) as string;
        }

        public IWebElement FindElement(By locator)
        {
            TryToFindElement(locator);
            return _driver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            _logger.Trace($"Searching for elements by locator {locator}");
            return _driver.FindElements(locator);
        }

        public ReadOnlyCollection<Cookie> GetBrowserCookies()
        {
            _logger.Debug("Returning cookies...");
            return _driver.Manage().Cookies.AllCookies;
        }

        public Browser GetDriverName()
        {
            return _factory.Name;
        }

        public bool CanClickOnElement(By locator)
        {
            _logger.Debug("Checking if element is clickable.");
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                _logger.Debug($"Element is not clickable");
                return false;
            }
            catch (ElementNotInteractableException)
            {
                _logger.Debug($"Element is not clickable");
                return false;
            }
        }

        public void InitDriver()
        {
            _driver = _factory.CreateWebDriver();
            _logger.Debug($"{_factory.Name} was inited.");
            _driver.Manage().Window.Maximize();
            _logger.Debug($"Browser window was maximized.");
        }

        public void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
            _logger.Debug($"Driver moved to element {element.Text}");
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _logger.Debug($"Driver navigated to {url}");
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _logger.Debug($"Driver navigated to {url}");
        }

        public void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url + ".html");
            _logger.Debug($"Driver navigated to {url}.html");
        }

        public void Quit()
        {
            if (_driver == null)
            {
                return;
            }

            _driver.Quit();
            _logger.Debug($"Session of a {_factory.ToString()} Webdriver  was finalized.");
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
            _logger.Debug("The page is refreshing...");
        }

        public void SwitchToFrame(IWebElement iFrame)
        {
            _driver.SwitchTo().Frame(iFrame);
            _logger.Debug("Driver switched to the frame.");
        }

        public void SwitchToDefaultContent()
        {
            _driver.SwitchTo().DefaultContent();
            _logger.Debug("Driver switched to the default content.");
        }

        public void SwitchToLastTab()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver => _driver.WindowHandles.Count > 1);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _logger.Debug("Driver switched to the last tab.");
        }

        public void SwitchToFirstTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            _logger.Debug("Driver switched to the first tab.");
        }

        public void TryToFindElement(By locator)
        {
            _logger.Trace($"Driver is performing search on the page by locator {locator}.");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver =>
            {
                try
                {
                    _driver.FindElement(locator);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            _logger.Debug($"Requested element was displayed.");
        }

        public void WaitForElementDissapear(By locator)
        {
            _logger.Debug($"Waiting for element dissapear...");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.DissapearTime));
            wait.Until(driver =>
            {
                try
                {
                    var displayed = _driver.FindElement(locator).Displayed;
                    return false;
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
            _logger.Trace($"Requested element was hidden.");
        }

        public void WaitForElementDissapear(IWebElement element)
        {
            _logger.Debug($"Waiting for element {element.Text} dissapear...");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.DissapearTime));
            wait.Until(driver =>
            {
                try
                {
                    var displayed = element.Displayed;
                    return false;
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
            _logger.Trace($"Requested element was hidden.");
        }

        public void WaitForPseudoElementDissapear(string pseudoElement, string property, IWebElement element)
        {
            var script = $"return window.getComputedStyle(arguments[0], ':{pseudoElement}').getPropertyValue('{property}')";

            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.DissapearTime));
            wait.Until(driver =>
            {
                _logger.Trace($"Executing script {script}");
                string result = js.ExecuteScript(script, element) as string;
                _logger.Trace($"Result ' {result} ' was returned");
                return result == "none" ? true : false;
            });
            _logger.Trace($"Pseudo element ---{pseudoElement}--- was hidden.");
        }

        public void WaitForElement(By locator)
        {
            TryToFindElement(locator);
        }

        public void WaitForElement(IWebElement element)
        {
            _logger.Debug($"Waiting for element...");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            _logger.Debug($"Requested element was found.");
        }

        public void WaitForElement(IWebElement element, By locator)
        {
            _logger.Debug($"Waiting for element...");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver =>
            {
                try
                {
                    return element.FindElement(locator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            _logger.Debug($"Requested element was found.");
        }

        public void WaitForElements(By locator)
        {
            _logger.Debug($"Waiting for elements...");
            int count = 0;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver =>
            {
                try
                {
                    count = _driver.FindElements(locator).Count;
                    return count > 0 ? true : false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            _logger.Debug($"{count} elements were displayed on the page.");
        }

        public void WaitForTabOpen()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutSearch));
            wait.Until(driver => !_driver.Url.Contains("about:blank"));
            _logger.Debug($"New tab was opened.");
        }

        public void WaitReadyState()
        {
            var waitDOM = new WebDriverWait(_driver, TimeSpan.FromSeconds(_configuration.TimeOutPageLoad));
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            waitDOM.Until(driver => (bool)js.ExecuteScript("return document.readyState == 'complete'"));
            _logger.Debug($"DOM was successfully built.");
        }
    }
}
