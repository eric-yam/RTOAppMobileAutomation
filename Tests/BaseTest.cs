using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using RTOAndrodAutomationFramework.Enums;

namespace RTOAndrodAutomationFramework.Tests;

public abstract class BaseTest
{
    private const string APP_PACKAGE = "appPackage";
    private const string APP_ACTIVITY = "appActivity";
    protected static AndroidDriver _driver;

    [SetUp]
    public void SetUp()
    {
        //Added TraversePath() flag to enable DotNetEnv to also search ancestor/descendant directories for .env file
        DotNetEnv.Env.TraversePath().Load();

        var appiumOptions = new AppiumOptions();
        // UiAutomator2Options options = new UiAutomator2Options();
        // OpenQA.Selenium.Appium.Android.UiAutomator2Options temp = new OpenQA.Selenium.Appium.Android.UiAutomator2Options();

        //Configure Appium options for session
        appiumOptions.PlatformName = Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.PlatformName]) ?? "Android";
        appiumOptions.DeviceName = Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.DeviceName]) ?? "emulator-5554";
        appiumOptions.AutomationName = Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.AutomationName]) ?? "UiAutomator2";

        //Configure app-specific capabilities
        //Open RTO Mobile App
        appiumOptions.AddAdditionalAppiumOption(APP_PACKAGE, Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.AppPackage]) ?? "");
        appiumOptions.AddAdditionalAppiumOption(APP_ACTIVITY, Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.AppActivity]) ?? "");

        // mCurrentFocus=Window{d839b u0 com.example.rtotracker/com.example.rtotracker.MainActivity}

        /*
            Configure Appium server URL.
            Note that "127.0.0.1:4723" is the default. 
        */
        // var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");        
        var appiumServerUrl = new Uri(Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.AppiumServerUrl]) ?? "http://127.0.0.1:4723");

        //Instantiate AndroidDriver
        int implicitwait = int.Parse(Environment.GetEnvironmentVariable(EnvCapabilitiesSetup.EnvironmentSetup[EnvironmentEnums.ImplicitWait]) ?? "10");
        _driver = new AndroidDriver(appiumServerUrl, appiumOptions);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitwait);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }
}
