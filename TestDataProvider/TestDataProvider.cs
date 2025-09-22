using System.Text.Json;

namespace RTOAndrodAutomationFramework.TestDataProvider;

// This class is used to deserialize JSON objects into C# data model classes
public static class TestDataProvider
{
    public static IEnumerable<T> TestCaseDataProvider<T>(string jsonString)
    {
        T? deserializedObj;
        try
        {
            deserializedObj = JsonSerializer.Deserialize<T>(jsonString);
        }
        catch (Exception e)
        {
            //In the case a required Data Model member is missing from the JSON file, an exception will be thrown.
            throw new Exception(e.Message);
        }

        if (deserializedObj != null)
        {
            yield return deserializedObj;
        }
    }
}