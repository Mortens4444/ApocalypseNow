using Mtf.LanguageService;

namespace ApocalypseNow.Services;

internal static class FlashlightService
{
    public static async Task TurnOnAsync(Page page)
    {
        try
        {
            await Flashlight.Default.TurnOnAsync().ConfigureAwait(false);
        }
        catch (FeatureNotSupportedException)
        {
            await page.DisplayAlert(Lng.Elem("Error"), Lng.Elem("Flashlight not supported on this device."), Lng.Elem("OK")).ConfigureAwait(true);
        }
        catch (PermissionException)
        {
            await page.DisplayAlert(Lng.Elem("Error"), Lng.Elem("No permission to access flashlight."), Lng.Elem("OK")).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            await page.DisplayAlert(Lng.Elem("Error"), ex.Message, Lng.Elem("OK")).ConfigureAwait(true);
        }
    }

    public static async Task TurnOffAsync(Page page)
    {
        try
        {
            await Flashlight.Default.TurnOffAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await page.DisplayAlert(Lng.Elem("Error"), ex.Message, Lng.Elem("OK")).ConfigureAwait(true);
        }
    }
}
