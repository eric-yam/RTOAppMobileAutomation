namespace RTOAndrodAutomationFramework.TestDataModels;

//This is the data model class that each JSON file for AppTest is converted into.
public class DateInfoDataModel
{
    public string? Month { get; set; }
    public string? Day { get; set; }
    public string? TypeOfDay { get; set; }
}

public class Test01DM
{
    public List<DateInfoDataModel>? DateInfoDataModels { get; set; }
}