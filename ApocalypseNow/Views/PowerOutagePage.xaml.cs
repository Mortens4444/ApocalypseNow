using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class PowerOutagePage : ContentPage
{
	public PowerOutagePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}