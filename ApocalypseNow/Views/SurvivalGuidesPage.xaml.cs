using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class SurvivalGuidesPage : ContentPage
{
	public SurvivalGuidesPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}