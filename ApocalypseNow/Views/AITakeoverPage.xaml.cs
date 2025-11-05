using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

internal partial class AITakeoverPage : ContentPage
{
	public AITakeoverPage()
	{
		InitializeComponent();
		Translator.Translate(this);
	}
}