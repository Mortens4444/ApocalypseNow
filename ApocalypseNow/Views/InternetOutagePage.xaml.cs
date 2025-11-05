using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class InternetOutagePage : ContentPage
{
	public InternetOutagePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}