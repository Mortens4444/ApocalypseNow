using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class PandemicPage : ContentPage
{
	public PandemicPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}