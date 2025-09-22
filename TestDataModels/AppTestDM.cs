namespace RTOAndrodAutomationFramework.TestDataModels;

//This is the data model class that each JSON file for AppTest is converted into.
public class DateInfoDataModel
{
    public required string Month { get; set; }
    public required string Day { get; set; }
    public required string TypeOfDay { get; set; }
}

public class Test01DM
{
    public required List<DateInfoDataModel> DateInfoDataModels { get; set; }
}