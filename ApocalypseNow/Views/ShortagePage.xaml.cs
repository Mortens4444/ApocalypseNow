using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class ShortagePage : ContentPage
{
	public ShortagePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}