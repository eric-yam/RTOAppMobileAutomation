# Introduction

https://docs.nunit.org/articles/nunit/getting-started/installation.html
https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-nunit

dotnet new nunit
dotnet add package Appium.WebDriver
dotnet add package PublicHoliday --version 3.9.0
#################################################################################

## Launch Emulator:

1. Navigate to the directory containing the emulator
   ex. \Local\Android\Sdk\emulator\
2. emulator -avd {Insert Name of Android Virtual Device}

Note that you can list all the emulators installed on your machine with:

- emulator -list-avds

#################################################################################

## Setup AppiumOptions

- AppiumOptions is the Parent class, set any Appium capability
- Note that UiAutomator2Options is a subclass of AppiumOptions, specifically for Android capabilities
  HOWEVER, it seems like it is not available for C#, therefore we will continue using AppiumOptions even though its more generic.
  The only drawback is that each Android capability requires the property to be manually written as a string instead.
  Ex.

  - AppiumOptions: appiumOptions.AddAdditionalAppiumOption("appPackage", "com.google.android.documentsui");
  - UiAutomator2Options: options.AppPackage = "com.google.android.documentsui";

- In AppiumOptions, PlatformName, AutomationName, and DeviceName are capabilities that are built in.
  PlatformName and AutomationName are always required.

- When using AppiumOptions, the method, AddAdditionalAppiumOption(), can be used to provide additional
  capabilities to AppiumOptions in the case AppiumOptions does not have a property available for a specific capability.

Ex. there is no property for appPackage in AppiumProperties, therefore we would use AddAdditionalAppiumOption()
to add this capability using string.

    - appiumOptions.AddAdditionalAppiumOption("appPackage", "com.google.android.documentsui");

Example AppiumOptions Configuration:

appiumOptions.PlatformName = "Andoid";
appiumOptions.DeviceName = "emulator-5554";
appiumOptions.AutomationName = "UiAutomator2";

- Device name is found using the CMD Prompt
  - Navigate emulator direcotry
  - Type in adb devices
  - A list of devices attached is displayed
- Platform is defined by the type of application being tested. Can be Android, IOS, Windows App.
- Each Platform name has a corresponding Automation Name
  - Android -> UiAUtomator2
  - IOS -> XCUITest
  - WindowsApp -> Windows

## Get Android Application To Launch In Emulator:

Source : https://www.automationtestinghub.com/apppackage-and-appactivity-name/
https://www.youtube.com/watch?v=jqTZj0Ky7Hs

- Open Emulator
- Open APK within Emulator
- In Terminal Execute commands
  - adb shell
  - dumpsys window displays | grep -E 'mCurrentFocus'
- This should return something similar to :
  mCurrentFocus=Window{6508e98 u0 com.google.android.apps.nexuslauncher/com.google.android.apps.nexuslauncher.NexusLauncherActivity}

- This is denoted as:
  mCurrentFocus=Window{6508e98 u0 {appPackage IS HERE }/{appActivity IS HERE}}

#################################################################################

## csproj File Setup:

- Modified the <ItemGroup> in csproj with:
  <None Update="TestData\**\*.json">
  <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
- During build, now the resource files located in TestData, will also be copied into the Output directory (bin/Debug/net9.0)
- Therefore, in the TestDataProvider classes, when we specify the path to where the TestData is located, we only need
  the relative path (to this RTO project) to the test data rather than including the full absolute path.
