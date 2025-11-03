using ApocalypseNow.Data;
using ApocalypseNow.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ApocalypseNow.ViewModels;

internal partial class ChecklistViewModel : INotifyPropertyChanged
{
    private const string DateFormat = "yyyy-MM-dd HH:mm:ss";
    private readonly ChecklistRepository repo = new();

    public ObservableCollection<ChecklistItem> Items { get; } = [];

    public ICommand AddItemCommand { get; }

    public ICommand SaveCommand { get; }

    public ICommand DeleteItemCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public ChecklistViewModel()
    {
        AddItemCommand = new Command<object>(AddItem);
        SaveCommand = new Command(async () => await SaveAsync().ConfigureAwait(false));
        DeleteItemCommand = new Command<string>(async id => await DeleteItemAsync(id).ConfigureAwait(false));

        _ = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await repo.InitDbAsync().ConfigureAwait(false);
        await DbInit.InitializeAndSeedAsync().ConfigureAwait(false);
        await LoadAsync().ConfigureAwait(false);
    }

    private void AddItem(object param)
    {
        var text = param?.ToString() ?? String.Empty;
        if (String.IsNullOrWhiteSpace(text))
        {
            return;
        }

        var item = new ChecklistItem { Title = text };
        Items.Add(item);
    }

    private async Task DeleteItemAsync(string id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            Items.Remove(item);
            await repo.DeleteChecklistItemAsync(id).ConfigureAwait(false);
        }
    }

    private async Task SaveAsync()
    {
        foreach (var it in Items)
        {
            await repo.SaveChecklistItemAsync(it).ConfigureAwait(false);
        }
    }

    private async Task LoadAsync()
    {
        Items.Clear();
        var list = await repo.GetAllChecklistItemsAsync().ConfigureAwait(false);
        foreach (var it in list)
        {
            Items.Add(it);
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}