using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class WildfirePage : ContentPage
{
	public WildfirePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}