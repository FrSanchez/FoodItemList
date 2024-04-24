// <copyright file="PlateRelatedTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;
using PlannerEngine.PlateStuff;
using PlannerEngine.Units;

namespace PlannerEngineTests;

/// <summary>
/// Tests related to the plate.
/// </summary>
[TestFixture]
public class PlateRelatedTests
{
    /// <summary>
    /// Tests the calculation of an empty plate.
    /// </summary>
    [Test]
    public void CalculateEmptyPlate()
    {
        var plate = new Plate(DateTime.Today, MealType.Breakfast);
        var calc = plate.CalculateCategoryFilled();
        foreach (var key in calc.Keys)
        {
            if (calc[key] != 0)
            {
                Assert.Fail();
            }
        }

        Assert.That(calc.Count, Is.EqualTo(5));
    }

    /// <summary>
    /// Tests calculation for single item.
    /// </summary>
    [Test]
    public void CalculateSingleItemPlate()
    {
        var plate = new Plate(DateTime.Today, MealType.Breakfast);
        var testItem = new FoodItem(
            [FoodCategory.Fruits],
            "Apple",
            new ItemUnit("ounce", 2),
            0.5);
        var plateItem = new PlateItem(testItem, 2);
        plate.PlateItems.Add(plateItem);
        var calc = plate.CalculateCategoryFilled();
        Assert.That(calc, Has.Count.EqualTo(5));
        Assert.That(calc[FoodCategory.Fruits], Is.EqualTo(1));
    }

    /// <summary>
    /// General set-up for running data-driven tests.
    /// </summary>
    /// <param name="items">List of PlateItems.</param>
    /// <param name="expected">Goal.</param>
    [TestCaseSource(nameof(PlateTestCaseData))]
    public void PlateCalculatorTest(List<PlateItem> items, Goal expected)
    {
        var plate = new Plate(DateTime.Today, MealType.Breakfast);
        foreach (var item in items)
        {
            plate.PlateItems.Add(item);
        }

        var calc = plate.CalculateCategoryFilled();
        Assert.That(calc, Has.Count.EqualTo(5));
        Assert.That(calc.ToString(), Is.EqualTo(expected.ToString()));
    }

    /// <summary>
    /// Data for Test cases.
    /// </summary>
#pragma warning disable SA1201
    public static object[] PlateTestCaseData =
#pragma warning restore SA1201
    {
        new object[]
        {
            new List<PlateItem>
            {
                new (
                new FoodItem(
                [FoodCategory.Fruits],
                "Apple",
                new ItemUnit("ounce", 2),
                0.5),
                2),
            },

            // Builds expected output.
            Utils.BuildExpected([FoodCategory.Fruits], [1]),
        },

        // What's sent to test case
        new object[]
        {
                // List of PlateItems
                new List<PlateItem>
                {
                    // Plate Items
                new (
                    new FoodItem(
                    [FoodCategory.Fruits],
                    "Apple",
                    new ItemUnit("ounce", 2),
                    0.5),
                    2),
                new (
                    new FoodItem(
                        [FoodCategory.Vegetables, FoodCategory.Proteins],
                        "Lentils",
                        new ItemUnit("ounce", 2),
                        0.3),
                    1),
                },

                // Builds expected output.
                Utils.BuildExpected(
                    [FoodCategory.Fruits, FoodCategory.Vegetables, FoodCategory.Proteins,],
                    [1, 0.3, 0.3,]),
        },
        new object[]
        {
            new List<PlateItem>
            {
                new(
                    new FoodItem(
                    [FoodCategory.Proteins],
                    "Beef",
                    new ItemUnit("grams", 1),
                    0.05),
                    10),
            },
            Utils.BuildExpected([FoodCategory.Proteins], [0.5]),
        },
        new object[]
        {
            new List<PlateItem>
            {
                new (
                    new FoodItem(
                    [FoodCategory.Dairy],
                    "Milk",
                    new ItemUnit("cups", 1),
                    1),
                    2),
                new (
                    new FoodItem(
                        [FoodCategory.Grains],
                        "Granola",
                        new ItemUnit("cups", 1),
                        1),
                    2),
            },
            Utils.BuildExpected([FoodCategory.Dairy, FoodCategory.Grains], [2, 2]),
        },
    };
}