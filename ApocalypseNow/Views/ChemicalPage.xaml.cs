using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class ChemicalPage : ContentPage
{
	public ChemicalPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}