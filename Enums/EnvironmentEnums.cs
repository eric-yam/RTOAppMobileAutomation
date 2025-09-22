namespace RTOAndrodAutomationFramework.Enums;
public enum EnvironmentEnums
{
    AppiumServerUrl,
    ImplicitWait,
    PlatformName,
    DeviceName,
    AutomationName,
    AppPackage,
    AppActivity
}

public static class EnvCapabilitiesSetup
{
    public static Dictionary<EnvironmentEnums, string> EnvironmentSetup = new Dictionary<EnvironmentEnums, string>()
    {
        { EnvironmentEnums.AppiumServerUrl, "APPIUM_SERVER"},
        { EnvironmentEnums.ImplicitWait,    "IMPLICIT_WAIT"},
        { EnvironmentEnums.PlatformName,    "PLATFORM_NAME"},
        { EnvironmentEnums.DeviceName,      "DEVICE_NAME"},
        { EnvironmentEnums.AutomationName,  "AUTOMATION_NAME"},
        { EnvironmentEnums.AppPackage,      "APP_PACKAGE"},
        { EnvironmentEnums.AppActivity,     "APP_ACTIVITY"}
    };
}