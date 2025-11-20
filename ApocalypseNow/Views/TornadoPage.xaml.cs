using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class TornadoPage : ContentPage
{
	public TornadoPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}