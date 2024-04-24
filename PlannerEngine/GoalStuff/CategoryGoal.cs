// <copyright file="CategoryGoal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.Units;

namespace PlannerEngine.GoalStuff;

public class CategoryGoal(FoodCategory cat, ItemUnit unit)
{
    public FoodCategory Category { get; set; } = cat;

    public ItemUnit Unit { get; set; } = unit;
}