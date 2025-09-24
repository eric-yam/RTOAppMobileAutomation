using RTOAndrodAutomationFramework.TestDataModels;

namespace RTOAndrodAutomationFramework.TestDataProvider;
//This is the data provider class for AppTest test cases
//Used to locate the JSON file to be deserialized for individual test cases in AppTest test suite
public static class AppTestDataProvider
{
    public static IEnumerable<Test01DM> Test_01_Mark_Dates_DP()
    {
        string jsonString = File.ReadAllText("TestData\\AppTest\\test_01_mark_dates.json");
        return TestDataProvider.TestCaseDataProvider<Test01DM>(jsonString);
    }
}