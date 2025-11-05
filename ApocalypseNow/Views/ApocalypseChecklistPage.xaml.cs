using Mtf.LanguageService.MAUI;

namespace ApocalypseNow.Views;

public partial class ApocalypseChecklistPage : ContentPage
{
	public ApocalypseChecklistPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }

    private void OnAddToolbarClicked(object sender, EventArgs e)
    {

    }
}