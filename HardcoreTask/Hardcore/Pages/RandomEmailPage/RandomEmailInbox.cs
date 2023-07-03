using OpenQA.Selenium;
using Hardcore.Tests.Bots;

namespace Hardcore.Tests.Pages;

public class RandomEmailInbox
{
    private IWebDriver _driver;
    private ActionBot _actionBot;

    // Определение элементов страницы
    private readonly By _checkNewEmailButtonSelector = By.CssSelector("button.md.but.text.f24.egenbut:last-child");
    private readonly By _emailInboxButtonSelector = By.CssSelector("iframe[name = 'ifinbox']");

    private readonly By _iframeInEmailSelector = By.CssSelector("iframe[name = 'ifmail']");
    private readonly By _costElementInEmailSelector = By.XPath("//h3[contains(text(),'USD')]");

    public RandomEmailInbox(IWebDriver driver, ActionBot actionBot)
    {
        this._actionBot = actionBot;
        this._driver = driver;
    }


    public void OpenEmailInbox()
    {
        this._actionBot.Click(_checkNewEmailButtonSelector);

        while (!this._driver.FindElement(_emailInboxButtonSelector).Displayed)
        {
            _driver.Navigate().Refresh();
        }
    }

    public string CheckTotalCostInEmail()
    {
        this._actionBot.SwitchToFrame(_iframeInEmailSelector);
        string costInEmail = this._actionBot.GetText(_costElementInEmailSelector);

        return costInEmail;
    }
}