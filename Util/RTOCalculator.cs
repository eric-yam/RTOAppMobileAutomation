using PublicHoliday;
using RTOAndrodAutomationFramework.Enums;

namespace RTOAndrodAutomationFramework.Util;

public static class RTOCalculator
{
    public static int numDaysInOffice = 0;
    public static int numDaysPTO = 0;

    public static int TotalWorkingWeekdays(DateTime startDate, DateTime endDate)
    {

        return new CanadaPublicHoliday().BusinessDaysBetween(startDate, endDate);
        // new CanadaPublicHoliday().BusinessDaysAdd()

        // int totalDays = 0;
        // for (int i = startDate.Month; i < endDate.Month; i++)
        // {
        //     //Count the weekdays
        //     totalDays += DateTime.DaysInMonth(startDate.Year, i);

        // }

        //subtract the weekdays with the public holiday

        // return -1;
    }

    public static void IncrementNumDaysInOffice()
    {
        numDaysInOffice++;
    }

    public static void IncrementNumDaysPTO()
    {
        numDaysPTO++;
    }

    public static void DecrementDays(string dayToDecrement)
    {
        if (dayToDecrement.Equals(RTOEnumPolicies.RTOPolicies[RTOEnum.InOffice]))
        {
            numDaysInOffice--;
        }
        else if (dayToDecrement.Equals(RTOEnumPolicies.RTOPolicies[RTOEnum.PTO]))
        {
            numDaysPTO--;
        }
    }

    public static string GetProgressPercentage(int totalWorkingDays)
    {
        float result = (float)numDaysInOffice / (totalWorkingDays - numDaysPTO) * 100;
        return result.ToString("F2");
    }
}