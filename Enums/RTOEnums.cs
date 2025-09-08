namespace RTOAndrodAutomationFramework.Enums;

public enum RTOEnum
{
    InOffice,
    PTO
}

public static class RTOEnumPolicies
{
    public static Dictionary<RTOEnum, string> RTOPolicies = new Dictionary<RTOEnum, string>()
    {
        { RTOEnum.InOffice, "InOffice"},
        { RTOEnum.PTO, "PTO"},
    };
}