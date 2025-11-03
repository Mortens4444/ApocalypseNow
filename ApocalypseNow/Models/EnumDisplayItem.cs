namespace ApocalypseNow.Models;

public class EnumDisplayItem
{
    public Enum Value { get; set; }
    public string Description { get; set; }

    public override string ToString() => Description ?? Value?.ToString() ?? String.Empty;
}
