// <copyright file="FoodItemService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using MealPlanner.Models;
using PlannerEngine.FoodStuff;
using PlannerEngine.Units;

namespace MealPlanner.TempServices;

/// <summary>
/// Temporary holder for Plate while we get everything working.
/// </summary>
public class FoodItemService
{
    // TODO: Change this class to work with the fridge.
    private Fridge fridge;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItemService"/> class.
    /// </summary>
    public FoodItemService(Fridge fridge)
    {
        this.fridge = fridge;
    }

    /// <summary>
    /// Sets up the IEnumerable of FoodItemModel.
    /// </summary>
    /// <returns>List of FoodItemModel.</returns>
    public IEnumerable<FoodItemModel> GetItems()
    {
        var foods = this.fridge.FridgeContents();
        var foodItemModels = new List<FoodItemModel>();
        foreach (var item in foods)
        {
            foodItemModels.Add(new FoodItemModel(item));
        }

        return foodItemModels;
    }

    /// <summary>
    /// Puts together default items.
    /// </summary>
    /// <returns>IEnumerable of FoodItem.</returns>
    public IEnumerable<FoodItem> GetFoodItems() => new FoodItem[]
    {
        new FoodItem([FoodCategory.Dairy], "Milk", new ItemUnit("cup", 1.0), 1),
        new FoodItem(
            [FoodCategory.Vegetables, FoodCategory.Proteins],
            "Lentils",
            new ItemUnit("ounce", 1.0),
            0.1),
    };
}
