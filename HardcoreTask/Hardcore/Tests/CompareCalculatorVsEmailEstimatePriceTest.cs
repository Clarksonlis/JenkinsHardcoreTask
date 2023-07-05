using NUnit.Framework;
using OpenQA.Selenium;
using Hardcore.Tests.Pages;

namespace Hardcore.Tests.Tests;

[TestFixture]
[Category("SmokeTests")]
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


    /// <summary>
    /// Тест для сравнения цены из страницы Калькулятора и входящяего письма на странице рандомного email:
    /// 1. Открытие Google Cloud Search и переход на Google Cloud Platform Pricing Calculator
    /// 2. Заполнение формы COMPUTE ENGINE
    /// 3. Нажатие Add to Estimate и выбоп EMAIL ESTIMATE
    /// 4. Открытие в новой вкладке сервиса для генерации временных email'ов https://yopmail.com/
    /// 5. Копирование временного email и отправка письма на этот email
    /// 6. Проверка, совпадает ли стоимость
    /// </summary>

    [Test]
    public void CompareCalculatorVsEmailEstimatePriceTest()
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

    /// <summary>
    /// Метод для скриншота страницы и сохранения его в папку TestScreenshot
    /// </summary>

    public void TakeScreenshot()
    {
        Screenshot screenshot = takesScreenshot.GetScreenshot();
        string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestScreenshot");
        string fileName = $"Failure_{DateTime.Now:yyyyMMddHHmmss}.png";
        string filePath = Path.Combine(directoryPath, fileName);

        Directory.CreateDirectory(directoryPath);
        screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
    }
}