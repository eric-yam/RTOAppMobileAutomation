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
        
        foreach (var dateInfo in wf.DateInfoDataModels)
        {
            if (dateInfo.Month != null && dateInfo.Day != null && dateInfo.TypeOfDay != null)
            {
                string? month = dateInfo.Month;
                int day = int.Parse(dateInfo.Day);
                string? typeOfDay = dateInfo.TypeOfDay;

                calendar.SetDate(month, day, typeOfDay);

            }               
        }

        string result = RTOCalculator.GetProgressPercentage(totalWorkingDays);
        string expectedResult = hp.GetProgress();

        Assert.That(result.Equals(expectedResult), Is.EqualTo(true));
        //TODO: Include Month Parameter when marking PTO/In Office days

        //note that current example, June 1 -> September 30, there are 62 days excluding weekends and public holidays
    }
}