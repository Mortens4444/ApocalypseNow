using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class BagPage : ContentPage
{
	public BagPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}