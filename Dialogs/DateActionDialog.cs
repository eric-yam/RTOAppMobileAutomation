using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace RTOAndrodAutomationFramework.Dialog;

public class DateActionDialog : BaseDialog
{
    private AppiumElement MarkInOfficeButton() => this._driver.FindElement(MobileBy.XPath("//android.widget.TextView[@text=\"Mark In Office\"]//following-sibling::android.widget.Button"));
    private AppiumElement MarkPTOButton() => this._driver.FindElement(MobileBy.XPath("//android.widget.TextView[@text=\"Mark as PTO\"]//following-sibling::android.widget.Button"));
    private AppiumElement UnmarkDayButton() => this._driver.FindElement(MobileBy.XPath("//android.widget.TextView[@text=\"Unmark Day\"]//following-sibling::android.widget.Button"));
    private AppiumElement CancelButton() => this._driver.FindElement(MobileBy.XPath("//android.widget.TextView[@text=\"Cancel\"]//following-sibling::android.widget.Button"));

    public DateActionDialog(AndroidDriver driver) : base(driver) { }

    //Actions
    public void ClickMarkInOfficeButton() { this.MarkInOfficeButton().Click(); }
    public void ClickMarkPTOButton() { this.MarkPTOButton().Click(); }
    public void ClickUnmarkDayButton() { this.UnmarkDayButton().Click(); }
    public void ClickCancelButton() { this.CancelButton().Click(); }

}