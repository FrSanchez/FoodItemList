// <copyright file="FoodCategoryModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Globalization;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using MealPlanner.Converters;
using PlannerEngine.FoodStuff;

namespace MealPlanner.Models;

/// <summary>
/// FoodCategory Model class. Model version of FoodCategory for MVVM purposes.
/// </summary>
public class FoodCategoryModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoodCategoryModel"/> class.
    /// </summary>
    /// <param name="cat">FoodCategory.</param>
    /// <param name="isChecked">bool.</param>
    public FoodCategoryModel(FoodCategory cat)
    {
        this.Category = cat;
        this.IsChecked = false;
        var converter = new FoodCategoryImageConverter();
        this.Image = (Bitmap?)converter.Convert(cat, typeof(Bitmap), 32, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodCategoryModel"/> class.
    /// </summary>
    /// <param name="cat">FoodCategory.</param>
    /// <param name="isChecked">bool.</param>
    public FoodCategoryModel(FoodCategory cat, bool isChecked = false)
    {
        this.Category = cat;
        this.IsChecked = isChecked;
        var converter = new FoodCategoryImageConverter();
        this.Image = (Bitmap?)converter.Convert(cat, typeof(Bitmap), 32, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Gets or sets Category.
    /// </summary>
    public FoodCategory Category { get; set; }

    /// <summary>
    /// Gets Name Property.
    /// </summary>
    public string Name => this.Category.ToString();

    /// <summary>
    /// Gets or sets a value indicating whether gets or sets IsChecked.
    /// </summary>
    public bool IsChecked { get; set; }

    public Bitmap Image { get; set; }
}