// <copyright file="Goal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;

namespace PlannerEngine.PlateStuff;

/// <summary>
/// Goal class, contains Dictionary of FoodCategory and double.
/// </summary>
public class Goal : Dictionary<FoodCategory, double>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Goal"/> class.
    /// </summary>
    public Goal()
    {
    }

    /// <summary>
    /// Overrides ToString() method with own string.
    /// </summary>
    /// <returns>string.</returns>
    public override string ToString()
    {
        return string.Join(", ", this.Select(pair => $"{pair.Key} => {pair.Value}"));
    }
}