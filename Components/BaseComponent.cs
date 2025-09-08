using OpenQA.Selenium.Appium.Android;

namespace RTOAndrodAutomationFramework.Components;

public abstract class BaseComponent
{
    protected AndroidDriver _driver;

    public BaseComponent(AndroidDriver driver)
    {
        this._driver = driver;
    }
}