using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class FaminePage : ContentPage
{
	public FaminePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}