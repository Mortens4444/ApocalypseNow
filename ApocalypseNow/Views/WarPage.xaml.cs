using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class WarPage : ContentPage
{
	public WarPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}