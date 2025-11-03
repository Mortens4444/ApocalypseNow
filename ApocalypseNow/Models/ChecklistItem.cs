using SQLite;

namespace ApocalypseNow.Models;

[Table("ChecklistItems")]
public class ChecklistItem
{
    [PrimaryKey]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = String.Empty;
    public bool IsChecked { get; set; }
    public string Location { get; set; } = String.Empty;
    public string Quantity { get; set; } = String.Empty;
    public string Unit { get; set; } = String.Empty;
    public int Priority { get; set; } // numeric priority (bigger = higher)
}

//[Table("ChecklistItems")]
//public class ChecklistItem : INotifyPropertyChanged
//{
//    [PrimaryKey]
//    public string Id { get; set; } = Guid.NewGuid().ToString();

//    string title = String.Empty;
//    public string Title
//    {
//        get => title;
//        set { title = value; OnPropertyChanged(nameof(Title)); }
//    }

//    bool isChecked;
//    public bool IsChecked
//    {
//        get => isChecked;
//        set { isChecked = value; OnPropertyChanged(nameof(IsChecked)); }
//    }

//    string location = String.Empty;
//    public string Location
//    {
//        get => location;
//        set { location = value; OnPropertyChanged(nameof(Location)); }
//    }

//    string quantity = String.Empty;
//    public string Quantity
//    {
//        get => quantity;
//        set { quantity = value; OnPropertyChanged(nameof(Quantity)); }
//    }

//    string unit = String.Empty;
//    public string Unit
//    {
//        get => unit;
//        set { unit = value; OnPropertyChanged(nameof(Unit)); }
//    }

//    int priority;
//    public int Priority
//    {
//        get => priority;
//        set { priority = value; OnPropertyChanged(nameof(Priority)); }
//    }

//    public event PropertyChangedEventHandler PropertyChanged;
//    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
//}