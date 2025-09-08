using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace RTOAndrodAutomationFramework.Tests;

public abstract class BaseTest
{
    protected static AndroidDriver _driver;

    [SetUp]
    public void SetUp()
    {
        //TODO: Factor out hard coded AppiumOption values into external environment file
        var appiumOptions = new AppiumOptions();
        // UiAutomator2Options options = new UiAutomator2Options();
        // OpenQA.Selenium.Appium.Android.UiAutomator2Options temp = new OpenQA.Selenium.Appium.Android.UiAutomator2Options();

        //Configure Appium options for session
        appiumOptions.PlatformName = "Android";
        appiumOptions.DeviceName = "emulator-5554";
        appiumOptions.AutomationName = "UiAutomator2";

        //Configure app-specific capabilities
        //Open RTO Mobile App
        appiumOptions.AddAdditionalAppiumOption("appPackage", "com.example.rtotracker");
        appiumOptions.AddAdditionalAppiumOption("appActivity", "com.example.rtotracker.MainActivity");

        // mCurrentFocus=Window{d839b u0 com.example.rtotracker/com.example.rtotracker.MainActivity}

        /*
            Configure Appium server URL.
            Note that "127.0.0.1:4723" is the default. 
        */
        // var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
        var appiumServerUrl = new Uri("http://127.0.0.1:4723");

        //Instantiate AndroidDriver
        _driver = new AndroidDriver(appiumServerUrl, appiumOptions);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }
}
