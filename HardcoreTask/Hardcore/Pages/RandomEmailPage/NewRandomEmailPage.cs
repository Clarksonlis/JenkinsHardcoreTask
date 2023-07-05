using OpenQA.Selenium;
using Hardcore.Tests.Bots;
using OpenQA.Selenium.Support.UI;

namespace Hardcore.Tests.Pages;

public class NewRandomEmailPage
{
    private IWebDriver _driver;
    private DefaultWait<IWebDriver> _wait;
    private ActionBot _actionBot;

    // Элементы страницы
    private readonly By _copyRandomEmailButtonSelector = By.CssSelector("button[id='cprnd']");
    private readonly By _adsSelector = By.CssSelector(".adsbygoogle");

    public NewRandomEmailPage(IWebDriver driver, DefaultWait<IWebDriver> wait, ActionBot actionBot)
    {
        this._driver = driver;
        this._wait = wait;
        this._actionBot = actionBot;
    }

    /// <summary>
    /// Метод удаления рекламы на сайте (а именно всех элементов с селектором .adsbygoogle из DOM), т.к. она мешает нажатию кнопок
    /// </summary>

    public void AvoidAdvertisement()
    {
        this._wait.Until(_driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
        this._wait.Until(_driver => _driver.FindElement(_adsSelector).Displayed);

        IReadOnlyCollection<IWebElement> adElements = _driver.FindElements(_adsSelector);

        foreach (IWebElement adElement in adElements)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].remove();", adElement);
        }
    }

    /// <summary>
    /// Метод копирования нового рандомного email, который включает в себя метод удаления рекламы AvoidAdvertisement()
    /// </summary>
    public void CopyNewRandomEmail()
    {
        this._wait.Until(_driver => _driver.FindElement(_copyRandomEmailButtonSelector).Displayed);
        this.AvoidAdvertisement();
        this._actionBot.Click(_copyRandomEmailButtonSelector);
    }
}