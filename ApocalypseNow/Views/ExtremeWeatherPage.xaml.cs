using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class ExtremeWeatherPage : ContentPage
{
	public ExtremeWeatherPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}