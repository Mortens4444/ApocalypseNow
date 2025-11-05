using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class EconomicCrisisPage : ContentPage
{
	public EconomicCrisisPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}