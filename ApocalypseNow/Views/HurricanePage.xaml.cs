using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class HurricanePage : ContentPage
{
	public HurricanePage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}