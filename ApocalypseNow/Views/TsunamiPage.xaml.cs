using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class TsunamiPage : ContentPage
{
	public TsunamiPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}