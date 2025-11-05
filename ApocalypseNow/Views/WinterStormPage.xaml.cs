using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class WinterStormPage : ContentPage
{
	public WinterStormPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}