using Hardcore.Tests.Bots;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Hardcore.Tests.Configuration;

namespace Hardcore.Tests.Tests
{
    [TestFixture]
    public class BaseTestClass
    {
        protected IWebDriver _driver;
        protected ActionBot _actionBot;
        protected DefaultWait<IWebDriver> _wait;
        protected ITakesScreenshot takesScreenshot;

        [SetUp]
        public virtual void Setup()
        {
            this._driver = GetDriver();
            this._wait = this.GetWaiter();
            this._actionBot = this.GetActionBot();
            this._driver.Manage().Window.Maximize();
            takesScreenshot = (ITakesScreenshot)this._driver;
        }

        protected IWebDriver GetDriver()
        {
            BrowserType browserType = Configuration.Configuration.ReadBrowserTypeFromConfig();
            return Managers.WebDriverManager.GetWebDriver(browserType);
        }

        protected DefaultWait<IWebDriver> GetWaiter()
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
        }

        protected ActionBot GetActionBot()
        {
            return new ActionBot(this._driver, this._wait);
        }

        [TearDown]
        public virtual void TearDown()
        {
            _driver.Quit();
        }
    }
}