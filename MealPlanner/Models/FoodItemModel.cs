// <copyright file="FoodItemModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.Units;

namespace MealPlanner.Models;

/// <summary>
/// FoodItem Model class. Model version of FoodItem for MVVM purposes.
/// </summary>
public class FoodItemModel
{
    private FoodItem item;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItemModel"/> class.
    /// Automatically fills in for FoodItemModel.
    /// </summary>
    /// <param name="item">FoodItem.</param>
    public FoodItemModel(FoodItem item)
    {
        this.item = item;
        this.IsChecked = false;
        this.Quantity = 0;
        this.IsEdited = false;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItemModel"/> class.
    /// </summary>
    /// <param name="item">FoodItem.</param>
    /// <param name="b">bool.</param>
    /// <param name="quantity">double.</param>
    public FoodItemModel(FoodItem item, bool b, double quantity)
    {
        this.item = item;
        this.IsChecked = b;
        this.Quantity = quantity;
        this.IsEdited = false;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItemModel"/> class.
    /// This instance will have nothing in .
    /// </summary>
    public FoodItemModel()
    {
        this.item = new FoodItem();
        this.IsChecked = false;
        this.Quantity = 0;
    }

    /// <summary>
    /// Gets or sets Categories related to FoodItem.
    /// </summary>
    public FoodCategory[] Categories
    {
        get => this.item.Categories;
        set => this.item.Categories = value;
    }

    /// <summary>
    /// Gets or sets Unit related to FoodItem.
    /// </summary>
    public ItemUnit Unit
    {
        get => this.item.Unit;
        set => this.item.Unit = value;
    }

    /// <summary>
    /// Gets or sets ServingSize related to FoodItem.
    /// </summary>
    public double ServingSize
    {
        get => this.item.ServingSize;
        set => this.item.ServingSize = value;
    }

    /// <summary>
    /// Gets Item related to FoodItem.
    /// </summary>
    public FoodItem Item => this.item;

    /// <summary>
    /// Gets or sets Name related to FoodItem.
    /// </summary>
    public string Name
    {
        get => this.item.Name;
        set => this.item.Name = value;
    }

    /// <summary>
    /// Gets or sets Quantity.
    /// </summary>
    public double Quantity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or sets IsChecked.
    /// </summary>
    public bool IsChecked { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a FoodItemModel is being edited or not.
    /// </summary>
    public bool IsEdited { get; set; }
}