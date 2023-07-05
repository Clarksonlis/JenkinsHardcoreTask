using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Hardcore.Tests.Bots;

namespace Hardcore.Tests.Pages;

public class RandomEmailPage
{
    private IWebDriver _driver;
    private DefaultWait<IWebDriver> _wait;
    private ActionBot _actionBot;
    private string secondWindow;

    // Элементы страницы
    private readonly By _randomEmailButtonSelector = By.CssSelector("main a[href='email-generator']");
    private readonly By _adsSelector = By.CssSelector(".adsbygoogle");


    public RandomEmailPage(IWebDriver driver, DefaultWait<IWebDriver> wait, ActionBot actionBot)
    {
        this._driver = driver;
        this._wait = wait;
        this._actionBot = actionBot;
    }


    /// <summary>
    /// Метод открытия новой вкладки и перехода на сайт генерации рандомного email https://yopmail.com/
    /// </summary>

    public void OpenNewWindow()
    {
        this._driver.SwitchTo().NewWindow(WindowType.Tab);
        this._driver.Navigate().GoToUrl("https://yopmail.com/");
        secondWindow = this._driver.CurrentWindowHandle;
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
    /// Метод генерации рандомного email
    /// </summary>

    public void GenerateNewEmail()
    {
        this._wait.Until(_driver => _driver.FindElement(_randomEmailButtonSelector).Displayed);
        AvoidAdvertisement();

        int maxAttempts = 2;
        int currentAttempt = 1;

        while (_driver.FindElements(_randomEmailButtonSelector).Count > 0 && currentAttempt <= maxAttempts)
        {
            this._actionBot.Click(_randomEmailButtonSelector);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            currentAttempt++;
        }

    }

    /// <summary>
    /// Метод переключения обратно на вкладку с рандомным email
    /// </summary>

    public void SwitchToEmailWindow()
    {
        this._driver.SwitchTo().Window(this.secondWindow);
    }
}