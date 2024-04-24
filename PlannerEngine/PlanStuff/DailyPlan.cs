// <copyright file="DailyPlan.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.GoalStuff;
using PlannerEngine.PlateStuff;

namespace PlannerEngine.PlanStuff;

/// <summary>
/// DailyPlan class. The wrapper for the Plates.
/// </summary>
public class DailyPlan
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DailyPlan"/> class.
    /// </summary>
    /// <param name="date">DateTime.</param>
    /// <param name="goal">DailyGoal.</param>
    public DailyPlan(DateTime date, DailyGoal goal)
    {
        this.Date = date;
        this.Goal = goal;
        this.Plates = [];
    }

    /// <summary>
    /// Gets Date.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets Goal.
    /// </summary>
    public DailyGoal Goal { get; }

    /// <summary>
    /// Gets Plates.
    /// </summary>
    public List<Plate> Plates { get; }

    /// <summary>
    /// Calculates the summary Goal of all the plates.
    /// </summary>
    /// <returns>Goal.</returns>
    public Goal CalculateAllPlates()
    {
        var calc = new Goal();
        foreach (var cat in Enum.GetValues(typeof(FoodCategory)))
        {
            calc[(FoodCategory)cat] = 0;
        }

        foreach (var plate in this.Plates)
        {
            var plateCalc = plate.CalculateCategoryFilled();
            foreach (var item in plate.CalculateCategoryFilled())
            {
                calc[item.Key] += item.Value;
            }
        }

        return calc;
    }
}