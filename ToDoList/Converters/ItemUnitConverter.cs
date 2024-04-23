using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using ToDoList.DataModel;

namespace ToDoList.Converters;

public class ItemUnitConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ItemUnit sourceItemUnit)
        {
            return value.ToString();
        }

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}