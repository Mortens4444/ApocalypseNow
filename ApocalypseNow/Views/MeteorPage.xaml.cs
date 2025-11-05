using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class MeteorPage : ContentPage
{
	public MeteorPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}