using System.Globalization;

namespace ApocalypseNow.Converters;

internal class EnumToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return String.Empty;
        // egyszerű: CamelCase -> spaced words (Basic)
        var s = value.ToString();
        var sb = new System.Text.StringBuilder();
        foreach (var c in s)
        {
            if (char.IsUpper(c) && sb.Length > 0) sb.Append(' ');
            sb.Append(c);
        }
        return sb.ToString();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => value;
}