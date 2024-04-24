// <copyright file="AddFoodItemViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using MealPlanner.Models;
using PlannerEngine.FoodStuff;
using ReactiveUI;

namespace MealPlanner.ViewModels;

/// <summary>
/// ViewModel for AddFoodItem.
/// </summary>
public class AddFoodItemViewModel : ViewModelBase
{
    private string name = string.Empty;
    private double servingSize;
    private string unitName = string.Empty;
    private double unitUnit;
    private double quantity;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddFoodItemViewModel"/> class.
    /// </summary>
    /// <param name="item">Nullable FoodItemModel.</param>
    public AddFoodItemViewModel(FoodItemModel? item)
    {
        if (item is null)
        {
            item = new FoodItemModel
            {
                Categories = [],
                IsEdited = false,
            };
        }
        else
        {
            item.IsEdited = true;
        }

        var isValidObservable = this.WhenAnyValue(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        // Set the new values to the previous values
        this.Name = item.Name;
        this.Categories = this.ArrayToEnumerables(item.Categories);
        this.UnitName = item.Unit.Name;
        this.UnitUnit = item.Unit.Unit;
        this.ServingSize = item.ServingSize;
        this.Quantity = item.Quantity;

        // Create Commands that will take in newly adjusted values
        this.OkCommand = ReactiveCommand.Create(
            () =>
            {
                item.Name = this.Name;
                item.Categories = this.EnumerablesToArray();
                item.ServingSize = this.ServingSize;
                item.Quantity = this.Quantity;
                item.Unit.Name = this.UnitName;
                item.Unit.Unit = this.UnitUnit;
                return item;
            });

        this.CancelCommand = ReactiveCommand.Create(() => { });
    }

    /// <summary>
    /// Gets ReactiveCommand that ties a Unit to a new FoodItemModel.
    /// </summary>
    public ReactiveCommand<Unit, FoodItemModel> OkCommand { get; }

    /// <summary>
    /// Gets ReactiveCommand that ties a Unit to a Unit.
    /// </summary>
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    /// <summary>
    /// Gets or sets Name.
    /// </summary>
    public string Name
    {
        get => this.name;
        set => this.RaiseAndSetIfChanged(ref this.name, value);
    }

    /// <summary>
    /// Gets or sets list of FoodCategories.
    /// </summary>
    public IEnumerable<FoodCategoryModel> Categories { get; set; }

    /// <summary>
    /// Gets or sets the new serving size.
    /// </summary>
    public double ServingSize
    {
        get => this.servingSize;
        set => this.RaiseAndSetIfChanged(ref this.servingSize, value);
    }

    /// <summary>
    /// Gets or sets the unit's name.
    /// </summary>
    public string UnitName
    {
        get => this.unitName;
        set => this.RaiseAndSetIfChanged(ref this.unitName, value);
    }

    /// <summary>
    /// Gets or sets the unit's size.
    /// </summary>
    public double UnitUnit
    {
        get => this.unitUnit;
        set => this.RaiseAndSetIfChanged(ref this.unitUnit, value);
    }

    /// <summary>
    /// Gets or sets the Quantity.
    /// </summary>
    public double Quantity
    {
        get => this.quantity;
        set => this.RaiseAndSetIfChanged(ref this.quantity, value);
    }

    /// <summary>
    /// Gets the list of FoodCategories based off of the FoodCategoryModels that had the IsSelected property true.
    /// </summary>
    /// <returns>FoodCategory list.</returns>
    private FoodCategory[] EnumerablesToArray()
    {
        List<FoodCategory> foodCategories = [];
        foreach (var cat in this.Categories)
        {
            if (cat.IsChecked)
            {
                foodCategories.Add(cat.Category);
            }
        }

        var finale = foodCategories.ToArray();
        return finale;
    }

    private IEnumerable<FoodCategoryModel> ArrayToEnumerables(FoodCategory[] categories)
    {
        var cats = new List<FoodCategoryModel>();
        cats.Add(new FoodCategoryModel(FoodCategory.Fruits, categories.Contains(FoodCategory.Fruits)));
        cats.Add(new FoodCategoryModel(FoodCategory.Vegetables, categories.Contains(FoodCategory.Vegetables)));
        cats.Add(new FoodCategoryModel(FoodCategory.Grains, categories.Contains(FoodCategory.Grains)));
        cats.Add(new FoodCategoryModel(FoodCategory.Proteins, categories.Contains(FoodCategory.Proteins)));
        cats.Add(new FoodCategoryModel(FoodCategory.Dairy, categories.Contains(FoodCategory.Dairy)));

        return cats;
    }
}