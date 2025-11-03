using System.ComponentModel;

namespace ApocalypseNow.Enums;

public enum PriorityLevel
{
    [Description("None / Optional")] None = 0,
    [Description("Very Low")] VeryLow = 1,
    [Description("Low")] Low = 2,
    [Description("Below Normal")] BelowNormal = 3,
    [Description("Normal")] Normal = 4,
    [Description("Above Normal")] AboveNormal = 5,
    [Description("Important")] Important = 6,
    [Description("High")] High = 7,
    [Description("Very High")] VeryHigh = 8,
    [Description("Critical")] Critical = 9,
    [Description("Emergency / Life Saving")] Emergency = 10,
    [Description("Top Priority / Vital")] Top = 11,
    [Description("Custom")] Custom = 100
}