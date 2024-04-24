// <copyright file="Utils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.PlateStuff;

namespace PlannerEngineTests;

/// <summary>
/// Utility helpers.
/// </summary>
public class Utils
{
    /// <summary>
    /// Builds expected output using given arrays.
    /// </summary>
    /// <param name="categories">FoodCategory[].</param>
    /// <param name="qtys">double[].</param>
    /// <returns>Goal.</returns>
    public static Goal BuildExpected(IReadOnlyList<FoodCategory> categories, IReadOnlyList<double> qtys)
    {
        var calc = new Goal();
        foreach (var cat in Enum.GetValues(typeof(FoodCategory)))
        {
            calc[(FoodCategory)cat] = 0;
        }

        for (var i = 0; i < categories.Count; i++)
        {
            calc[categories[i]] = qtys[i];
        }

        return calc;
    }
}