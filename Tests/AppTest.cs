using RTOAndrodAutomationFramework.Components;
using RTOAndrodAutomationFramework.Dialog;
using RTOAndrodAutomationFramework.Pages;
using RTOAndrodAutomationFramework.Util;

namespace RTOAndrodAutomationFramework.Tests;

public class AppTest : BaseTest
{
    [Test]
    public void Test_1()
    {
        HomePage hp = new HomePage(_driver);
        DateTime startDate = hp.GetStartDate();
        DateTime endDate = hp.GetEndDate();

        int totalWorkingDays = RTOCalculator.TotalWorkingWeekdays(startDate, endDate); //Calculated using library PublicHoliday

        Calendar calendar = hp.GetCalendar();
        calendar.MarkDayInOffice(2);
        calendar.MarkDayInOffice(3);
        calendar.MarkDayInOffice(4);
        calendar.MarkDayInOffice(5);

        float result = (float)RTOCalculator.numDaysInOffice / totalWorkingDays * 100;
        string resultFormatted = result.ToString("F2");
        string expectedResult = hp.GetProgress();

        Assert.That(resultFormatted.Equals(expectedResult), Is.EqualTo(true));

        calendar.UnmarkDay(2, "InOffice");
        calendar.UnmarkDay(3, "InOffice");
        calendar.UnmarkDay(4, "InOffice");
        calendar.UnmarkDay(5, "InOffice");

        result = (float)RTOCalculator.numDaysInOffice / totalWorkingDays * 100;
        resultFormatted = result.ToString("F2");
        expectedResult = hp.GetProgress();

        Assert.That(resultFormatted.Equals(expectedResult), Is.EqualTo(true));

        //TODO: Include Month Parameter when marking PTO/In Office days

        //note that current example, June 1 -> September 30, there are 62 days excluding weekends and public holidays
    }
}