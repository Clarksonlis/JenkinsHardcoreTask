using OpenQA.Selenium;
using Hardcore.Tests.Bots;
using OpenQA.Selenium.Support.UI;

namespace Hardcore.Tests.Pages;

public class NewRandomEmailPage
{
    private IWebDriver _driver;
    private DefaultWait<IWebDriver> _wait;
    private ActionBot _actionBot;

    // Определение элементов страницы
    private readonly By _copyRandomEmailButtonSelector = By.CssSelector("button[id='cprnd']");
    private readonly By _adsSelector = By.CssSelector(".adsbygoogle");

    public NewRandomEmailPage(IWebDriver driver, DefaultWait<IWebDriver> wait, ActionBot actionBot)
    {
        this._driver = driver;
        this._wait = wait;
        this._actionBot = actionBot;
    }


    public void AvoidAdvertisement()
    {
        this._wait.Until(_driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        this._wait.Until(_driver => _driver.FindElement(_adsSelector).Displayed);

        // Находим все элементы рекламы с классом ".adsbygoogle"
        IReadOnlyCollection<IWebElement> adElements = _driver.FindElements(_adsSelector);

        // Исполняем JavaScript-код для удаления каждого элемента из DOM
        foreach (IWebElement adElement in adElements)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].remove();", adElement);
        }
    }

    public void CopyNewRandomEmail()
    {
        this._wait.Until(_driver => _driver.FindElement(_copyRandomEmailButtonSelector).Displayed);
        this.AvoidAdvertisement();
        this._actionBot.Click(_copyRandomEmailButtonSelector);
    }
}