using OpenQA.Selenium;
using Hardcore.Tests.Bots;

namespace Hardcore.Tests.Pages;

public class GoogleCloudSearchResultPage
{
    private ActionBot _actionBot;

    // Элементы страницы
    private readonly By _сalculatorLinkSelector = By.CssSelector(".gsc-thumbnail-inside a[data-ctorig='https://cloud.google.com/products/calculator']");

    public GoogleCloudSearchResultPage(ActionBot actionBot)
    {
        this._actionBot = actionBot;
    }

    /// <summary>
    /// Метод перехода на ссылку Калькулятора:
    /// </summary>

    public void ClickСalculatorLink()
    {
        this._actionBot.Click(_сalculatorLinkSelector);
    }
}