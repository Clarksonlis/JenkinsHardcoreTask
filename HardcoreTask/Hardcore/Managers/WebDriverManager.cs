using Hardcore.Tests.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Hardcore.Tests.Managers
{
    public static class WebDriverManager
    {
        public static IWebDriver GetWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.CHROME:
                    return new ChromeDriver();
                case BrowserType.FIREFOX:
                    return new FirefoxDriver();
                default:
                    throw new ArgumentException("Invalid driver name.");
            }
        }
    }
}