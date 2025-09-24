using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using RTOAndrodAutomationFramework.Dialog;
using RTOAndrodAutomationFramework.Enums;
using RTOAndrodAutomationFramework.Util;

namespace RTOAndrodAutomationFramework.Components;

public class Calendar : BaseComponent
{
    private AppiumElement CalendarLocator() => this._driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.View\").instance(8)"));
    private AppiumElement PreviousMonthButton() => this._driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.View\").instance(4)"));
    private AppiumElement CurrentMonth() => this._driver.FindElement(MobileBy.XPath("//androidx.compose.ui.platform.ComposeView/android.view.View/android.view.View/android.view.View[3]//following-sibling::android.widget.TextView[1]"));
    private AppiumElement NextMonthButton() => this._driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.View\").instance(6)"));
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
    public void SetDate(string month, int day, string typeOfDay)
    {
        if (typeOfDay.Equals(RTOEnumPolicies.RTOPolicies[RTOEnum.InOffice]))
        {
            this.SetMonth(month);
            this.SetCalenderDaysList();
            this.MarkDayInOffice(day);
        }
        else if (typeOfDay.Equals(RTOEnumPolicies.RTOPolicies[RTOEnum.PTO]))
        {
            this.SetMonth(month);
            this.SetCalenderDaysList();
            this.MarkDayPTO(day);
        }
    }

    public void SetMonth(string month)
    {
        string currentMonth = this.CurrentMonth().Text.Substring(0, this.CurrentMonth().Text.IndexOf(" "));

        var currentMonthNumber = DateTime.ParseExact(currentMonth, "MMMM", null).Month;
        var expectedMonthNumber = DateTime.ParseExact(month, "MMMM", null).Month;

        while (currentMonthNumber != expectedMonthNumber)
        {
            if (currentMonthNumber > expectedMonthNumber)
            {
                this.PreviousMonthButton().Click();
                currentMonth = this.CurrentMonth().Text.Substring(0, this.CurrentMonth().Text.IndexOf(" "));
                currentMonthNumber = DateTime.ParseExact(currentMonth, "MMMM", null).Month;
            }
            else if (currentMonthNumber < expectedMonthNumber)
            {
                this.NextMonthButton().Click();
                currentMonth = this.CurrentMonth().Text.Substring(0, this.CurrentMonth().Text.IndexOf(" "));
                currentMonthNumber = DateTime.ParseExact(currentMonth, "MMMM", null).Month;
            }
            else
            {
                throw new Exception("Error with current month");
            }
        }
    }

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
        dateActionDialog.ClickMarkPTOButton();

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