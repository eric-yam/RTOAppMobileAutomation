using System.Text.Json;

namespace RTOAndrodAutomationFramework.TestDataProvider;

// This class is used to deserialize JSON objects into C# data model classes
public static class TestDataProvider
{
    public static IEnumerable<T> TestCaseDataProvider<T>(string jsonString)
    {
        T? deserializedObj = JsonSerializer.Deserialize<T>(jsonString);

        if (deserializedObj != null)
        {
            yield return deserializedObj;
        }
    }
}