using RTOAndrodAutomationFramework.TestDataModels;

namespace RTOAndrodAutomationFramework.TestDataProvider;

//This class is used to locate the JSON file to be deserialized for individual test cases
public static class AppTestDataProvider
{
    public static IEnumerable<Test01DM> Test_01_Mark_Dates_DP()
    {
        string jsonString = File.ReadAllText("C:\\Users\\Eric\\Documents\\vscode-repos\\RTOAndrodAutomationFramework\\TestData\\AppTest\\test_01_mark_dates.json");
        return TestDataProvider.TestCaseDataProvider<Test01DM>(jsonString);
    }
}