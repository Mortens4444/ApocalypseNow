using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class ExplosionPage : ContentPage
{
	public ExplosionPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}