// <copyright file="FoodCategoriesConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using System.Text;
using Avalonia.Data;
using Avalonia.Data.Converters;
using PlannerEngine.FoodStuff;

namespace MealPlanner.Converters;

/// <summary>
/// Converter class that converts a list of FoodCategories to strings and vice versa.
/// </summary>
public class FoodCategoriesConverter : IValueConverter
{
    /// <summary>
    /// Convert a list of FoodCategories to a string.
    /// </summary>
    /// <param name="value">object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">object?.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>nullable object.</returns>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not FoodCategory[] sourceCategories)
        {
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        // return new SolidColorBrush(sourceColor);
        var sb = new StringBuilder("[ ");
        var first = true;

        // for each category
        foreach (var cat in sourceCategories)
        {
            if (!first)
            {
                sb.Append(", ");
            }

            sb.Append(cat);
            first = false;
        }

        sb.Append(" ]");

        return sb.ToString();

        // converter used for the wrong type
    }

    /// <summary>
    /// Convert an object to an object.
    /// </summary>
    /// <param name="value">object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">object?.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>nullable object.</returns>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}