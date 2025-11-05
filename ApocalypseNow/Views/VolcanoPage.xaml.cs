using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class VolcanoPage : ContentPage
{
	public VolcanoPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}