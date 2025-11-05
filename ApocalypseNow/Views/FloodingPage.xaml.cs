using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class FloodingPage : ContentPage
{
	public FloodingPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}