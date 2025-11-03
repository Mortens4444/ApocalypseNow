using System.Globalization;

namespace ApocalypseNow.Converters;

internal class EnumToListConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // parameter is the enum Type
        var enumType = parameter as Type;
        if (enumType == null || !enumType.IsEnum) return null;
        var values = Enum.GetValues(enumType).Cast<object>().ToList();
        return values;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}