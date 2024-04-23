
using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ToDoList.DataModel;

namespace ToDoList.Converters;

public class FoodCategoryConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is FoodCategory category)
        {
            var img = @"avares://ToDoList/Assets/dish.png";
            if (targetType.IsAssignableTo(typeof(IImage)))
            {
                switch (category)
                {
                    case FoodCategory.Dairy:
                        img = @"avares://ToDoList/Assets/milk.png";
                        break;
                    case FoodCategory.Fruit:
                        img = @"avares://ToDoList/Assets/fruits.png";
                        break;
                    case FoodCategory.Grains:
                        img = @"avares://ToDoList/Assets/rice.png";
                        break;
                    case FoodCategory.Protein:
                        img = @"avares://ToDoList/Assets/beef.png";
                        break;
                    case FoodCategory.Vegetable:
                        img = @"avares://ToDoList/Assets/vegetable.png";
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

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}