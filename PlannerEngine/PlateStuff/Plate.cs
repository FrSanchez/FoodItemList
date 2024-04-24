// <copyright file="Plate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;

namespace PlannerEngine.PlateStuff;

/// <summary>
/// Plate class.
/// </summary>
public class Plate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Plate"/> class.
    /// </summary>
    /// <param name="date">DateTime.</param>
    /// <param name="meal">MealType.</param>
    public Plate(DateTime date, MealType meal)
    {
        this.Date = date;
        this.MealType = meal;
        this.PlateItems = [];
    }

    /// <summary>
    /// Gets Date.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets MealType.
    /// </summary>
    public MealType MealType { get; }

    /// <summary>
    /// Gets PlateItems.
    /// </summary>
    public List<PlateItem> PlateItems { get; }

    /// <summary>
    /// Calculates the amount of food category that all the plate items fill.
    /// </summary>
    /// <returns>Dictionary.</returns>
    public Goal CalculateCategoryFilled()
    {
        var calc = new Goal();

        // Initialize calc
        foreach (var cat in Enum.GetValues(typeof(FoodCategory)))
        {
            calc[(FoodCategory)cat] = 0;
        }

        // For each plate item
        foreach (var food in this.PlateItems)
        {
            // For each food category in each item
            foreach (var category in food.Item.Categories)
            {
                calc[category] += food.Item.ServingSize * food.Qty;
            }
        }

        return calc;
    }
}