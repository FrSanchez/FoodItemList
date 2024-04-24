// <copyright file="PlannerRelatedTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.GoalStuff;
using PlannerEngine.PlanStuff;
using PlannerEngine.Units;

namespace PlannerEngineTests;

/// <summary>
/// Tests related to the Planner class.
/// </summary>
[TestFixture]
public class PlannerRelatedTests
{
    /// <summary>
    /// Test related to when there are no plates with stuff.
    /// </summary>
    [Test]
    public void NoPlatesPlanner()
    {
        var goal = new DailyGoal();
        goal.SetCategoryUnit(FoodCategory.Dairy, new ItemUnit("cup", 2.5));
        goal.SetCategoryUnit(FoodCategory.Fruits, new ItemUnit("cup", 1));
        goal.SetCategoryUnit(FoodCategory.Vegetables, new ItemUnit("cup", 1.5));
        goal.SetCategoryUnit(FoodCategory.Proteins, new ItemUnit("ounces", 3));
        goal.SetCategoryUnit(FoodCategory.Grains, new ItemUnit("ounces", 4));
        var plan = new DailyPlan(DateTime.Today, goal);
        var actual = plan.CalculateAllPlates();
        var expected = Utils.BuildExpected([], []);
        Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
    }
}