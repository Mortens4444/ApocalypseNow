using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class CyberCatastrophePage : ContentPage
{
	public CyberCatastrophePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}