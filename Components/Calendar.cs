using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using RTOAndrodAutomationFramework.Dialog;
using RTOAndrodAutomationFramework.Util;

namespace RTOAndrodAutomationFramework.Components;

public class Calendar : BaseComponent
{
    private AppiumElement CalendarLocator() => this._driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.View\").instance(8)"));
    private List<AppiumElement> CalendarDaysList;

    public Calendar(AndroidDriver driver) : base(driver)
    {
        this.CalendarDaysList = new List<AppiumElement>();
        this.SetCalenderDaysList();
    }

    public void SetCalenderDaysList()
    {
        this.CalendarDaysList = this.CalendarLocator().FindElements(MobileBy.ClassName("android.view.View")).ToList();
    }

    public List<AppiumElement> GetCalendarDaysList()
    {
        return CalendarDaysList;
    }

    //Actions
    //TODO: Revisit, need to specify day and month
    public void MarkDayInOffice(int day)
    {
        this.ClickDay(day);

        DateActionDialog dateActionDialog = new DateActionDialog(this._driver);
        dateActionDialog.ClickMarkInOfficeButton();

        RTOCalculator.IncrementNumDaysInOffice();
    }

    public void MarkDayPTO(int day)
    {
        this.ClickDay(day);

        DateActionDialog dateActionDialog = new DateActionDialog(this._driver);
        dateActionDialog.ClickMarkInOfficeButton();

        RTOCalculator.IncrementNumDaysPTO();
    }

    public void UnmarkDay(int day, string dayToDecrement)
    {
        this.ClickDay(day);

        DateActionDialog dateActionDialog = new DateActionDialog(this._driver);
        dateActionDialog.ClickUnmarkDayButton();

        RTOCalculator.DecrementDays(dayToDecrement);
    }

    public void ClickDay(int day)
    {
        //Convert day integer into list index
        this.CalendarDaysList[day - 1].Click(); //TODO: Factor out magic number
    }
}