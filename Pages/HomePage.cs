using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using RTOAndrodAutomationFramework.Components;

namespace RTOAndrodAutomationFramework.Pages;

public class HomePage : BasePage
{
    private AppiumElement StartDateFilter() => this._driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.View\").instance(2)"));
    private AppiumElement EndDateFilter() => this._driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.View\").instance(3)"));
    private AppiumElement ProgressIndicator() => this._driver.FindElement(MobileBy.XPath("//android.widget.TextView[@text=\"Your Progress:\"]//following-sibling::android.widget.TextView[contains(@text, \"%\")]"));
    private AppiumElement DaysRequired() => this._driver.FindElement(MobileBy.XPath("//android.widget.TextView[contains(@text, \"You need to attend\")]"));

    private Calendar calendar;

    //Constructor
    public HomePage(AndroidDriver driver) : base(driver)
    {
        this.calendar = new Calendar(driver);
    }

    public string GetProgress()
    {
        //Return progress omitting the percent character
        return this.ProgressIndicator().Text.Replace("%", "");
    }

    public string GetDaysRequired()
    {
        return this.DaysRequired().Text;
    }

    public Calendar GetCalendar()
    {
        return this.calendar;
    }

    public DateTime GetStartDate()
    {
        string startTime = this.StartDateFilter().FindElement(MobileBy.ClassName("android.widget.TextView")).Text;
        return DateTime.Parse(startTime.Replace("Start: ", "")); //TODO: Factor out as constants
    }

    public DateTime GetEndDate()
    {
        string endDate = this.EndDateFilter().FindElement(MobileBy.ClassName("android.widget.TextView")).Text;
        return DateTime.Parse(endDate.Replace("End: ", ""));
    }

    //Actions
    public void ClickStartDateFilter() { this.StartDateFilter().Click(); }
    public void ClickEndDateFilter() { this.EndDateFilter().Click(); }
}