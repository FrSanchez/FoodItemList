// <copyright file="FoodCategoryImageConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PlannerEngine.FoodStuff;

namespace MealPlanner.Converters;

/// <summary>
/// Class for connecting images to related categories.
/// </summary>
public class FoodCategoryImageConverter : IValueConverter
{
    /// <summary>
    /// Converts food category to a specific Bitmap Image.
    /// </summary>
    /// <param name="value">nullable object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">Nullable object.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>object.</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is FoodCategory category)
        {
            var img = @"avares://MealPlanner/Assets/dish.png";
            if (targetType.IsAssignableTo(typeof(IImage)))
            {
                switch (category)
                {
                    case FoodCategory.Fruits:
                        img = @"avares://MealPlanner/Assets/fruits.png";
                        break;
                    case FoodCategory.Vegetables:
                        img = @"avares://MealPlanner/Assets/vegetable.png";
                        break;
                    case FoodCategory.Grains:
                        img = @"avares://MealPlanner/Assets/grains.png";
                        break;
                    case FoodCategory.Proteins:
                        img = @"avares://MealPlanner/Assets/beef.png";
                        break;
                    case FoodCategory.Dairy:
                        img = @"avares://MealPlanner/Assets/milk.png";
                        break;
                }

                if (parameter is not int targetWidth)
                {
                    targetWidth = 32;
                }

                using Bitmap fullImage = new Bitmap(AssetLoader.Open(new Uri(img)));
                var newHeight = fullImage.Size.Width > targetWidth
                    ? targetWidth / fullImage.Size.Width * fullImage.Size.Height
                    : fullImage.Size.Height;
                return fullImage.CreateScaledBitmap(new PixelSize(targetWidth, (int)newHeight));
            }
        }

        return value?.ToString();
    }

    /// <summary>
    /// Reverses conversion.
    /// </summary>
    /// <param name="value">nullable object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">Nullable object.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>object.</returns>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}