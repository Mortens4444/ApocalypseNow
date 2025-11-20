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

    [Description("Severe snowstorm, blizzard conditions")]
    WinterStorm = 10,

    [Description("Prolonged lack of precipitation / crop stress")]
    Drought = 11,

    [Description("Slope failure, debris flow")]
    Landslide = 12,

    [Description("Tsunami / large sea surge")]
    Tsunami = 13,

    [Description("Volcanic eruption and ashfall")]
    VolcanicEruption = 14,

    [Description("Rotating violent windstorm touching the ground")]
    Tornado = 15,

    [Description("AI takeover, rogue AI or alien invasion")]
    AITakeover = 16,

    [Description("Large-scale cyberattack or digital infrastructure collapse")]
    CyberCatastrophe = 17,

    [Description("Severe economic downturn or financial system failure")]
    EconomicCrisis = 18,

    [Description("Large accidental or intentional explosion")]
    Explosion = 19,

    [Description("Extreme weather event beyond normal conditions")]
    ExtreameWeather = 20,

    [Description("Severe tropical cyclone or hurricane")]
    Hurricane = 21,

    [Description("Widespread loss of internet connectivity")]
    InternetOutage = 22,

    [Description("Meteor impact or near-Earth object strike")]
    Meteor = 23,

    [Description("Widespread network failure or communication outage")]
    NetworkOutage = 24,

    [Description("Severe shortage of food supply")]
    Famine = 25
}
