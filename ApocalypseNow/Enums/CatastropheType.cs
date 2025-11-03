using System.ComponentModel;

namespace ApocalypseNow.Enums;

public enum CatastropheType
{
    [Description("Severe flooding, rising water levels")]
    Flood = 1,
    [Description("Extreme heat, prolonged high temperatures")]
    HeatWave = 2,
    [Description("Large wildfires/brush fires")]
    Wildfire = 3,
    [Description("Ground shaking, building collapse")]
    Earthquake = 4,
    [Description("Widespread infectious disease outbreak")]
    Pandemic = 5,
    [Description("Hazardous chemical release")]
    ChemicalSpill = 6,
    [Description("Nuclear/radiological event")]
    Nuclear = 7,
    [Description("Armed conflict or war-related danger")]
    War = 8,
    [Description("Extended power outage / grid failure")]
    PowerOutage = 9,
    [Description("Severe storms, hurricanes, tornadoes")]
    Storm = 10,
    [Description("Prolonged lack of precipitation / crop stress")]
    Drought = 11,
    [Description("Slope failure, debris flow")]
    Landslide = 12,
    [Description("Tsunami / large sea surge")]
    Tsunami = 13,
    [Description("Volcanic eruption and ashfall")]
    VolcanicEruption = 14
}
