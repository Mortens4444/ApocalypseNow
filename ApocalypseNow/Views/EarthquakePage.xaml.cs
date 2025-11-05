using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class EarthquakePage : ContentPage
{
	public EarthquakePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}