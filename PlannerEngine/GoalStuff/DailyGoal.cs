// <copyright file="DailyGoal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.Units;

namespace PlannerEngine.GoalStuff;

/// <summary>
/// DailyGoal class. Contains collection of FoodCategories with respective ItemUnits.
/// </summary>
public class DailyGoal
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DailyGoal"/> class.
    /// </summary>
    public DailyGoal()
    {
        this.GoalCategories = [];
        foreach (var category in Enum.GetValues(typeof(FoodCategory)))
        {
            this.GoalCategories.Add(new CategoryGoal((FoodCategory)category, new ItemUnit(string.Empty, 0.0)));
        }
    }

    /// <summary>
    /// Gets the FoodCategories that are tied to ItemUnits.
    /// </summary>
    public List<CategoryGoal> GoalCategories { get; }
}