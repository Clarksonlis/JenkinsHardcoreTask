using OpenQA.Selenium;
using Hardcore.Tests.Bots;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Emit;

namespace Hardcore.Tests.Pages;

public class EstimateForm
{
    private DefaultWait<IWebDriver> _wait;
    private ActionBot _actionBot;

    // Определение элементов страницы
    private readonly By _costElementInCalculatorSelector = By.CssSelector(".cpc-cart-total b");
    private readonly By _emailEstimateButtonSelector = By.CssSelector("button[title='Email Estimate']");
    private readonly By _emailFieldSelector = By.CssSelector("input[type='email']");
    private readonly By _sendEmailButtonSelector = By.CssSelector("form[name = 'emailForm'] button.md-raised.md-primary.cpc-button");

    public EstimateForm(DefaultWait<IWebDriver> wait, ActionBot actionBot)
    {
        this._wait = wait;
        this._actionBot = actionBot;
    }


    public void EmailEstimate()
    {
        this._actionBot.Click(_emailEstimateButtonSelector);
    }

    public void PasteNewEmail()
    {
        this._actionBot.Click(_emailFieldSelector);
        this._actionBot.PasteFromClipboard(_emailFieldSelector);
    }

    public void SendEmail()
    {
        this._actionBot.Click(_sendEmailButtonSelector);
    }

    public void SendCostOnNewEmail()
    {
        PasteNewEmail();
        SendEmail();
    }

    public string CheckTotalCostInCalculator()
    {
        this._wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[aria-label = 'Email Estiamte']")));

        string fullText = this._actionBot.GetText(_costElementInCalculatorSelector);

        // Используем методы строки для извлечения нужной части текста
        int startIndex = fullText.IndexOf("USD"); // Индекс символа после "USD"
        int endIndex = fullText.IndexOf("per"); // Индекс символа перед "per"
        string costInCalculator = fullText.Substring(startIndex, endIndex - startIndex).Trim();

        return costInCalculator;
    }
}