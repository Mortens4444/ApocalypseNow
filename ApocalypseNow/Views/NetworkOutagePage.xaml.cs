using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class NetworkOutagePage : ContentPage
{
	public NetworkOutagePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}