using OpenQA.Selenium.Appium.Android;

namespace RTOAndrodAutomationFramework.Pages;

public abstract class BasePage
{
    protected AndroidDriver _driver;

    public BasePage(AndroidDriver driver)
    {
        this._driver = driver;
    }
}