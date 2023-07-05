using OpenQA.Selenium;
using Hardcore.Tests.Bots;

namespace Hardcore.Tests.Pages;

public class GoogleCloudStartPage
{
    private IWebDriver _driver;
    private ActionBot _actionBot;
    private string originalWindow;

    // Элементы страницы 
    private readonly By _searchButtonSelector = By.CssSelector(".devsite-search-form");
    private readonly By _searchFieldSelector = By.CssSelector("input[aria-label='Search']");

    public GoogleCloudStartPage(IWebDriver driver, ActionBot actionBot)
    {
        this._driver = driver;
        this._actionBot = actionBot;
        this.originalWindow = _driver.CurrentWindowHandle;
    }


    /// <summary>
    /// Методы поиска страницы в Google Cloud Search:
    /// 1.Переход на страницу Google Cloud Search
    /// 2.Нажадие кнопни поиска
    /// 3.Ввод поисковых данных и submit
    /// всё вместе собрано в метод SearchPricingCalculator()
    /// отдельный метод SwitchToCalculatortWindow() для переключения обратно на вкладку Калькулятора
    /// </summary>

    public void OpenGoogleCloudPage()
    {
        _driver.Navigate().GoToUrl("https://cloud.google.com/");
    }

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