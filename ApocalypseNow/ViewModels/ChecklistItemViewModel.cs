using ApocalypseNow.Data;
using ApocalypseNow.Enums;
using ApocalypseNow.Models;
using Mtf.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ApocalypseNow.ViewModels;

internal partial class ChecklistItemViewModel : INotifyPropertyChanged
{
    readonly ChecklistRepository repo = new();
    readonly ChecklistItem model;

    public ChecklistItemViewModel(ChecklistItem m)
    {
        model = m ?? throw new ArgumentNullException(nameof(m));
        Quantity = model.Quantity;
        Unit = model.Unit ?? String.Empty;
        IsChecked = model.IsChecked;
        Title = model.Title ?? String.Empty;
        // set SelectedPriorityItem from numeric Priority (match enum value if possible)
        selectedPriorityItem = PriorityToDisplayItem(model.Priority);
        ManualPriority = model.Priority;
    }

    // exposed fields for binding
    public string Title { get; set; }
    public bool IsChecked { get; set; }
    public string Quantity { get; set; }
    public string Unit { get; set; }

    // Manual numeric override (used when user chooses Custom)
    int manualPriority;
    public int ManualPriority
    {
        get => manualPriority;
        set
        {
            if (manualPriority == value) return;
            manualPriority = value;
            OnPropertyChanged();
            // if Custom selected, persist new manual value
            if (IsCustomPriority)
                _ = PersistPriorityAsync();
        }
    }

    // Selected item from Picker (EnumDisplayItem)
    EnumDisplayItem selectedPriorityItem;
    public EnumDisplayItem SelectedPriorityItem
    {
        get => selectedPriorityItem;
        set
        {
            if (selectedPriorityItem == value) return;
            selectedPriorityItem = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsCustomPriority));
            // update model.Priority and persist
            _ = PersistPriorityAsync();
        }
    }

    public bool IsCustomPriority => SelectedPriorityItem?.Value?.ToString() == nameof(PriorityLevel.Custom);

    // Effective numeric priority used for DB and logic
    public int EffectivePriority
    {
        get
        {
            if (SelectedPriorityItem == null) return 0;
            var enumVal = SelectedPriorityItem.Value;
            if (enumVal is PriorityLevel pl && pl == PriorityLevel.Custom) return ManualPriority;
            // default: cast enum to int
            try { return Convert.ToInt32(enumVal); }
            catch { return 0; }
        }
    }

    async Task PersistPriorityAsync()
    {
        try
        {
            model.Priority = EffectivePriority;
            await repo.SaveChecklistItemAsync(model).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    // convenience: convert numeric DB value -> EnumDisplayItem (best effort)
    EnumDisplayItem PriorityToDisplayItem(int numeric)
    {
        // try to match numeric to defined enum values
        foreach (PriorityLevel p in Enum.GetValues(typeof(PriorityLevel)))
        {
            if (Convert.ToInt32(p) == numeric)
            {
                return new EnumDisplayItem { Value = p, Description = p.GetDescription() };
            }
        }
        // otherwise return Custom with manual numeric value
        return new EnumDisplayItem { Value = PriorityLevel.Custom, Description = PriorityLevel.Custom.GetDescription() };
    }

    // Save whole model (call from a Save command)
    public Task SaveAllFieldsAsync()
    {
        model.Title = Title;
        model.IsChecked = IsChecked;
        model.Quantity = Quantity;
        model.Unit = Unit;
        model.Priority = EffectivePriority;
        return repo.SaveChecklistItemAsync(model);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}