using NUnit.Framework;
using OpenQA.Selenium;
using Hardcore.Tests.Pages;

namespace Hardcore.Tests.Tests;

[TestFixture]
public class HardcoreTests : BaseTestClass
{
    private GoogleCloudStartPage googleCloudStartPage;
    private GoogleCloudSearchResultPage googleCloudSearchResultPage;
    private ComputeEngineForm computeEngineForm;
    private EstimateForm estimateForm;
    private RandomEmailPage randomEmailPage;
    private NewRandomEmailPage newRandomEmailPage;
    private RandomEmailInbox randomEmailInbox;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        // Инициализация WebDriver 
        googleCloudStartPage = new GoogleCloudStartPage(_driver, _actionBot);
        googleCloudSearchResultPage = new GoogleCloudSearchResultPage(_actionBot);
        computeEngineForm = new ComputeEngineForm(_actionBot);
        estimateForm = new EstimateForm(_wait, _actionBot);
        randomEmailPage = new RandomEmailPage(_driver, _wait, _actionBot);
        newRandomEmailPage = new NewRandomEmailPage(_driver, _wait, _actionBot);
        randomEmailInbox = new RandomEmailInbox(_driver, _actionBot);
    }

    [TearDown]
    public override void TearDown()
    {
        base.TearDown();
    }

    [Test]
    public void CalculatePriceAndCompareWithPriceInEmailTest()
    {
        try
        {
            googleCloudStartPage.SearchPricingCalculator();
            googleCloudSearchResultPage.ClickСalculatorLink();

            computeEngineForm.ChooseCalculatorForm();

            computeEngineForm.FillForm();
            estimateForm.EmailEstimate();

            randomEmailPage.OpenNewWindow();
            randomEmailPage.GenerateNewEmail();
            newRandomEmailPage.CopyNewRandomEmail();

            googleCloudStartPage.SwitchToCalculatortWindow();
            computeEngineForm.SwitchToComputeEngineFrame();
            estimateForm.SendCostOnNewEmail();
            string costFromCalculator = estimateForm.CheckTotalCostInCalculator();

            randomEmailPage.SwitchToEmailWindow();
            randomEmailInbox.OpenEmailInbox();

            string costFromEmail = randomEmailInbox.CheckTotalCostInEmail();

            Assert.AreEqual(costFromCalculator, costFromEmail, "The cost doesn't match.");
        }

        catch (Exception ex)
        {
            TakeScreenshot();
            throw new Exception("Exception with screenshot", ex);
        }
    }

    public void TakeScreenshot()
    {
        Screenshot screenshot = takesScreenshot.GetScreenshot();
        string fileName = $"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
        screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
    }
}