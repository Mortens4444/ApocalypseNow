using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class HeatwavesPage : ContentPage
{
	public HeatwavesPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}