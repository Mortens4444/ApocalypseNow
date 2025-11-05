using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class ClimateChangePage : ContentPage
{
	public ClimateChangePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}