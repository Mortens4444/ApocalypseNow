using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class NuclearPage : ContentPage
{
	public NuclearPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}