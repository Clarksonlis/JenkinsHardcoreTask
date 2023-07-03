using OpenQA.Selenium;
using Hardcore.Tests.Bots;

namespace Hardcore.Tests.Pages;

public class ComputeEngineForm
{
    private ActionBot _actionBot;

    /// Определение элементов страницы
    // IFrames
    private readonly By _iframeParentSelector = By.XPath("//devsite-iframe/iframe");
    private readonly By _iframeChildSelector = By.Id("myFrame");

    //Элементы
    private readonly By _computeEngineButtonSelector = By.CssSelector("#tab-item-1 .presets-buttons");

    private readonly By _numberOfInstancesInputFieldSelector = By.Id("input_97");

    private readonly By _operatingSystemOptionFieldSelector = By.Id("select_110");
    private readonly By _operatingSystemOptionFreeSelector = By.Id("select_option_99");

    private readonly By _vmClassOptionSelector = By.Id("select_114");
    private readonly By _vmClassOptionRegularSelector = By.Id("select_option_112");

    private readonly By _instanceSerieOptionSelector = By.Id("select_122");
    private readonly By _instanceSerieOptionN1Selector = By.Id("select_option_213");

    private readonly By _instanceMachineTypeOptionSelector = By.Id("select_124");
    private readonly By _instanceTypeOptionN1Standard8Selector = By.Id("select_option_453");

    private readonly By _addGPUsCheckboxSelector = By.CssSelector("md-checkbox[ng-model='listingCtrl.computeServer.addGPUs']");
    private readonly By _gpuTypeOptionSelector = By.CssSelector("[placeholder='GPU type']");
    private readonly By _gpuTypeOptionNVIDIATeslaV100Selector = By.CssSelector("[value='NVIDIA_TESLA_V100']");
    private readonly By _numberOfGPUsOptionSelector = By.CssSelector("[placeholder='Number of GPUs']");
    private readonly By _numberOfGPUsOption1Selector = By.Id("select_option_499");

    private readonly By _localSSDOptionSelector = By.Id("select_448");
    private readonly By _localSSDOption2x375GBSelector = By.Id("select_option_474");

    private readonly By _datacenterLocationOptionSelector = By.Id("select_130");
    private readonly By _datacenterLocationOptionFrankfurtSelector = By.Id("select_option_255");

    private readonly By _committedUsageOptionSelector = By.Id("select_137");
    private readonly By _committedUsageOption1YearSelector = By.Id("select_option_135");

    private readonly By _addToEstimateButtonSelector = By.CssSelector("button[ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']");


    public ComputeEngineForm(ActionBot actionBot)
    {
        this._actionBot = actionBot;
    }


    //Методы выбора формы
    public void SwitchToComputeEngineFrame()
    {
        this._actionBot.SwitchToFrame(_iframeParentSelector);
        this._actionBot.SwitchToFrame(_iframeChildSelector);
    }

    public void ClickComputerEngineTab()
    {
        this._actionBot.Click(_computeEngineButtonSelector);
    }

    public void ChooseCalculatorForm()
    {
        SwitchToComputeEngineFrame();
        ClickComputerEngineTab();
    }

    //Методы заполнения формы

    public void FillNumberOfInstancesField()
    {
        this._actionBot.Type(_numberOfInstancesInputFieldSelector, "4");
    }

    public void SelectOperatingSystemOption()
    {
        this._actionBot.Click(_operatingSystemOptionFieldSelector);
        this._actionBot.Click(_operatingSystemOptionFreeSelector);
    }

    public void SelectVmClassOption()
    {
        this._actionBot.Click(_vmClassOptionSelector);
        this._actionBot.Click(_vmClassOptionRegularSelector);
    }

    public void SelectInstanceSerieOption()
    {
        this._actionBot.Click(_instanceSerieOptionSelector);
        this._actionBot.Click(_instanceSerieOptionN1Selector);
    }

    public void SelectInstanceMachineTypeOption()
    {
        this._actionBot.Click(_instanceMachineTypeOptionSelector);
        this._actionBot.Click(_instanceTypeOptionN1Standard8Selector);
    }

    public void FillGPUsCheckbox()
    {
        this._actionBot.Click(_addGPUsCheckboxSelector);
        this._actionBot.Click(_gpuTypeOptionSelector);
        this._actionBot.Click(_gpuTypeOptionNVIDIATeslaV100Selector);
        this._actionBot.Click(_numberOfGPUsOptionSelector);
        this._actionBot.Click(_numberOfGPUsOption1Selector);
    }

    public void SelectLocalSSDOption()
    {
        this._actionBot.Click(_localSSDOptionSelector);
        this._actionBot.Click(_localSSDOption2x375GBSelector);
    }

    public void SelectDatacenterLocationOption()
    {
        this._actionBot.Click(_datacenterLocationOptionSelector);
        this._actionBot.Click(_datacenterLocationOptionFrankfurtSelector);
    }

    public void SelectCommittedUsageOption()
    {
        this._actionBot.Click(_committedUsageOptionSelector);
        this._actionBot.Click(_committedUsageOption1YearSelector);
    }

    public void AddToEstimate()
    {
        this._actionBot.Click(_addToEstimateButtonSelector);
    }

    public void FillForm()
    {
        FillNumberOfInstancesField();
        SelectOperatingSystemOption();
        SelectVmClassOption();
        SelectInstanceSerieOption();
        SelectInstanceMachineTypeOption();
        FillGPUsCheckbox();
        SelectLocalSSDOption();
        SelectDatacenterLocationOption();
        SelectCommittedUsageOption();
        AddToEstimate();
    }
}