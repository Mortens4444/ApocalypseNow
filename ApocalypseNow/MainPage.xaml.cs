using Mtf.Extensions;
using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.Extensions;
using Mtf.LanguageService.MAUI;
using System.Diagnostics;

namespace ApocalypseNow;

internal partial class MainPage : ContentPage
{
    private Dictionary<object, string> originalTextElements;

    public MainPage()
    {
        InitializeComponent();

        var languages = Enum.GetValues<ImplementedLanguage>().Cast<ImplementedLanguage>()
            .OrderBy(l => l.GetDescription())
            .ToList();
        foreach (var lang in languages)
        {
            LanguagePicker.Items.Add(lang.GetDescription());
        }
        LanguagePicker.SelectedIndex = languages.IndexOf(Lng.DefaultLanguage.ToImplementedLanguage());

        LanguagePicker.SelectedIndexChanged += (s, e) =>
        {
            var selected = languages[LanguagePicker.SelectedIndex];
            Lng.DefaultLanguage = selected.ToLanguage();
            if (originalTextElements != null)
            {
                Translator.SetOriginalTexts(originalTextElements);
            }
            originalTextElements = Translator.Translate(this);
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            originalTextElements = Translator.Translate(this);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Translate error: {ex}");
        }
    }
}
