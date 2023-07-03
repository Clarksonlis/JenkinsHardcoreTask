using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Hardcore.Tests.Bots
{
    public class ActionBot
    {
        private IWebDriver driver;
        private DefaultWait<IWebDriver> wait;
        private Actions action;

        public ActionBot(IWebDriver driver, DefaultWait<IWebDriver> wait)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = new Actions(driver);
        }

        public void Click(By locator)
        {
            this.wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }

        public void Submit(By locator)
        {
            this.wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Submit();
        }

        public void Type(By locator, string text)
        {
            this.wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public void PasteFromClipboard(By locator)
        {
            this.wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
            action.KeyDown(Keys.Command).SendKeys("v").KeyUp(Keys.Command).Perform();
        }

        public void SwitchToFrame(By locator)
        {
            this.wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.SwitchTo().Frame(driver.FindElement(locator));
        }

        public string GetText(By locator)
        {
            this.wait.Until(driver => driver.FindElement(locator).Displayed);
            string result = driver.FindElement(locator).Text;
            return result;
        }       
    }
}