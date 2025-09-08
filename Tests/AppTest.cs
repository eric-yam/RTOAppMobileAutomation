using RTOAndrodAutomationFramework.Components;
using RTOAndrodAutomationFramework.Pages;
using RTOAndrodAutomationFramework.TestDataModels;
using RTOAndrodAutomationFramework.TestDataProvider;
using RTOAndrodAutomationFramework.Util;

namespace RTOAndrodAutomationFramework.Tests;

public class AppTest : BaseTest
{
    [Test]
    [TestCaseSource(typeof(AppTestDataProvider), nameof(AppTestDataProvider.Test_01_Mark_Dates_DP))]
    public void Test_01_Mark_Dates(Test01DM wf)
    {
        HomePage hp = new HomePage(_driver);
        DateTime startDate = hp.GetStartDate();
        DateTime endDate = hp.GetEndDate();

        //Calculate the total number of working days excluding the weekends and public holidays
        int totalWorkingDays = RTOCalculator.TotalWorkingWeekdays(startDate, endDate); //Calculated using library PublicHoliday

        Calendar calendar = hp.GetCalendar();

        if (wf.DateInfoDataModels != null)
        {
            foreach (var dateInfo in wf.DateInfoDataModels)
            {
                if (dateInfo.Month != null && dateInfo.Day != null && dateInfo.TypeOfDay != null)
                {
                    string? month = dateInfo.Month;
                    int day = Int32.Parse(dateInfo.Day);
                    string? typeOfDay = dateInfo.TypeOfDay;

                    calendar.SetDate(month, day, typeOfDay);

                }
            }
        }

        float result = (float)RTOCalculator.numDaysInOffice / totalWorkingDays * 100;
        string resultFormatted = result.ToString("F2");
        string expectedResult = hp.GetProgress();

        Assert.That(resultFormatted.Equals(expectedResult), Is.EqualTo(true));


        // string month = "October";
        // int day = 7;

        // calendar.SetDate(month, day, "InOffice");

        // month = "August";
        // day = 5;
        // calendar.SetDate(month, day, "PTO");

        // calendar.SetMonth(month);

        // calendar.MarkDayInOffice(2);
        // calendar.MarkDayInOffice(3);
        // calendar.MarkDayInOffice(4);
        // calendar.MarkDayInOffice(5);

        // float result = (float)RTOCalculator.numDaysInOffice / totalWorkingDays * 100;
        // string resultFormatted = result.ToString("F2");
        // string expectedResult = hp.GetProgress();

        // Assert.That(resultFormatted.Equals(expectedResult), Is.EqualTo(true));

        // calendar.UnmarkDay(2, "InOffice");
        // calendar.UnmarkDay(3, "InOffice");
        // calendar.UnmarkDay(4, "InOffice");
        // calendar.UnmarkDay(5, "InOffice");

        // result = (float)RTOCalculator.numDaysInOffice / totalWorkingDays * 100;
        // resultFormatted = result.ToString("F2");
        // expectedResult = hp.GetProgress();

        // Assert.That(resultFormatted.Equals(expectedResult), Is.EqualTo(true));

        //TODO: Include Month Parameter when marking PTO/In Office days

        //note that current example, June 1 -> September 30, there are 62 days excluding weekends and public holidays
    }
}