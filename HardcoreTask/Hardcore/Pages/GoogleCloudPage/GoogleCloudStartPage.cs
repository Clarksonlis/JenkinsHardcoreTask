using OpenQA.Selenium;
using Hardcore.Tests.Bots;

namespace Hardcore.Tests.Pages;

public class GoogleCloudStartPage
{
    private IWebDriver _driver;
    private ActionBot _actionBot;
    private string originalWindow;

    // Определение элементов страницы
    private readonly By _searchButtonSelector = By.CssSelector(".devsite-search-form");
    private readonly By _searchFieldSelector = By.CssSelector("input[aria-label='Search']");

    public GoogleCloudStartPage(IWebDriver driver, ActionBot actionBot)
    {
        this._driver = driver;
        this._actionBot = actionBot;
        this.originalWindow = _driver.CurrentWindowHandle;

    }


    public void OpenGoogleCloudPage()
    {
        _driver.Navigate().GoToUrl("https://cloud.google.com/");
    }

    //Методы поиска страницы

    public void ClickSearchButton()
    {
        this._actionBot.Click(_searchButtonSelector);
    }

    public void FillSearchField()
    {
        this._actionBot.Type(_searchFieldSelector, "Google Cloud Platform Pricing Calculator");
        this._actionBot.Submit(_searchFieldSelector);
    }

    public void SearchPricingCalculator()
    {
        OpenGoogleCloudPage();
        ClickSearchButton();
        FillSearchField();
    }

    public void SwitchToCalculatortWindow()
    {
        _driver.SwitchTo().Window(this.originalWindow);
    }
}