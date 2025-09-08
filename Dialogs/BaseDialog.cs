using OpenQA.Selenium.Appium.Android;

namespace RTOAndrodAutomationFramework.Dialog;

public abstract class BaseDialog
{
    protected AndroidDriver _driver;

    public BaseDialog(AndroidDriver driver)
    {
        this._driver = driver;
    }
}