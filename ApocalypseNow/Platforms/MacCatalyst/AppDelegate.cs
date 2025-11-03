using Foundation;
using System.Runtime.Versioning;

namespace ApocalypseNow;

[Register("AppDelegate")]
internal class AppDelegate : MauiUIApplicationDelegate
{
    [SupportedOSPlatform("windows10.0.17763.0")]
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
