using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Globalization;


namespace MusicPlayer.Converters
{
    public class DividerConverter :IValueConverter
    {
        public static readonly DividerConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter,
                                                                CultureInfo culture)
        {
            if (value is float sourceValue && parameter is float divisionAmount
                && divisionAmount != 0 &&targetType.IsAssignableTo(typeof(float)))
            {
                return sourceValue / divisionAmount;
            }
            // converter used for the wrong type
            return new BindingNotification(new InvalidCastException(),
                                                    BindingErrorType.Error);
        }

        public object ConvertBack(object? value, Type targetType,
                                    object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
